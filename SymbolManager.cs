using IBSampleApp.messages;
using System;
using System.Collections.Generic;
using System.Text;
using IbDataTool.Model;

namespace IbDataTool
{
    /// <summary>
    /// SymbolManager
    /// </summary>
    public class SymbolManager
    {
        //private static SymbolManager _symbolManager;
        //private static readonly object lockObject = new object();

        //SymbolManager() { }

        ///// <summary>
        ///// Instance
        ///// </summary>
        //public static SymbolManager Instance
        //{
        //    get
        //    {
        //        lock (lockObject)
        //        {
        //            if (_symbolManager == null)
        //            {
        //                _symbolManager = new SymbolManager();
        //            }
        //            return _symbolManager;
        //        }
        //    }
        //}

        /// <summary>
        /// FilterSymbols
        /// </summary>
        /// <param name="company">
        /// </param>
        /// <param name="symbolSamplesMessage">
        /// </param>
        /// <param name="exchangeAndCurrency">
        /// Symbol and currency symbol divided by whitespace.
        /// </param>
        /// <returns></returns>
        public static List<Contract> FilterSymbols(string company, SymbolSamplesMessage symbolSamplesMessage, string exchangeAndCurrency)
        {
            List<Contract> resultArray = new List<Contract>();

            if(string.IsNullOrWhiteSpace(exchangeAndCurrency))
            {
                return resultArray;
            }

            string[] exchangeAndCurrencyArray = exchangeAndCurrency.Split(" ");
            string exchange = exchangeAndCurrencyArray[0];
            string currency = exchangeAndCurrencyArray[1];

            foreach(var contractDescription in symbolSamplesMessage.ContractDescriptions)
            {
                if(contractDescription.Contract.PrimaryExch == exchange && contractDescription.Contract.Currency == currency)
                {
                    resultArray.Add(new Contract { 
                        Company = company,
                        SecType = contractDescription.Contract.SecType,
                        Symbol = contractDescription.Contract.Symbol,
                        Currency  = contractDescription.Contract.Currency,
                        Exchange = contractDescription.Contract.PrimaryExch,
                    });
                }
            }

            return resultArray;
        }
    }
}
