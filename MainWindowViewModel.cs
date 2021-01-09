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
using IbDataTool.Queries;

namespace IbDataTool
{
    /// <summary>
    /// MainWindowViewModel
    /// </summary>
    public class MainWindowViewModel : DependencyObject
    {
        public static readonly DependencyProperty PortIbProperty;
        public static readonly DependencyProperty ConnectionStringProperty;
        public static readonly DependencyProperty LogSymbolsProperty;
        public static readonly DependencyProperty LogFundamentalsProperty;
        public static readonly DependencyProperty CompaniesProperty;
        public static readonly DependencyProperty SymbolsProperty;
        public static readonly DependencyProperty ExchangesProperty;
        public static readonly DependencyProperty ExchangeSelectedProperty;
        public static readonly DependencyProperty BackgroundLogProperty;
        public static readonly DependencyProperty DateProperty;

        public RelayCommand CommandImportFundamentals { get; set; }
        public RelayCommand CommandImportContracts { get; set; }

        static MainWindowViewModel()
        {
            PortIbProperty = DependencyProperty.Register("PortIb", typeof(int), typeof(MainWindowViewModel), new PropertyMetadata(0));
            ConnectionStringProperty = DependencyProperty.Register("ConnectionString", typeof(string), typeof(MainWindowViewModel), new PropertyMetadata(string.Empty));
            LogSymbolsProperty = DependencyProperty.Register("LogSymbols", typeof(ObservableCollection<string>), typeof(MainWindowViewModel), new PropertyMetadata(new ObservableCollection<string>()));
            LogFundamentalsProperty = DependencyProperty.Register("LogFundamentals", typeof(ObservableCollection<string>), typeof(MainWindowViewModel), new PropertyMetadata(new ObservableCollection<string>()));
            CompaniesProperty = DependencyProperty.Register("Companies", typeof(string), typeof(MainWindowViewModel), new PropertyMetadata(string.Empty));
            SymbolsProperty = DependencyProperty.Register("Symbols", typeof(string), typeof(MainWindowViewModel), new PropertyMetadata(string.Empty));
            ExchangesProperty = DependencyProperty.Register("Exchanges", typeof(List<string>), typeof(MainWindowViewModel), new PropertyMetadata(new List<string>()));
            ExchangeSelectedProperty = DependencyProperty.Register("ExchangeSelected", typeof(string), typeof(MainWindowViewModel), new PropertyMetadata(string.Empty));
            BackgroundLogProperty = DependencyProperty.Register("BackgroundLog", typeof(Brush), typeof(MainWindowViewModel), new PropertyMetadata(default(Brush)));
            DateProperty = DependencyProperty.Register("Date", typeof(string), typeof(MainWindowViewModel), new PropertyMetadata(string.Empty));
        }

        public MainWindowViewModel()
        {
            PortIb = Convert.ToInt32(Configuration.Instance["PortIb"]);
            ConnectionString = Configuration.Instance["ConnectionString"];
            LogSymbols.Add("Willkommen! Enjoy the day (-:");
            BackgroundLog = Brushes.White;
            Date = "2019-12-31";

            InitExchangeCombobox();

            CommandImportFundamentals = new RelayCommand(async (p) => await ImportFundamentalsAsync(p));
            CommandImportContracts = new RelayCommand(async (p) => await ImportContractsAsync(p));

            IbClient.Instance.NextValidId += NextValidIdHandler;
            IbClient.Instance.ConnectionClosed += ConnectionClosedHandler;
            IbClient.Instance.SymbolSamples += SymbolSamplesHandler;
            IbClient.Instance.FundamentalData += FundamentalDataHandler;
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
        /// LogSymbols
        /// </summary>
        public ObservableCollection<string> LogSymbols
        {
            get { return (ObservableCollection<string>)GetValue(LogSymbolsProperty); }
            set { SetValue(LogSymbolsProperty, value); }
        }

        /// <summary>
        /// LogFundamentals
        /// </summary>
        public ObservableCollection<string> LogFundamentals
        {
            get { return (ObservableCollection<string>)GetValue(LogFundamentalsProperty); }
            set { SetValue(LogFundamentalsProperty, value); }
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
        /// Date
        /// </summary>
        public string Date
        {
            get { return (string)GetValue(DateProperty); }
            set { SetValue(DateProperty, value); }
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
        /// ConnectedToIb
        /// </summary>
        public bool ConnectedToIb { get; set; }


        /// <summary>
        /// ImportFundamentals
        /// </summary>
        /// <param name="p"></param>
        private async Task ImportFundamentalsAsync(object p)
        {
            var contractsToProcess = ContractsForIbFundamentalsQueries();
            if (!contractsToProcess.Any())
            {
                LogFundamentals.Add("No companies to process.");
                return;
            }

            LogSymbols.Clear();
            BackgroundLog = Brushes.Gray;
            await Task.Run(() =>
            {
                int portIb = 0;
                string host = string.Empty;
                int delay = 0;
                Dispatcher.Invoke(() =>
                {
                    portIb = PortIb;
                    host = Configuration.Instance["Localhost"];
                    delay = Convert.ToInt32(Configuration.Instance["DelayFundamentals"]);
                });

                IbClient.Instance.Connect(host, portIb, 1);

                // TODO ATTENTION Take(2)
                //foreach (var contract in contractsToProcess)
                foreach (var contract in contractsToProcess.Take(2))
                {
                    CurrentCompany = contract.Company;
                    IbClient.Instance.RequestFundamentals(contract);
                    Thread.Sleep(delay);
                }
            });

            IbClient.Instance.Disonnect();
        }

        /// <summary>
        /// ContractsForIbFundamentalsQueries
        /// </summary>
        /// <returns></returns>
        List<Contract> ContractsForIbFundamentalsQueries()
        {
            var companiesWithoutIncome = QueryFactory.CompaniesWithoutIncomeQuery.Run(Date);
            var companiesWithoutBalance = QueryFactory.CompaniesWithoutBalanceQuery.Run(Date);
            var companiesWithoutCash = QueryFactory.CompaniesWithoutCashQuery.Run(Date);

            var companiesWithoutDocuments = companiesWithoutIncome.Union(companiesWithoutBalance).Union(companiesWithoutCash);
            companiesWithoutDocuments = companiesWithoutDocuments.Where(c => !string.IsNullOrWhiteSpace(c)).ToList();

            var companiesWithExactOneIbSymbol = QueryFactory.CompaniesWithExactOneIbSymbolQuery.Run();
            var companiesToProcess = companiesWithoutDocuments.Intersect(companiesWithExactOneIbSymbol).ToList();
            var contractsToProcess = QueryFactory.ContractsByCompanyName.Run(companiesToProcess).ToList();

            return contractsToProcess;
        }

        /// <summary>
        /// ImportContracts
        /// </summary>
        /// <param name="p"></param>
        private async Task ImportContractsAsync(object p)
        {
            if (String.IsNullOrWhiteSpace(ExchangeSelected))
            {
                LogSymbols.Add($"ERROR! Exchange must be selected.");
                return;
            }

            LogSymbols.Clear();
            BackgroundLog = Brushes.Gray;
            await Task.Run(() =>
            {
                try
                {
                    int portIb = 0;
                    string host = string.Empty;
                    int delay = 0;
                    Dispatcher.Invoke(() =>
                    {
                        portIb = PortIb;
                        host = Configuration.Instance["Localhost"];
                        delay = Convert.ToInt32(Configuration.Instance["DelayMathingSymbols"]);
                    });

                    IbClient.Instance.Connect(host, portIb, 1);

                    string[] companiesArray = null;
                    Dispatcher.Invoke(() =>
                    {
                        companiesArray = Companies.Split("\r\n").Select(e => e.Trim()).Distinct().ToArray();
                        CompaniesList = companiesArray.ToList();
                        SymbolProcessed = new List<string>();
                        CompaniesProcessed = new List<string>();
                    });

                    foreach (var company in companiesArray)
                    {
                        CurrentCompany = company;
                        IbClient.Instance.LookForSymbols(CurrentCompany);
                        Thread.Sleep(delay);
                    }
                }
                catch (Exception exception)
                {
                    Dispatcher.Invoke(() => { LogSymbols.Add(exception.ToString()); });
                }
            });

            if (ConnectedToIb)
            {
                LogSymbols.Add($"OK! Import completed.");
                DataContext.Instance.SaveChanges();
                LogSymbols.Add("OK! All contracts saved in database.");
                IbClient.Instance.Disonnect();
            }
            else
            {
                LogSymbols.Add($"ERROR! Error while connection to IB server.");
            }

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
            var message = string.Empty;

            if (obj.IsConnected)
            {
                ConnectedToIb = true;
                message = "OK! Connected to IB server.";
            }
            else
            {
                ConnectedToIb = false;
                message = "ERROR! error connecting to IB server.";
            }

            LogSymbols.Add(message);
        }

        /// <summary>
        /// ConnectionClosedHandler
        /// </summary>
        private void ConnectionClosedHandler()
        {
            LogSymbols.Add($"Connection to IB server closed.");
        }

        /// <summary>
        /// SymbolSamplesHandler
        /// </summary>
        /// <param name="obj"></param>
        private void SymbolSamplesHandler(IBSampleApp.messages.SymbolSamplesMessage obj)
        {
            LogSymbols.Add($"{obj.ContractDescriptions.Count()} symbols found for company {CurrentCompany}. {CompaniesList.Count()} companies more.");
            CompaniesList.Remove(CurrentCompany);
            var contracts = SymbolManager.FilterSymbols(CurrentCompany, obj, ExchangeSelected);
            LogSymbols.Add($"{contracts.Count()} symbols filtered out for company {CurrentCompany}");

            try
            {
                if (!contracts.Any())
                {
                    ProcessNotResolved();
                    ProcessDatabaseBatch();
                    return;
                }

                ProcessResolved(contracts);
                ProcessDatabaseBatch();
            }
            catch (Exception exception)
            {
                LogSymbols.Add(exception.ToString());
            }
        }

        /// <summary>
        /// ProcessResolved
        /// </summary>
        /// <param name="contracts"></param>
        private void ProcessResolved(IList<Contract> contracts)
        {
            for (int i = 0; i < contracts.Count(); i++)
            {
                Contract contract = contracts[i];
                if (!SymbolProcessed.Any(s => s.ToUpper() == contract.Symbol.ToUpper()))
                {
                    if (DataContext.Instance.Contracts.Any(c => c.Symbol == contract.Symbol))
                    {
                        LogSymbols.Add($"Symbol {contract.Symbol} exists already in database table Contracts.");
                        continue;
                    }
                    DataContext.Instance.Contracts.Add(contract);
                    SymbolProcessed.Add(contract.Symbol);
                }
            }

            CompaniesProcessed.Add(CurrentCompany);
        }

        /// <summary>
        /// ProcessNotResolved
        /// </summary>
        private void ProcessNotResolved()
        {
            if (!CompaniesProcessed.Any(s => s.ToUpper() == CurrentCompany.ToUpper()))
            {
                if (DataContext.Instance.NotResolved.Any(n => n.Company == CurrentCompany))
                {
                    LogSymbols.Add($"Company {CurrentCompany} exists already in database table NotResolved.");
                    return;
                }

                DataContext.Instance.NotResolved.Add(new NotResolved { Company = CurrentCompany });
            }

            CompaniesProcessed.Add(CurrentCompany);
        }

        /// <summary>
        /// ProcessDatabaseBatch
        /// </summary>
        private void ProcessDatabaseBatch()
        {
            if (CompaniesProcessed.Count() > 0 && CompaniesProcessed.Count() % Convert.ToInt32(Configuration.Instance["BatchSizeDatabase"]) == 0
                || CompaniesList.Count() == 0)
            {
                DataContext.Instance.SaveChanges();
                LogSymbols.Add("OK! Current batch saved in database.");
            }
        }

        /// <summary>
        /// FundamentalDataHandler
        /// </summary>
        /// <param name="obj"></param>
        private void FundamentalDataHandler(IBSampleApp.messages.FundamentalsMessage obj)
        {
            LogFundamentals.Add($"Processing {CurrentCompany} ...");
            var xmlDocument = XmlFactory.Instance.CreateXml(obj);
        }

    }
}
