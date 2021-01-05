using FmpDataTool.Ib;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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
        public static readonly DependencyProperty CompaniesProperty;

        public RelayCommand CommandImportData { get; set; }

        static MainWindowViewModel()
        {
            PortIbProperty = DependencyProperty.Register("PortIb", typeof(int), typeof(MainWindowViewModel), new PropertyMetadata(0));
            ConnectionStringProperty = DependencyProperty.Register("ConnectionString", typeof(string), typeof(MainWindowViewModel), new PropertyMetadata(string.Empty));
            LogProperty = DependencyProperty.Register("Log", typeof(string), typeof(MainWindowViewModel), new PropertyMetadata(string.Empty));
            CompaniesProperty = DependencyProperty.Register("Companies", typeof(string), typeof(MainWindowViewModel), new PropertyMetadata(string.Empty));
        }

        public MainWindowViewModel()
        {
            PortIb = 4001;
            ConnectionString = Configuration.Instance["ConnectionString"];
            Log = "Willkommen!";

            // TODO
            Companies = "Xtract Resources PLC\r\nYellow Cake PLC\r\nYew Grove REIT PLC\r\nYourgene Health PLC\r\nYoung & Co's Brewery PLC";

            IBClient.Instance.Message += Instance_Message;
            IBClient.Instance.FundamentalData += Instance_FundamentalData;
            IBClient.Instance.SymbolSamples += Instance_SymbolSamples;

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
        /// IsLookingForSymbols
        /// </summary>
        public bool IsLookingForSymbols { get; set; }

        /// <summary>
        /// Companies
        /// </summary>
        public string Companies
        {
            get { return (string)GetValue(CompaniesProperty); }
            set { SetValue(CompaniesProperty, value); }
        }

        /// <summary>
        /// ImportData
        /// </summary>
        /// <param name="p"></param>
        private void ImportData(object p)
        {
            IBClient.Instance.Connect(Configuration.Instance["Localhost"], PortIb, 1);

            var companiesArray = Companies.Split("\r\n");
            foreach(var company in companiesArray)
            {
                //Log += $"\r\nLooking for symbol for company {company}";
                //IsLookingForSymbols = true;
                IBClient.Instance.LookForSymbols(company);
                //while (IsLookingForSymbols) { };
                //Log += $"\r\nOK! Finished looking for symbol for company {company}";

                //IBClient.Instance.RequestFundamentals("IBKR", "USD");
            }
            
            //IBClient.Instance.Disonnect();
        }

        private void Instance_FundamentalData(IBSampleApp.messages.FundamentalsMessage obj)
        {
            var xmlDocument = XmlFactory.Instance.CreateXml(obj);
        }

        private void Instance_SymbolSamples(IBSampleApp.messages.SymbolSamplesMessage obj)
        {
            Dispatcher.Invoke(() => IsLookingForSymbols = false);
        }

        private void Instance_Message(object sender, string message)
        {
            Dispatcher.Invoke(() => { Log += message; });
        }
    }
}
