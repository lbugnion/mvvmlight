// ****************************************************************************
// <copyright file="NotificationMessageActionGeneric.cs" company="GalaSoft Laurent Bugnion">
// Copyright © GalaSoft Laurent Bugnion 2009-2015
// </copyright>
// ****************************************************************************
// <author>Laurent Bugnion</author>
// <email>laurent@galasoft.ch</email>
// <date>30.09.2014</date>
// <project>GalaSoft.MvvmLight</project>
// <web>http://www.mvvmlight.net</web>
// <license>
// See license.txt in this solution or http://www.galasoft.ch/license_MIT.txt
// </license>
// ****************************************************************************

using System.Threading.Tasks;

namespace GalaSoft.MvvmLight.Helpers
{
    /// <summary>
    /// Helper class used when an async method is required,
    /// but the context is synchronous.
    /// </summary>
    public static class Empty
    {
        private static readonly Task ConcreteTask = new Task(
            () =>
            {
            });

        /// <summary>
        /// Gets the empty task.
        /// </summary>
        public static Task Task
        {
            get
            {
                return ConcreteTask;
            }
        }
    }
}