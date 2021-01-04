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
        public static readonly DependencyProperty ConnectionStringProperty;
        public static readonly DependencyProperty LogProperty;

        public RelayCommand CommandImportData { get; set; }

        static MainWindowViewModel()
        {
            PortIbProperty = DependencyProperty.Register("PortIb", typeof(int), typeof(MainWindowViewModel), new PropertyMetadata(0));
            ConnectionStringProperty = DependencyProperty.Register("ConnectionString", typeof(string), typeof(MainWindowViewModel), new PropertyMetadata(string.Empty));
            LogProperty = DependencyProperty.Register("Log", typeof(string), typeof(MainWindowViewModel), new PropertyMetadata(string.Empty));
        }

        public MainWindowViewModel()
        {
            PortIb = 4001;
            ConnectionString = "TODO";
            Log = "Willkommen!";

            CommandImportData = new RelayCommand((p) => ImportData(p));
        }

        /// <summary>
        /// PortIb
        /// </summary>
        public int PortIb
        {
            get { return (int)GetValue(PortIbProperty); }
            set { SetValue(PortIbProperty, value); }
        }

        /// <summary>
        /// ConnectionString
        /// </summary>
        public string ConnectionString
        {
            get { return (string)GetValue(ConnectionStringProperty); }
            set { SetValue(ConnectionStringProperty, value); }
        }

        /// <summary>
        /// Log
        /// </summary>
        public string Log
        {
            get { return (string)GetValue(LogProperty); }
            set { SetValue(LogProperty, value); }
        }

        /// <summary>
        /// ImportData
        /// </summary>
        /// <param name="p"></param>
        private void ImportData(object p)
        {

        }
    }
}
