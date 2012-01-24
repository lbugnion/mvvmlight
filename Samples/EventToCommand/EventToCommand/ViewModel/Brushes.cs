using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace EventToCommand.ViewModel
{
    public class Brushes
    {
        public Brush None
        {
            get
            {
                return new SolidColorBrush(Colors.Black);
            }
        }

        public Brush Brush1
        {
            get
            {
                return new SolidColorBrush(Colors.Orange);
            }
        }

        public Brush Brush2
        {
            get
            {
                return new SolidColorBrush(Colors.Red);
            }
        }

        public Brush Brush3
        {
            get
            {
                return new SolidColorBrush(Colors.Purple);
            }
        }

        public Brush Brush4
        {
            get
            {
                return new SolidColorBrush(Colors.Blue);
            }
        }

        public Brush Brush5
        {
            get
            {
                return new SolidColorBrush(Colors.Green);
            }
        }
    }
}
