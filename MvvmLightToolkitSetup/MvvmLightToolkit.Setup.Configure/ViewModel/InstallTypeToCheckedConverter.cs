// ****************************************************************************
// <copyright file="InstallTypeToCheckedConverter.cs" company="GalaSoft Laurent Bugnion">
// Copyright © GalaSoft Laurent Bugnion 2009
// </copyright>
// ****************************************************************************
// <author>Laurent Bugnion</author>
// <email>laurent@galasoft.ch</email>
// <date>5.7.2009</date>
// <project>MvvmLightToolkit.Setup.Configure</project>
// <web>http://www.galasoft.ch</web>
// <license>
// See license.txt in this solution or http://www.galasoft.ch/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using System.Globalization;
using System.Windows.Data;

namespace MvvmLightToolkit.Setup.Configure.ViewModel
{
    /// <summary>
    /// Converts a string representing an <see cref="InstallType" /> enum value into
    /// a boolean. True if it is equal to the parameter, false otherwise.
    /// </summary>
    public class InstallTypeToCheckedConverter : IValueConverter
    {
        /// <summary>
        /// Converts a string representing an <see cref="InstallType" /> enum value into
        /// a boolean. True if it is equal to the parameter, false otherwise.
        /// </summary>
        /// <param name="value">The current value of the enum.</param>
        /// <param name="targetType">The target type.</param>
        /// <param name="parameter">The value against which the current value is tested.</param>
        /// <param name="culture">The culture to use for the test.</param>
        /// <returns>True if the value is equal to the parameter, false otherwise.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var casted = (InstallType) value;
            var expected = (InstallType) Enum.Parse(typeof(InstallType), parameter.ToString());
            return casted == expected;
        }

        /// <summary>
        /// Reads the parameter, converts it into a <see cref="InstallType" /> enum value and returns it.
        /// </summary>
        /// <param name="value">This value is ignored.</param>
        /// <param name="targetType">The target type.</param>
        /// <param name="parameter">The enum value that must be returned.</param>
        /// <param name="culture">The culture to use for the test.</param>
        /// <returns>The value of <see cref="parameter" /> as an enum value.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var expected = (InstallType) Enum.Parse(typeof(InstallType), parameter.ToString());
            return expected;
        }
    }
}