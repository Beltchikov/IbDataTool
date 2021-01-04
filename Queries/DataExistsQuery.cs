using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using IbDataTool.Model;

namespace IbDataTool.Queries
{
    /// <summary>
    /// DataExistsQuery
    /// </summary>
    public class DataExistsQuery : DataContext
    {
        /// <summary>
        /// Run
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<EssentialData> Run(string symbol, string date)
        {
            return (from income in IncomeStatements
                                     join balance in BalanceSheets
                                     on new { a = income.Symbol, b = income.Date } equals new { a = balance.Symbol, b = balance.Date }
                                     join cash in CashFlowStatements
                                     on new { a = income.Symbol, b = income.Date } equals new { a = cash.Symbol, b = cash.Date }
                                     where income.Symbol == symbol && income.Date == date
                                    select new EssentialData
                                    {
                                        Revenue = income.Revenue,
                                        NetIncome = income.NetIncome,
                                        OperatingIncome = income.OperatingIncome,
                                        Epsdiluted = income.Epsdiluted,
                                        TotalStockholdersEquity = balance.TotalStockholdersEquity,
                                        NetIncomeFromCashStatement = cash.NetIncome,
                                        OperatingCashFlow = cash.OperatingCashFlow,
                                        InvestmentsInPropertyPlantAndEquipment = cash.InvestmentsInPropertyPlantAndEquipment
                                    })
                                  .ToList();
        }
    }
}
