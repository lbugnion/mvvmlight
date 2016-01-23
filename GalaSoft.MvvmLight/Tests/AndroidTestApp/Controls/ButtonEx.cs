using System;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Widget;

namespace GalaSoft.MvvmLight.Test.Controls
{
    public class ButtonEx : Button
    {
        public ButtonEx(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        public ButtonEx(Context context)
            : base(context)
        {
        }

        public ButtonEx(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
        }

        public ButtonEx(Context context, IAttributeSet attrs, int defStyleAttr)
            : base(context, attrs, defStyleAttr)
        {
        }

        public ButtonEx(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
            : base(context, attrs, defStyleAttr, defStyleRes)
        {
        }

        public void TestClick()
        {
            PerformClick();
        }
    }
}