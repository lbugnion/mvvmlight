// ****************************************************************************
// <copyright file="ISimpleIoc.cs" company="GalaSoft Laurent Bugnion">
// Copyright © GalaSoft Laurent Bugnion 2011
// </copyright>
// ****************************************************************************
// <author>Laurent Bugnion</author>
// <email>laurent@galasoft.ch</email>
// <date>10.4.2011</date>
// <project>GalaSoft.MvvmLight.Extras.Ioc</project>
// <web>http://www.galasoft.ch</web>
// <license>
// See license.txt in this project or http://www.galasoft.ch/license_MIT.txt
// </license>
// ****************************************************************************

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
    //// [ClassInfo(typeof(SimpleIoc))]
    public interface ISimpleIoc : IServiceLocator
    {
        /// <summary>
        /// Checks whether at least one instance of a given class is already created in the container.
        /// </summary>
        /// <typeparam name="TClass">The class that is queried.</typeparam>
        /// <returns>True if at least on instance of the class is already created, false otherwise.</returns>
        bool Contains<TClass>();

        /// <summary>
        /// Checks whether the instance with the given key is already created for a given class
        /// in the container.
        /// </summary>
        /// <typeparam name="TClass">The class that is queried.</typeparam>
        /// <param name="key">The key that is queried.</param>
        /// <returns>True if the instance with the given key is already registered for the given class,
        /// false otherwise.</returns>
        bool Contains<TClass>(string key);

        /// <summary>
        /// Registers a given type for a given interface.
        /// </summary>
        /// <typeparam name="TInterface">The interface for which instances will be resolved.</typeparam>
        /// <typeparam name="TClass">The type that must be used to create instances.</typeparam>
        void Register<TInterface, TClass>() where TClass : class, TInterface;

        /// <summary>
        /// Registers a given type.
        /// </summary>
        /// <typeparam name="TClass">The type that must be used to create instances.</typeparam>
        void Register<TClass>() where TClass : class;

        /// <summary>
        /// Registers a given instance for a given type.
        /// </summary>
        /// <typeparam name="TClass">The type that is being registered.</typeparam>
        /// <param name="instance">The instance that must be returned when the given type
        /// is resolved.</param>
        void Register<TClass>(TClass instance) where TClass : class;

        /// <summary>
        /// Registers a given instance for a given type and a given key.
        /// </summary>
        /// <typeparam name="TClass">The type that is being registered.</typeparam>
        /// <param name="instance">The instance that must be returned when the given type
        /// and the given key are resolved.</param>
        /// <param name="key">The key for which the given instance is registered.</param>
        void Register<TClass>(TClass instance, string key) where TClass : class;

        /// <summary>
        /// Resets the instance in its original states. This deletes all the
        /// registrations.
        /// </summary>
        void Reset();

        /// <summary>
        /// Unregisters a class from the cache and removes all the previously
        /// created instances.
        /// </summary>
        /// <typeparam name="TClass">The class that must be removed.</typeparam>
        void Unregister<TClass>() where TClass : class;

        /// <summary>
        /// Removes the given instance from the cache. The class itself remains
        /// registered and can be used to create other instances.
        /// </summary>
        /// <typeparam name="TClass">The type of the instance to be removed.</typeparam>
        /// <param name="instance">The instance that must be removed.</param>
        void Unregister<TClass>(TClass instance) where TClass : class;

        /// <summary>
        /// Removes the instance corresponding to the given key from the cache. The class itself remains
        /// registered and can be used to create other instances.
        /// </summary>
        /// <typeparam name="TClass">The type of the instance to be removed.</typeparam>
        /// <param name="key">The key corresponding to the instance that must be removed.</param>
        void Unregister<TClass>(string key) where TClass : class;
    }
}