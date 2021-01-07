using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using IbDataTool.Model;

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
        public static readonly DependencyProperty BackgroundLogProperty;

        public RelayCommand CommandImportData { get; set; }
        public RelayCommand CommandImportContracts { get; set; }

        static MainWindowViewModel()
        {
            PortIbProperty = DependencyProperty.Register("PortIb", typeof(int), typeof(MainWindowViewModel), new PropertyMetadata(0));
            ConnectionStringProperty = DependencyProperty.Register("ConnectionString", typeof(string), typeof(MainWindowViewModel), new PropertyMetadata(string.Empty));
            LogProperty = DependencyProperty.Register("Log", typeof(ObservableCollection<string>), typeof(MainWindowViewModel), new PropertyMetadata(new ObservableCollection<string>()));
            CompaniesProperty = DependencyProperty.Register("Companies", typeof(string), typeof(MainWindowViewModel), new PropertyMetadata(string.Empty));
            SymbolsProperty = DependencyProperty.Register("Symbols", typeof(string), typeof(MainWindowViewModel), new PropertyMetadata(string.Empty));
            ExchangesProperty = DependencyProperty.Register("Exchanges", typeof(List<string>), typeof(MainWindowViewModel), new PropertyMetadata(new List<string>()));
            ExchangeSelectedProperty = DependencyProperty.Register("ExchangeSelected", typeof(string), typeof(MainWindowViewModel), new PropertyMetadata(string.Empty));
            BackgroundLogProperty = DependencyProperty.Register("BackgroundLog", typeof(Brush), typeof(MainWindowViewModel), new PropertyMetadata(default(Brush)));

        }

        public MainWindowViewModel()
        {
            PortIb = Convert.ToInt32(Configuration.Instance["PortIb"]);
            ConnectionString = Configuration.Instance["ConnectionString"];
            Log.Add("Willkommen");
            BackgroundLog = Brushes.White;
            InitExchangeCombobox();

            // TODO
            Companies = "Xtract Resources PLC\r\nYellow Cake PLC\r\nYew Grove REIT PLC\r\nYourgene Health PLC\r\nYoung & Co's Brewery PLC";

            CommandImportData = new RelayCommand((p) => ImportData(p));
            CommandImportContracts = new RelayCommand(async (p) => await ImportContractsAsync(p));

            IbClient.Instance.NextValidId += NextValidIdHandler;
            IbClient.Instance.ConnectionClosed += ConnectionClosedHandler;
            IbClient.Instance.SymbolSamples += SymbolSamplesHandler;
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
        public ObservableCollection<string> Log
        {
            get { return (ObservableCollection<string>)GetValue(LogProperty); }
            set { SetValue(LogProperty, value); }
        }

        /// <summary>
        /// RequestPending
        /// </summary>
        public bool RequestPending { get; set; }

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

        /// <summary>
        /// BackgroundLog
        /// </summary>
        public Brush BackgroundLog
        {
            get { return (Brush)GetValue(BackgroundLogProperty); }
            set { SetValue(BackgroundLogProperty, value); }
        }

        /// <summary>
        /// CompaniesList
        /// </summary>
        public List<string> CompaniesList { get; set; }

        /// <summary>
        /// CurrentCompany
        /// </summary>
        public string CurrentCompany { get; private set; }

        /// <summary>
        /// CompaniesProcessed
        /// </summary>
        public List<string> CompaniesProcessed { get; set; }

        /// <summary>
        /// SymbolProcessed
        /// </summary>
        public List<string> SymbolProcessed { get; set; }


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
        private async Task ImportContractsAsync(object p)
        {
            if (String.IsNullOrWhiteSpace(ExchangeSelected))
            {
                Log.Add($"ERROR! Exchange must be selected.");
                return;
            }

            BackgroundLog = Brushes.Gray;
            await Task.Run(() =>
            {
                int portIb = 0;
                string host = string.Empty;
                Dispatcher.Invoke(() =>
                {
                    portIb = PortIb;
                    host = Configuration.Instance["Localhost"];
                });

                IbClient.Instance.Connect(host, portIb, 1);

                int delay = 0;
                string[] companiesArray = null;
                Dispatcher.Invoke(() =>
                {
                    companiesArray = Companies.Split("\r\n");
                    CompaniesList = companiesArray.ToList();
                    delay = Convert.ToInt32(Configuration.Instance["DelayMathingSymbols"]);
                    SymbolProcessed = new List<string>();
                    CompaniesProcessed = new List<string>();
                });

                foreach (var company in companiesArray)
                {
                    CurrentCompany = company;
                    IbClient.Instance.LookForSymbols(CurrentCompany);
                    Thread.Sleep(delay);
                }
            });

            Log.Add($"OK! Import completed.");
            DataContext.Instance.SaveChanges();
            Log.Add("OK! All contracts saved in database.");
            IbClient.Instance.Disonnect();
        }

        /// <summary>
        /// EnsureEmptyDatabase
        /// </summary>
        /// <returns></returns>
        private bool EnsureEmptyDatabase()
        {
            if (DataContext.Instance.Contracts.Any())
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Database table 'Contracts' has already data. Do you want to overwrite it?", "Warning! Data exists!", MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    DataContext.Instance.Contracts.RemoveRange(DataContext.Instance.Contracts);
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// NextValidIdHandler
        /// </summary>
        /// <param name="obj"></param>
        private void NextValidIdHandler(IBSampleApp.messages.ConnectionStatusMessage obj)
        {
            BackgroundLog = Brushes.White;
            var message = obj.IsConnected
                ? "OK! Connected to IB server."
                : "ERROR! error connecting to IB server.";
            Log.Add(message);
        }

        /// <summary>
        /// ConnectionClosedHandler
        /// </summary>
        private void ConnectionClosedHandler()
        {
            Log.Add($"Connection to IB server closed.");
        }

        /// <summary>
        /// SymbolSamplesHandler
        /// </summary>
        /// <param name="obj"></param>
        private void SymbolSamplesHandler(IBSampleApp.messages.SymbolSamplesMessage obj)
        {
            Log.Add($"{obj.ContractDescriptions.Count()} symbols found for company {CurrentCompany}. {CompaniesList.Count()} companies more.");
            CompaniesList.Remove(CurrentCompany);
            var contracts = SymbolManager.FilterSymbols(CurrentCompany, obj, ExchangeSelected);
            Log.Add($"{contracts.Count()} symbols filtered out for company {CurrentCompany}");

            try
            {
                if (!contracts.Any())
                {
                    if (!CompaniesProcessed.Any(s => s == CurrentCompany))
                    {
                        DataContext.Instance.NotResolved.Add(new NotResolved { Company = CurrentCompany });
                    }

                    CompaniesProcessed.Add(CurrentCompany);
                    return;
                }

                for (int i = 0; i < contracts.Count(); i++)
                {
                    Contract contract = contracts[i];
                    if (!SymbolProcessed.Any(s => s == contract.Symbol))
                    {
                        DataContext.Instance.Contracts.Add(contract);
                        SymbolProcessed.Add(contract.Symbol);
                    }
                }

                CompaniesProcessed.Add(CurrentCompany);
                if (CompaniesProcessed.Count() > 0 && CompaniesProcessed.Count() % Convert.ToInt32(Configuration.Instance["BatchSizeDatabase"]) == 0)
                {
                    DataContext.Instance.SaveChanges();
                    Log.Add("OK! Current batch saved in database.");
                }
            }
            catch (Exception exception)
            {
                Log.Add($"" + exception.ToString());
            }
        }

        private void Instance_FundamentalData(IBSampleApp.messages.FundamentalsMessage obj)
        {
            var xmlDocument = XmlFactory.Instance.CreateXml(obj);
        }

    }
}
