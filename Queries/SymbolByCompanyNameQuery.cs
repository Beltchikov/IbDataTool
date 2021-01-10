using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using IbDataTool.Model;

namespace IbDataTool.Queries
{
    /// <summary>
    /// SymbolByCompanyNameQuery
    /// </summary>
    public class SymbolByCompanyNameQuery : DataContext
    {

        /// <summary>
        /// Run
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        public string Run(string company)
        {
            return (from stock in Stocks
                    where stock.Name == company
                    select stock.Symbol).FirstOrDefault();
        }
    }
}
