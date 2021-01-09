using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using IbDataTool.Model;

namespace IbDataTool.Queries
{
    /// <summary>
    /// ContractsByCompanyName
    /// </summary>
    public class ContractsByCompanyNameQuery : DataContext
    {

        /// <summary>
        /// Run
        /// </summary>
        /// <param name="companies"></param>
        /// <returns></returns>
        public List<Contract> Run(List<string> companies)
        {
            return (from contract in Contracts
                    where companies.Contains(contract.Company)
                    select contract).ToList();
        }
    }
}
