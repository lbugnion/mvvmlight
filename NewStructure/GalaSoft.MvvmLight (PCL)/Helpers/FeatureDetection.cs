using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace GalaSoft.MvvmLight.Helpers
{
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
