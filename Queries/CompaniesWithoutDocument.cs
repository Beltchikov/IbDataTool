using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using IbDataTool.Model;

namespace IbDataTool.Queries
{
    /// <summary>
    /// CompaniesWithoutDocument
    /// </summary>
    public class CompaniesWithoutDocument : DataContext
    {
        /// <summary>
        /// Run
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<string> Run(string symbol, string date)
        {
            return (from stock in Stocks
                    join income in IncomeStatements
                    on new { a = stock.Symbol, b = date } equals new { a = income.Symbol, b = income.Date }
                    into stockAndIncomeRecords
                    from stockAndIncome in stockAndIncomeRecords.DefaultIfEmpty()
                    where stockAndIncome == null
                    select stock.Name).ToList();
        }
    }
}
