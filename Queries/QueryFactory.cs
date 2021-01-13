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
        private static CompaniesWoDocumentsQuery _companiesWoDocumentsQuery;
        private static CompaniesWoDocumentsAndIbSymbolQuery _companiesWoDocumentsAndIbSymbolQuery;
        private static CompaniesWoDocumentsIbSymbolNotResolvedNotUniqueQuery _companiesWoDocumentsIbSymbolNotResolvedNotUniqueQuery;
        private static ExchangesFmpQuery _exchangesFmpQuery;
        private static CompaniesForSymbolResolutionQuery _companiesForSymbolResolutionQuery;
        private static CompaniesWoDocumentsButWithIbSymbolQuery _companiesWoDocumentsButWithIbSymbolQuery;

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

        /// <summary>
        /// Companies without all set of financial documents
        /// </summary>
        public static CompaniesWoDocumentsQuery CompaniesWoDocumentsQuery
        {
            get
            {
                lock (lockObject)
                {
                    if (_companiesWoDocumentsQuery == null)
                    {
                        _companiesWoDocumentsQuery = new CompaniesWoDocumentsQuery();
                    }
                    return _companiesWoDocumentsQuery;
                }
            }
        }

        /// <summary>
        /// Companies without all set of financial documents and without IB symbol
        /// </summary>
        public static CompaniesWoDocumentsAndIbSymbolQuery CompaniesWoDocumentsAndIbSymbolQuery
        {
            get
            {
                lock (lockObject)
                {
                    if (_companiesWoDocumentsAndIbSymbolQuery == null)
                    {
                        _companiesWoDocumentsAndIbSymbolQuery = new CompaniesWoDocumentsAndIbSymbolQuery();
                    }
                    return _companiesWoDocumentsAndIbSymbolQuery;
                }
            }
        }

        /// <summary>
        /// CompaniesWoDocumentsIbSymbolNotResolvedNotUniqueQuery
        /// </summary>
        public static CompaniesWoDocumentsIbSymbolNotResolvedNotUniqueQuery CompaniesWoDocumentsIbSymbolNotResolvedNotUniqueQuery
        {
            get
            {
                lock (lockObject)
                {
                    if (_companiesWoDocumentsIbSymbolNotResolvedNotUniqueQuery == null)
                    {
                        _companiesWoDocumentsIbSymbolNotResolvedNotUniqueQuery = new CompaniesWoDocumentsIbSymbolNotResolvedNotUniqueQuery();
                    }
                    return _companiesWoDocumentsIbSymbolNotResolvedNotUniqueQuery;
                }
            }
        }

        /// <summary>
        /// ExchangesFmpQuery
        /// </summary>
        public static ExchangesFmpQuery ExchangesFmpQuery
        {
            get
            {
                lock (lockObject)
                {
                    if (_exchangesFmpQuery == null)
                    {
                        _exchangesFmpQuery = new ExchangesFmpQuery();
                    }
                    return _exchangesFmpQuery;
                }
            }
        }

        /// <summary>
        /// CompaniesForSymbolResolutionQuery
        /// </summary>
        public static CompaniesForSymbolResolutionQuery CompaniesForSymbolResolutionQuery
        {
            get
            {
                lock (lockObject)
                {
                    if (_companiesForSymbolResolutionQuery == null)
                    {
                        _companiesForSymbolResolutionQuery = new CompaniesForSymbolResolutionQuery();
                    }
                    return _companiesForSymbolResolutionQuery;
                }
            }
        }

        /// <summary>
        /// CompaniesWoDocumentsButWithIbSymbolQuery
        /// </summary>
        public static CompaniesWoDocumentsButWithIbSymbolQuery CompaniesWoDocumentsButWithIbSymbolQuery
        {
            get
            {
                lock (lockObject)
                {
                    if (_companiesWoDocumentsButWithIbSymbolQuery == null)
                    {
                        _companiesWoDocumentsButWithIbSymbolQuery = new CompaniesWoDocumentsButWithIbSymbolQuery();
                    }
                    return _companiesWoDocumentsButWithIbSymbolQuery;
                }
            }
        }

    }
}
