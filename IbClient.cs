using IBApi;
using IBSampleApp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace IbDataTool
{
    /// <summary>
    /// IBClient
    /// </summary>
    class IbClient : IBClient
    {
        private const int FUNDAMENTALS_ID = 60000002;
        private const string SECURITY_TYPE_STOCK = "STK";
        private const string EXCHANGE_SMART = "SMART";
        private const string REPORT_TYPE_FIN_STATEMENTS = "ReportsFinStatements";

        private static IbClient _ibClient;
        private static readonly object lockObject = new object();

        IbClient(EReaderMonitorSignal signal) : base(signal)
        {
        }

        /// <summary>
        /// Instance
        /// </summary>
        public static IbClient Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (_ibClient == null)
                    {
                        _ibClient = new IbClient(new EReaderMonitorSignal());
                    }
                    return _ibClient;
                }
            }
        }

        /// <summary>
        /// ActiveReqId
        /// </summary>
        public int ActiveReqId { get; private set; }
        public bool IsConnectedIb { get; private set; }

        /// <summary>
        /// Connect
        /// </summary>
        /// <param name="host"></param>
        /// <param name="portIb"></param>
        /// <param name="clientIdIb"></param>
        public void Connect(string host, int portIb, int clientIdIb)
        {
            if (!IsConnectedIb)
            {
                try
                {
                    ClientSocket.eConnect(host, portIb, clientIdIb);
                    var signal = new EReaderMonitorSignal();
                    var reader = new EReader(ClientSocket, signal);
                    reader.Start();
                    new Thread(() =>
                    {
                        while (ClientSocket.IsConnected())
                        {
                            signal.waitForSignal();
                            reader.processMsgs();
                        }
                    })
                    { IsBackground = true }.Start();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                IsConnectedIb = false;
                ClientSocket.eDisconnect();
            }
        }

        /// <summary>
        /// Disonnect
        /// </summary>
        public void Disonnect()
        {
            try
            {
                ClientSocket.eDisconnect();
                IsConnectedIb = false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void RequestFundamentals(String symbol, string currency)
        {
            Contract contract = new Contract
            {
                SecType = SECURITY_TYPE_STOCK,
                Symbol = symbol,
                Currency = currency,
                Exchange = EXCHANGE_SMART
            };
            ClientSocket.reqFundamentalData(FUNDAMENTALS_ID, contract, REPORT_TYPE_FIN_STATEMENTS, new List<TagValue>());

        }

        public void LookForSymbols(string company)
        {
            ClientSocket.reqMatchingSymbols(++ActiveReqId, company);
        }
    }
}
