using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using IbDataTool.Model;

namespace IbDataTool.Queries
{
    /// <summary>
    /// CompaniesWithExactOneIbSymbolQuery
    /// </summary>
    public class CompaniesWithExactOneIbSymbolQuery : DataContext
    {
        
        /// <summary>
        /// Run
        /// </summary>
        /// <returns></returns>
        public List<string> Run()
        {
            return (from contract in Contracts
                    group contract by contract.Company 
                    into grouped
                    where grouped.Count() == 1
                    select grouped.Key
                    ).ToList();
        }
    }
}
