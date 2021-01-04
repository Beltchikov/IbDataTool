using System;
using System.Collections.Generic;
using System.Text;

namespace IbDataTool.Model
{
    /// <summary>
    /// EssentialData
    /// </summary>
    public class EssentialData
    {
        public double Revenue { get; set; }
        public double NetIncome { get; set; }
        public double OperatingIncome { get; set; }
        public double Epsdiluted { get; set; }
        public double TotalStockholdersEquity { get; set; }
        public double NetIncomeFromCashStatement { get; set; }
        public double OperatingCashFlow { get; set; }
        public double InvestmentsInPropertyPlantAndEquipment { get; set; }
    }
}
