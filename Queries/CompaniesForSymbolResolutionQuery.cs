using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using IbDataTool.Model;
using System.Windows;

namespace IbDataTool.Queries
{
    public class CompaniesForSymbolResolutionQuery : DataContext
    {
        public List<string> Run(List<string> inputCompaniesList, List<string> exchangesFmpSelected)
        {
            return (from stock in Stocks
                    where inputCompaniesList.Contains(stock.Name) && exchangesFmpSelected.Contains(stock.Exchange)
                    select stock.Name
                    ).ToList();
        }
    }
}