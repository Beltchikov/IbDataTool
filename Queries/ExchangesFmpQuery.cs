using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using IbDataTool.Model;

namespace IbDataTool.Queries
{
    /// <summary>
    /// ExchangesFmpQuery
    /// </summary>
    public class ExchangesFmpQuery : DataContext
    {
        public List<string> Run()
        {
            return (from stocks in Stocks
                    select stocks.Exchange
                    ).Distinct().ToList();
        }
    }
}