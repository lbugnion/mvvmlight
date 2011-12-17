// ****************************************************************************
// <copyright file="SimpleIoc.cs" company="GalaSoft Laurent Bugnion">
// Copyright © GalaSoft Laurent Bugnion 2011
// </copyright>
// ****************************************************************************
// <author>Laurent Bugnion</author>
// <email>laurent@galasoft.ch</email>
// <date>10.4.2011</date>
// <project>GalaSoft.MvvmLight.Extras</project>
// <web>http://www.galasoft.ch</web>
// <license>
// See license.txt in this project or http://www.galasoft.ch/license_MIT.txt
// </license>
// <LastBaseLevel>BL0002</LastBaseLevel>
// ****************************************************************************

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using Microsoft.Practices.ServiceLocation;

namespace GalaSoft.MvvmLight.Ioc
{
    /// <summary>
    /// A very simple IOC container with basic functionality needed to register and resolve
    /// instances. If needed, this class can be replaced by another more elaborate
    /// IOC container implementing the IServiceLocator interface.
    /// The inspiration for this class is at https://gist.github.com/716137 but it has
    /// been extended with additional features.
    /// </summary>
    //// [ClassInfo(typeof(SimpleIoc),
    ////  VersionString = "4.0.0.0/BL0002",
    ////  DateString = "201109042117",
    ////  Description = "A very simple IOC container.",
    ////  UrlContacts = "http://www.galasoft.ch/contact_en.html",
    ////  Email = "laurent@galasoft.ch")]
    public class SimpleIoc : IServiceLocator
    {
        private readonly object[] _emptyArguments = new object[0];
        private readonly object _syncLock = new object();

        private readonly string _uniqueKey = Guid.NewGuid().ToString();

        private static SimpleIoc _default;
        private readonly Dictionary<Type, Type> _interfaceToClassMap 
            = new Dictionary<Type, Type>();
        private readonly Dictionary<Type, Dictionary<string, Delegate>> _factories
            = new Dictionary<Type, Dictionary<string, Delegate>>();
        private readonly Dictionary<Type, Dictionary<string, object>> _instancesRegistry
            = new Dictionary<Type, Dictionary<string, object>>();

        /// <summary>
        /// This class' default instance.
        /// </summary>
        public static SimpleIoc Default
        {
            get
            {
                return _default ?? (_default = new SimpleIoc());
            }
        }

        /// <summary>
        /// Checks whether at least one instance of a given class is already created in the container.
        /// </summary>
        /// <typeparam name="TClass">The class that is queried.</typeparam>
        /// <returns>True if at least on instance of the class is already created, false otherwise.</returns>
        public bool Contains<TClass>()
        {
            return Contains<TClass>(null);
        }

        /// <summary>
        /// Checks whether the instance with the given key is already created for a given class
        /// in the container.
        /// </summary>
        /// <typeparam name="TClass">The class that is queried.</typeparam>
        /// <param name="key">The key that is queried.</param>
        /// <returns>True if the instance with the given key is already registered for the given class,
        /// false otherwise.</returns>
        public bool Contains<TClass>(string key)
        {
            var classType = typeof (TClass);

            if (!_instancesRegistry.ContainsKey(classType))
            {
                return false;
            }

            if (string.IsNullOrEmpty(key))
            {
                return true;
            }
            
            return _instancesRegistry[classType].ContainsKey(key);
        }

        public bool IsRegistered<T>()
        {
            var classType = typeof(T);
            return _interfaceToClassMap.ContainsKey(classType);
        }

        public bool IsRegistered<T>(string key)
        {
            var classType = typeof(T);

            if (!_interfaceToClassMap.ContainsKey(classType)
                || !_factories.ContainsKey(classType))
            {
                return false;
            }

            return _factories[classType].ContainsKey(key);
        }

        /// <summary>
        /// Registers a given type for a given interface.
        /// </summary>
        /// <typeparam name="TInterface">The interface for which instances will be resolved.</typeparam>
        /// <typeparam name="TClass">The type that must be used to create instances.</typeparam>
        [SuppressMessage(
            "Microsoft.Design",
            "CA1004",
            Justification = "This syntax is better than the alternatives.")]
        public void Register<TInterface, TClass>() where TClass : class, TInterface
        {
            lock (_syncLock)
            {
                var interfaceType = typeof (TInterface);
                var classType = typeof (TClass);

                if (_interfaceToClassMap.ContainsKey(interfaceType))
                {
                    if (_interfaceToClassMap[interfaceType] != classType)
                    {
                        if (_instancesRegistry.ContainsKey(interfaceType))
                        {
                            _instancesRegistry.Remove(interfaceType);
                        }
                    }
                    
                    _interfaceToClassMap[interfaceType] = classType;
                }
                else
                {
                    _interfaceToClassMap.Add(interfaceType, classType);
                }

                if (_factories.ContainsKey(interfaceType))
                {
                    _factories.Remove(interfaceType);
                }
            }
        }

        /// <summary>
        /// Registers a given type.
        /// </summary>
        /// <typeparam name="TClass">The type that must be used to create instances.</typeparam>
        [SuppressMessage(
            "Microsoft.Design",
            "CA1004",
            Justification = "This syntax is better than the alternatives.")]
        public void Register<TClass>() where TClass : class
        {
            lock (_syncLock)
            {
                var classType = typeof (TClass);

#if WIN8
                if (classType.GetTypeInfo().IsInterface)
#else
                if (classType.IsInterface)
#endif
                {
                    throw new ArgumentException("An interface cannot be registered alone");
                }

                if (_interfaceToClassMap.ContainsKey(classType))
                {
                    _interfaceToClassMap[classType] = null;
                }
                else
                {
                    _interfaceToClassMap.Add(classType, null);
                }

                if (_factories.ContainsKey(classType))
                {
                    _factories.Remove(classType);
                }
            }
        }

        /// <summary>
        /// Registers a given instance for a given type.
        /// </summary>
        /// <typeparam name="TClass">The type that is being registered.</typeparam>
        /// <param name="factory">The factory method able to create the instance that
        /// must be returned when the given type is resolved.</param>
        public void Register<TClass>(Func<TClass> factory) where TClass : class
        {
            Register(factory, _uniqueKey);
        }

        /// <summary>
        /// Registers a given instance for a given type and a given key.
        /// </summary>
        /// <typeparam name="TClass">The type that is being registered.</typeparam>
        /// <param name="factory">The factory method able to create the instance that
        /// must be returned when the given type is resolved.</param>
        /// <param name="key">The key for which the given instance is registered.</param>
        public void Register<TClass>(Func<TClass> factory, string key) where TClass : class
        {
            lock (_syncLock)
            {
                var classType = typeof (TClass);

                if (_interfaceToClassMap.ContainsKey(classType))
                {
                    _interfaceToClassMap[classType] = null;
                }
                else
                {
                    _interfaceToClassMap.Add(classType, null);
                }

                if (_instancesRegistry.ContainsKey(classType)
                    && _instancesRegistry[classType].ContainsKey(key))
                {
                    _instancesRegistry[classType].Remove(key);
                }

                if (_factories.ContainsKey(classType))
                {
                    if (_factories[classType].ContainsKey(key))
                    {
                        _factories[classType][key] = factory;
                    }
                    else
                    {
                        _factories[classType].Add(key, factory);
                    }
                }
                else
                {
                    var list = new Dictionary<string, Delegate>
                    {
                        {
                            key, 
                            factory
                        }
                    };

                    _factories.Add(classType, list);
                }
            }
        }

        /// <summary>
        /// Resets the instance in its original states. This deletes all the
        /// registrations.
        /// </summary>
        public void Reset()
        {
            _interfaceToClassMap.Clear();
            _instancesRegistry.Clear();
            _factories.Clear();
        }

        /// <summary>
        /// Unregisters a class from the cache and removes all the previously
        /// created instances.
        /// </summary>
        /// <typeparam name="TClass">The class that must be removed.</typeparam>
        [SuppressMessage(
            "Microsoft.Design",
            "CA1004",
            Justification = "This syntax is better than the alternatives.")]
        public void Unregister<TClass>() where TClass : class
        {
            lock (_syncLock)
            {
                var classType = typeof (TClass);

                if (_instancesRegistry.ContainsKey(classType))
                {
                    _instancesRegistry.Remove(classType);
                }

                if (_interfaceToClassMap.ContainsKey(classType))
                {
                    _interfaceToClassMap.Remove(classType);
                }

                if (_factories.ContainsKey(classType))
                {
                    _factories.Remove(classType);
                }
            }
        }

        /// <summary>
        /// Removes the given instance from the cache. The class itself remains
        /// registered and can be used to create other instances.
        /// </summary>
        /// <typeparam name="TClass">The type of the instance to be removed.</typeparam>
        /// <param name="instance">The instance that must be removed.</param>
        public void Unregister<TClass>(TClass instance) where TClass : class
        {
            lock (_syncLock)
            {
                var classType = typeof (TClass);

                if (_instancesRegistry.ContainsKey(classType))
                {
                    var list = _instancesRegistry[classType];

                    var pairs = list.Where(pair => pair.Value == instance).ToList();
                    for (var index = 0; index < pairs.Count(); index++)
                    {
                        var key = pairs[index].Key;

                        list.Remove(key);

                        if (_factories.ContainsKey(classType))
                        {
                            if (_factories[classType].ContainsKey(key))
                            {
                                _factories[classType].Remove(key);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Removes the instance corresponding to the given key from the cache. The class itself remains
        /// registered and can be used to create other instances.
        /// </summary>
        /// <typeparam name="TClass">The type of the instance to be removed.</typeparam>
        /// <param name="key">The key corresponding to the instance that must be removed.</param>
        [SuppressMessage(
            "Microsoft.Design",
            "CA1004",
            Justification = "This syntax is better than the alternatives.")]
        public void Unregister<TClass>(string key) where TClass : class
        {
            lock (_syncLock)
            {
                var classType = typeof (TClass);

                if (_instancesRegistry.ContainsKey(classType))
                {
                    var list = _instancesRegistry[classType];

                    var pairs = list.Where(pair => pair.Key == key).ToList();
                    for (var index = 0; index < pairs.Count(); index++)
                    {
                        list.Remove(pairs[index].Key);
                    }
                }

                if (_factories.ContainsKey(classType))
                {
                    if (_factories[classType].ContainsKey(key))
                    {
                        _factories[classType].Remove(key);
                    }
                }
            }
        }

        private object DoGetService(Type serviceType, string key)
        {
            lock (_syncLock)
            {
                if (string.IsNullOrEmpty(key))
                {
                    key = _uniqueKey;
                }

                Dictionary<string, object> instances;

                if (!_instancesRegistry.ContainsKey(serviceType))
                {
                    if (!_interfaceToClassMap.ContainsKey(serviceType))
                    {
                        throw new ActivationException("Type not found in cache: " + serviceType.FullName);
                    }

                    instances = new Dictionary<string, object>();
                    _instancesRegistry.Add(serviceType, instances);
                }
                else
                {
                    instances = _instancesRegistry[serviceType];
                }

                if (instances.ContainsKey(key))
                {
                    return instances[key];
                }

                object instance = null;

                if (_factories.ContainsKey(serviceType))
                {
                    if (_factories[serviceType].ContainsKey(key))
                    {
                        instance = _factories[serviceType][key].DynamicInvoke();
                    }
                    else
                    {
                        if (_factories[serviceType].ContainsKey(_uniqueKey))
                        {
                            instance = _factories[serviceType][_uniqueKey].DynamicInvoke();
                        }
                    }
                }
                
                if (instance == null)
                {
                    var constructor = GetConstructorInfo(serviceType);
                    var parameterInfos = constructor.GetParameters();

                    if (parameterInfos.Length == 0)
                    {
                        instance = constructor.Invoke(_emptyArguments);
                    }
                    else
                    {
                        var parameters = new object[parameterInfos.Length];
                        foreach (var parameterInfo in parameterInfos)
                        {
                            parameters[parameterInfo.Position] = GetService(parameterInfo.ParameterType);
                        }

                        instance = constructor.Invoke(parameters);
                    }
                }

                instances.Add(key, instance);
                return instance;
            }
        }

        private ConstructorInfo GetConstructorInfo(Type serviceType)
        {
            var resolveTo = _interfaceToClassMap[serviceType] ?? serviceType;

#if WIN8
            var constructorInfos = resolveTo.GetTypeInfo().DeclaredConstructors.ToArray();
#else
            var constructorInfos = resolveTo.GetConstructors();
#endif

            if (constructorInfos.Length > 1)
            {
                ConstructorInfo preferredConstructorInfo = null;

                for (var index = 0; index < constructorInfos.Length; index++)
                {
#if WIN8
                    var attribute = constructorInfos[index].GetCustomAttribute(
                        typeof (PreferredConstructorAttribute));
#else
                    var attribute = Attribute.GetCustomAttribute(
                        constructorInfos[index], typeof (PreferredConstructorAttribute));
#endif

                    if (attribute != null)
                    {
                        preferredConstructorInfo = constructorInfos[index];
                        break;
                    }
                }

                if (preferredConstructorInfo == null)
                {
                    throw new ActivationException(
                        "Cannot build instance: Multiple constructors found but none marked with PreferredConstructor");
                }

                return preferredConstructorInfo;
            }

            return constructorInfos[0];
        }

        #region Implementation of IServiceProvider

        /// <summary>
        /// Gets the service object of the specified type.
        /// </summary>
        /// <returns>
        /// A service object of type <paramref name="serviceType"/>.
        /// -or- 
        /// null if there is no service object of type <paramref name="serviceType"/>.
        /// </returns>
        /// <param name="serviceType">An object that specifies the type of service object to get.</param>
        public object GetService(Type serviceType)
        {
            return DoGetService(serviceType, _uniqueKey);
        }

        #endregion

        #region Implementation of IServiceLocator

        /// <summary>
        /// Provides a way to get all the instances of a given type available in the
        /// cache.
        /// </summary>
        /// <param name="serviceType">The class of which all instances
        /// must be returned.</param>
        /// <returns>All the instances of the given type.</returns>
        public IEnumerable<object> GetAllInstances(Type serviceType)
        {
            if (_instancesRegistry.ContainsKey(serviceType))
            {
                return _instancesRegistry[serviceType].Values;
            }

            return new List<object>();
        }

        /// <summary>
        /// Provides a way to get all the instances of a given type available in the
        /// cache.
        /// </summary>
        /// <typeparam name="TService">The class of which all instances
        /// must be returned.</typeparam>
        /// <returns>All the instances of the given type.</returns>
        public IEnumerable<TService> GetAllInstances<TService>()
        {
            var serviceType = typeof (TService);

            if (_instancesRegistry.ContainsKey(serviceType))
            {
                return _instancesRegistry[serviceType].Values.Select(instance => (TService) instance);
            }

            return new List<TService>();
        }

        /// <summary>
        /// Provides a way to get an instance of a given type. If no instance had been instantiated 
        /// before, a new instance will be created. If an instance had already
        /// been created, that same instance will be returned.
        /// <remarks>If the class has not been registered before, this method
        /// returns null!</remarks>
        /// </summary>
        /// <param name="serviceType">The class of which an instance
        /// must be returned.</param>
        /// <returns>An instance of the given type.</returns>
        public object GetInstance(Type serviceType)
        {
            return DoGetService(serviceType, _uniqueKey);
        }

        /// <summary>
        /// Provides a way to get an instance of a given type corresponding
        /// to a given key. If no instance had been instantiated with this
        /// key before, a new instance will be created. If an instance had already
        /// been created with the same key, that same instance will be returned.
        /// <remarks>If the class has not been registered before, this method
        /// returns null!</remarks>
        /// </summary>
        /// <param name="serviceType">The class of which an instance must be returned.</param>
        /// <param name="key">The key uniquely identifying this instance.</param>
        /// <returns>An instance corresponding to the given type and key.</returns>
        public object GetInstance(Type serviceType, string key)
        {
            return DoGetService(serviceType, key);
        }

        /// <summary>
        /// Provides a way to get an instance of a given type. If no instance had been instantiated 
        /// before, a new instance will be created. If an instance had already
        /// been created, that same instance will be returned.
        /// <remarks>If the class has not been registered before, this method
        /// returns null!</remarks>
        /// </summary>
        /// <typeparam name="TService">The class of which an instance
        /// must be returned.</typeparam>
        /// <returns>An instance of the given type.</returns>
        public TService GetInstance<TService>()
        {
            return (TService) DoGetService(typeof (TService), _uniqueKey);
        }

        /// <summary>
        /// Provides a way to get an instance of a given type corresponding
        /// to a given key. If no instance had been instantiated with this
        /// key before, a new instance will be created. If an instance had already
        /// been created with the same key, that same instance will be returned.
        /// <remarks>If the class has not been registered before, this method
        /// returns null!</remarks>
        /// </summary>
        /// <typeparam name="TService">The class of which an instance must be returned.</typeparam>
        /// <param name="key">The key uniquely identifying this instance.</param>
        /// <returns>An instance corresponding to the given type and key.</returns>
        public TService GetInstance<TService>(string key)
        {
            return (TService) DoGetService(typeof (TService), key);
        }

        #endregion
    }
}