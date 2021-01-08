using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using IbDataTool.Model;

namespace IbDataTool.Queries
{
    /// <summary>
    /// Returns companies without cash flow statement sheet.
    /// </summary>
    public class CompaniesWithoutCashQuery : DataContext
    {
        
        /// <summary>
        /// Run
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<string> Run(string date)
        {
            return (from stock in Stocks
                    join cash in CashFlowStatements
                    on new { a = stock.Symbol, b = date } equals new { a = cash.Symbol, b = cash.Date }
                    into stockAndCashRecords
                    from stockAndCash in stockAndCashRecords.DefaultIfEmpty()
                    where stockAndCash == null
                    select stock.Name).ToList();
        }
    }
}
