// ****************************************************************************
// <copyright file="FeatureDetection.cs" company="GalaSoft Laurent Bugnion">
// Copyright © GalaSoft Laurent Bugnion 2009-2014
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

using System.Reflection;

namespace GalaSoft.MvvmLight.Helpers
{
    /// <summary>
    /// Helper class for platform and feature detection.
    /// </summary>
    static class FeatureDetection
    {
        private static bool? _isPrivateReflectionSupported;

        public static bool IsPrivateReflectionSupported
        {
            get
            {
                if (_isPrivateReflectionSupported == null)
                    _isPrivateReflectionSupported = ResolveIsPrivateReflectionSupported();

                return _isPrivateReflectionSupported.Value;
            }
        }

        private static bool ResolveIsPrivateReflectionSupported()
        {
            var inst = new ReflectionDetectionClass();

            try
            {
                var method = typeof(ReflectionDetectionClass).GetTypeInfo().GetDeclaredMethod("Method");
                method.Invoke(inst, null);
            }
            catch // If we get here, then our platform doesn't support private reflection
            {
                return false;
            }

            return true;
        }

        private class ReflectionDetectionClass
        {
// ReSharper disable UnusedMember.Local
            private void Method()
// ReSharper restore UnusedMember.Local
            {

            }
        }
    }
}
