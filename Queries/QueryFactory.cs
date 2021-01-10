using System;
using System.Collections.Generic;
using System.Text;

namespace IbDataTool.Queries
{
    /// <summary>
    /// QueryFactory
    /// </summary>
    public class QueryFactory
    {
        private static readonly object lockObject = new object();

        private static CompaniesWithoutIncomeQuery _companiesWithoutIncomeQuery;
        private static CompaniesWithoutBalanceQuery _companiesWithoutBalanceQuery;
        private static CompaniesWithoutCashQuery _companiesWithoutCashQuery;
        private static CompaniesWithExactOneIbSymbolQuery _companiesWithExactOneIbSymbolQuery;
        private static ContractsByCompanyNameQuery _contractsByCompanyName;
        private static SymbolByCompanyNameQuery _symbolByCompanyNameQuery;
        private static StocksTotalQuery _stocksTotalQuery;

        /// <summary>
        /// CompaniesWithoutIncomeQuery
        /// </summary>
        public static CompaniesWithoutIncomeQuery CompaniesWithoutIncomeQuery
        {
            get
            {
                lock (lockObject)
                {
                    if (_companiesWithoutIncomeQuery == null)
                    {
                        _companiesWithoutIncomeQuery = new CompaniesWithoutIncomeQuery();
                    }
                    return _companiesWithoutIncomeQuery;
                }
            }
        }

        /// <summary>
        /// CompaniesWithoutBalanceQuery
        /// </summary>
        public static CompaniesWithoutBalanceQuery CompaniesWithoutBalanceQuery
        {
            get
            {
                lock (lockObject)
                {
                    if (_companiesWithoutBalanceQuery == null)
                    {
                        _companiesWithoutBalanceQuery = new CompaniesWithoutBalanceQuery();
                    }
                    return _companiesWithoutBalanceQuery;
                }
            }
        }

        /// <summary>
        /// CompaniesWithoutCashQuery
        /// </summary>
        public static CompaniesWithoutCashQuery CompaniesWithoutCashQuery
        {
            get
            {
                lock (lockObject)
                {
                    if (_companiesWithoutCashQuery == null)
                    {
                        _companiesWithoutCashQuery = new CompaniesWithoutCashQuery();
                    }
                    return _companiesWithoutCashQuery;
                }
            }
        }

        /// <summary>
        /// CompaniesWithExactOneIbSymbolQuery
        /// </summary>
        public static CompaniesWithExactOneIbSymbolQuery CompaniesWithExactOneIbSymbolQuery
        {
            get
            {
                lock (lockObject)
                {
                    if (_companiesWithExactOneIbSymbolQuery == null)
                    {
                        _companiesWithExactOneIbSymbolQuery = new CompaniesWithExactOneIbSymbolQuery();
                    }
                    return _companiesWithExactOneIbSymbolQuery;
                }
            }
        }

        /// <summary>
        /// ContractsByCompanyName
        /// </summary>
        public static ContractsByCompanyNameQuery ContractsByCompanyName
        {
            get
            {
                lock (lockObject)
                {
                    if (_contractsByCompanyName == null)
                    {
                        _contractsByCompanyName = new ContractsByCompanyNameQuery();
                    }
                    return _contractsByCompanyName;
                }
            }
        }

        /// <summary>
        /// SymbolByCompanyNameQuery
        /// </summary>
        public static SymbolByCompanyNameQuery SymbolByCompanyNameQuery
        {
            get
            {
                lock (lockObject)
                {
                    if (_symbolByCompanyNameQuery == null)
                    {
                        _symbolByCompanyNameQuery = new SymbolByCompanyNameQuery();
                    }
                    return _symbolByCompanyNameQuery;
                }
            }
        }

        /// <summary>
        /// StocksTotalQuery
        /// </summary>
        public static StocksTotalQuery StocksTotalQuery
        {
            get
            {
                lock (lockObject)
                {
                    if (_stocksTotalQuery == null)
                    {
                        _stocksTotalQuery = new StocksTotalQuery();
                    }
                    return _stocksTotalQuery;
                }
            }
        }
    }
}
