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
    }
}
