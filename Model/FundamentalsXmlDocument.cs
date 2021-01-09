using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace IbDataTool.Model
{
    public class FundamentalsXmlDocument : XmlDocument
    {
        FundamentalsXmlDocument(){}
        
        public FundamentalsXmlDocument(string xmlAsString)
        {
            base.LoadXml(xmlAsString);
        }

        public double NetIncome()
        {
            // /ReportFinancialStatements[@Major="1"]/FinancialStatements/AnnualPeriods/FiscalPeriod[1]/Statement[1]//lineItem[19]/text()
            
            //string xPath = "/ReportFinancialStatements[@Major='1']/FinancialStatements/AnnualPeriods";
            //string xPath = "/ReportFinancialStatements[@Major='1']/FinancialStatements/AnnualPeriods/FiscalPeriod[@Type='Annual']";
            string xPath = "/ReportFinancialStatements[@Major='1']/FinancialStatements/AnnualPeriods/FiscalPeriod[@Type='Annual' and @EndDate='2019-12-31' and @FiscalYear='2019']";
            var annualPeriods = DocumentElement.SelectNodes(xPath);
            

            //DocumentElement.SelectNodes();
            //DocumentElement.SelectSingleNode()

            // TODO
            return 0;
        }


    }
}
