using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using IbDataTool.Model;

namespace IbDataTool.Queries
{
    /// <summary>
    /// Returns companies without balance sheet.
    /// </summary>
    public class CompaniesWithoutBalanceQuery : DataContext
    {
        
        /// <summary>
        /// Run
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<string> Run(string date)
        {
            return (from stock in Stocks
                    join balance in BalanceSheets
                    on new { a = stock.Symbol, b = date } equals new { a = balance.Symbol, b = balance.Date }
                    into stockAndBalanceRecords
                    from stockAndBalance in stockAndBalanceRecords.DefaultIfEmpty()
                    where stockAndBalance == null
                    select stock.Name).ToList();
        }
    }
}
