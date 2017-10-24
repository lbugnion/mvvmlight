using DispatcherHelperSampleStd.Data.Helpers;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Threading.Tasks;

namespace DispatcherHelperSampleStd.Data.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private string _time = "00:00:00";
        private bool _clockIsRunning;

        public string Time
        {
            get
            {
                return _time;
            }
            set
            {
                Set(ref _time, value);
            }
        }

        public void StartClock()
        {
            _clockIsRunning = true;

            Task.Run(async () =>
            {
                while (_clockIsRunning)
                {
                    await Task.Delay(1000);

                    if (_clockIsRunning)
                    {
                        SimpleIoc.Default.GetInstance<IDispatcherHelper>()
                            .CheckBeginInvokeOnUi(() =>
                            {
                                var now = DateTime.Now;
                                Time = $"{now.Hour:D2}:{now.Minute:D2}:{now.Second:D2}";
                            });
                    }
                }
            });
        }

        public void StopClock()
        {
            _clockIsRunning = false;
        }
    }
}