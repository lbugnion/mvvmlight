using GalaSoft.MvvmLight.Ioc;

namespace GalaSoft.MvvmLight.Test.Stubs
{
    public class TestBaseClass
    {
        public void Remove()
        {
            SimpleIoc.Default.Unregister(this);
        }
    }
}