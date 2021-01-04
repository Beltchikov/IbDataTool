using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace IbDataTool
{
    /// <summary>
    /// MainWindowViewModel
    /// </summary>
    public class MainWindowViewModel : DependencyObject
    {
        public static readonly DependencyProperty PortIbProperty;

        static MainWindowViewModel()
        {
            PortIbProperty = DependencyProperty.Register("PortIb", typeof(int), typeof(MainWindowViewModel), new PropertyMetadata(0));
        }

        public MainWindowViewModel()
        {
            PortIb = 4001;
        }

        /// <summary>
        /// PortIb
        /// </summary>
        public int PortIb
        {
            get { return (int)GetValue(PortIbProperty); }
            set { SetValue(PortIbProperty, value); }
        }




    }
}
