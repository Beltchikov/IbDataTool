using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        public static readonly DependencyProperty SymbolsProperty;
        public static readonly DependencyProperty ExchangesProperty;
        public static readonly DependencyProperty ExchangeSelectedProperty;

        public RelayCommand CommandImportData { get; set; }
        public RelayCommand CommandImportContracts { get; set; }

        static MainWindowViewModel()
        {
            PortIbProperty = DependencyProperty.Register("PortIb", typeof(int), typeof(MainWindowViewModel), new PropertyMetadata(0));
            ConnectionStringProperty = DependencyProperty.Register("ConnectionString", typeof(string), typeof(MainWindowViewModel), new PropertyMetadata(string.Empty));
            LogProperty = DependencyProperty.Register("Log", typeof(string), typeof(MainWindowViewModel), new PropertyMetadata(string.Empty));
            CompaniesProperty = DependencyProperty.Register("Companies", typeof(string), typeof(MainWindowViewModel), new PropertyMetadata(string.Empty));
            SymbolsProperty = DependencyProperty.Register("Symbols", typeof(string), typeof(MainWindowViewModel), new PropertyMetadata(string.Empty));
            ExchangesProperty = DependencyProperty.Register("Exchanges", typeof(List<string>), typeof(MainWindowViewModel), new PropertyMetadata(new List<string>()));
            ExchangeSelectedProperty = DependencyProperty.Register("ExchangeSelected", typeof(string), typeof(MainWindowViewModel), new PropertyMetadata(string.Empty));
        }

        public MainWindowViewModel()
        {
            PortIb = Convert.ToInt32(Configuration.Instance["PortIb"]);
            ConnectionString = Configuration.Instance["ConnectionString"];
            Log = "Willkommen!";
            InitExchangeCombobox();

            // TODO
            Companies = "Xtract Resources PLC\r\nYellow Cake PLC\r\nYew Grove REIT PLC\r\nYourgene Health PLC\r\nYoung & Co's Brewery PLC";

            IbClient.Instance.NextValidId += NextValidIdHandler;
            //IbClient.Instance.FundamentalData += Instance_FundamentalData;
            IbClient.Instance.SymbolSamples += SymbolSamplesHandler;

            CommandImportData = new RelayCommand((p) => ImportData(p));
            CommandImportContracts = new RelayCommand((p) => ImportContracts(p));

        }

        /// <summary>
        /// InitExchangeCombobox
        /// </summary>
        private void InitExchangeCombobox()
        {
            var exchanges = Configuration.Instance["ExchangesNorthAmerica"].Split(",").ToList();
            exchanges.AddRange(Configuration.Instance["ExchangesAsia"].Split(",").ToList());
            exchanges.AddRange(Configuration.Instance["ExchangesEurope"].Split(",").ToList());

            Exchanges = exchanges.Select(e => e.Trim()).ToList();
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
        /// Symbols
        /// </summary>
        public string Symbols
        {
            get { return (string)GetValue(SymbolsProperty); }
            set { SetValue(SymbolsProperty, value); }
        }

        /// <summary>
        /// Exchanges
        /// </summary>
        public List<string> Exchanges
        {
            get { return (List<string>)GetValue(ExchangesProperty); }
            set { SetValue(ExchangesProperty, value); }
        }

        /// <summary>
        /// ExchangeSelected
        /// </summary>
        public string ExchangeSelected
        {
            get { return (string)GetValue(ExchangeSelectedProperty); }
            set { SetValue(ExchangeSelectedProperty, value); }
        }

        public string CurrentCompany { get; private set; }

        /// <summary>
        /// ImportData
        /// </summary>
        /// <param name="p"></param>
        private void ImportData(object p)
        {
            IbClient.Instance.Connect(Configuration.Instance["Localhost"], PortIb, 1);

            var companiesArray = Companies.Split("\r\n");
            foreach (var company in companiesArray)
            {
                //Log += $"\r\nLooking for symbol for company {company}";
                //IsLookingForSymbols = true;
                IbClient.Instance.LookForSymbols(company);
                //while (IsLookingForSymbols) { };
                //Log += $"\r\nOK! Finished looking for symbol for company {company}";

                //IBClient.Instance.RequestFundamentals("IBKR", "USD");
            }

            //IBClient.Instance.Disonnect();
        }

        /// <summary>
        /// ImportContracts
        /// </summary>
        /// <param name="p"></param>
        private void ImportContracts(object p)
        {
            if (String.IsNullOrWhiteSpace(ExchangeSelected))
            {
                Log += $"\r\nERROR! Exchange must be selected.";
                return;
            }

            IbClient.Instance.Connect(Configuration.Instance["Localhost"], PortIb, 1);

            var companiesArray = Companies.Split("\r\n");
            //Log += $"\r\nStarting symbol import for {companiesArray.Count()} companies...";
            foreach (var company in companiesArray)
            {
                CurrentCompany = company;
                IbClient.Instance.LookForSymbols(CurrentCompany);
                Thread.Sleep(1100);
            }

            //Log += $"\r\n OK! Import completed.";
            //IBClient.Instance.Disonnect();
        }

        /// <summary>
        /// NextValidIdHandler
        /// </summary>
        /// <param name="obj"></param>
        private void NextValidIdHandler(IBSampleApp.messages.ConnectionStatusMessage obj)
        {
            var message = obj.IsConnected
                ? "\r\nOK! Connected to IB server."
                : "\r\nERROR! error connecting to IB server.";
            Log += message;
        }

        private void Instance_FundamentalData(IBSampleApp.messages.FundamentalsMessage obj)
        {
            var xmlDocument = XmlFactory.Instance.CreateXml(obj);
        }

        private void SymbolSamplesHandler(IBSampleApp.messages.SymbolSamplesMessage obj)
        {
            Log += $"\r\n{obj.ContractDescriptions.Count()} symbols found for company {CurrentCompany}";

            // TODO
            var contracts = SymbolManager.FilterSymbols(CurrentCompany, obj, ExchangeSelected);

        }
    }
}
