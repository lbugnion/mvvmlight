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
// <LastBaseLevel>BL0001</LastBaseLevel>
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
    ////  VersionString = "4.0.0.0/BL0001",
    ////  DateString = "201104101020",
    ////  Description = "A very simple IOC container.",
    ////  UrlContacts = "http://www.galasoft.ch/contact_en.html",
    ////  Email = "laurent@galasoft.ch")]
    public class SimpleIoc : IServiceLocator
    {
        private readonly object[] _emptyArguments = new object[0];
        private readonly object _syncLock = new object();

        private readonly string _uniqueKey = Guid.NewGuid().ToString();

        private static SimpleIoc _default;
        private Dictionary<Type, Type> _registration = new Dictionary<Type, Type>();
        private Dictionary<Type, Dictionary<string, object>> _rot = new Dictionary<Type, Dictionary<string, object>>();

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

            if (!_rot.ContainsKey(classType))
            {
                return false;
            }

            if (string.IsNullOrEmpty(key))
            {
                return true;
            }
            
            return _rot[classType].ContainsKey(key);
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

                if (_registration.ContainsKey(interfaceType))
                {
                    if (_registration[interfaceType] != classType)
                    {
                        _registration[interfaceType] = classType;
                        _rot[interfaceType] = new Dictionary<string, object>();
                    }
                }
                else
                {
                    _registration.Add(interfaceType, classType);
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

                if (classType.IsInterface)
                {
                    throw new ArgumentException("An interface cannot be registered alone");
                }

                if (_registration.ContainsKey(classType))
                {
                    _registration[classType] = null;
                }
                else
                {
                    _registration.Add(classType, null);
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

                if (_registration.ContainsKey(classType))
                {
                    _registration[classType] = null;
                }
                else
                {
                    _registration.Add(classType, null);
                }

                Dictionary<string, object> list;

                if (_rot.ContainsKey(classType))
                {
                    list = _rot[classType];
                }
                else
                {
                    list = new Dictionary<string, object>();
                    _rot.Add(classType, list);
                }

                if (list.ContainsKey(key))
                {
                    list[key] = factory();
                }
                else
                {
                    list.Add(key, factory());
                }
            }
        }

        /// <summary>
        /// Resets the instance in its original states. This deletes all the
        /// registrations.
        /// </summary>
        public void Reset()
        {
            _registration = new Dictionary<Type, Type>();
            _rot = new Dictionary<Type, Dictionary<string, object>>();
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

                if (_rot.ContainsKey(classType))
                {
                    _rot.Remove(classType);
                }

                if (_registration.ContainsKey(classType))
                {
                    _registration.Remove(classType);
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

                if (_rot.ContainsKey(classType))
                {
                    var list = _rot[classType];

                    var pairs = list.Where(pair => pair.Value == instance).ToList();
                    for (var index = 0; index < pairs.Count(); index++)
                    {
                        list.Remove(pairs[index].Key);
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

                if (_rot.ContainsKey(classType))
                {
                    var list = _rot[classType];

                    var pairs = list.Where(pair => pair.Key == key).ToList();
                    for (var index = 0; index < pairs.Count(); index++)
                    {
                        list.Remove(pairs[index].Key);
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

                if (!_rot.ContainsKey(serviceType))
                {
                    if (!_registration.ContainsKey(serviceType))
                    {
                        throw new ActivationException("Type not found in cache: " + serviceType.FullName);
                    }

                    // TODO Refactor and extract common code in a method
                    var list = new Dictionary<string, object>();
                    _rot.Add(serviceType, list);

                    var constructor = GetConstructorInfo(serviceType);
                    var parameterInfos = constructor.GetParameters();
                    if (parameterInfos.Length == 0)
                    {
                        var instance = constructor.Invoke(_emptyArguments);
                        list.Add(key, instance);
                    }
                    else
                    {
                        var parameters = new object[parameterInfos.Length];
                        foreach (var parameterInfo in parameterInfos)
                        {
                            parameters[parameterInfo.Position] = GetService(parameterInfo.ParameterType);
                        }

                        var instance = constructor.Invoke(parameters);
                        list.Add(key, instance);
                    }
                }
                else
                {
                    if (!_rot[serviceType].ContainsKey(key))
                    {
                        var constructor = GetConstructorInfo(serviceType);
                        var parameterInfos = constructor.GetParameters();

                        object instance;

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

                        _rot[serviceType].Add(key, instance);
                    }
                }

                return _rot[serviceType][key];
            }
        }

        private ConstructorInfo GetConstructorInfo(Type serviceType)
        {
            var resolveTo = _registration[serviceType] ?? serviceType;
            var constructorInfos = resolveTo.GetConstructors();

            if (constructorInfos.Length > 1)
            {
                ConstructorInfo preferredConstructorInfo = null;

                for (var index = 0; index < constructorInfos.Length; index++)
                {
                    var attribute = Attribute.GetCustomAttribute(
                        constructorInfos[index], typeof (PreferredConstructorAttribute));

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
            if (_rot.ContainsKey(serviceType))
            {
                return _rot[serviceType].Values;
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

            if (_rot.ContainsKey(serviceType))
            {
                return _rot[serviceType].Values.Select(instance => (TService) instance);
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