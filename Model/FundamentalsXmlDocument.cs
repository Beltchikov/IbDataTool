using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml;

namespace IbDataTool.Model
{
    /// <summary>
    /// FundamentalsXmlDocument
    /// </summary>
    public class FundamentalsXmlDocument : XmlDocument
    {
        private string _date;
        private CultureInfo _culture = new CultureInfo("en-US");


        FundamentalsXmlDocument() { }

        /// <summary>
        /// FundamentalsXmlDocument
        /// </summary>
        /// <param name="xmlAsString"></param>
        /// <param name="date"></param>
        public FundamentalsXmlDocument(string xmlAsString, string date)
        {
            base.LoadXml(xmlAsString);
            _date = date;
        }

        /// <summary>
        /// NetIncome
        /// </summary>
        /// <returns></returns>
        public double NetIncome
        {
            get
            {
                string xPath = @"/ReportFinancialStatements[@Major='1']/FinancialStatements/AnnualPeriods/
                            FiscalPeriod[@Type='Annual' and @EndDate='@@date' and @FiscalYear='@@year']/
                            Statement[@Type='INC']//lineItem[@coaCode='NINC']";
                xPath = xPath.Replace("@@date", _date);
                xPath = xPath.Replace("@@year", Convert.ToString(_date[..4]));

                var lineItems = DocumentElement.SelectNodes(xPath);
                if (lineItems.Count != 1)
                {
                    return 0d;
                }

                try
                {
                    return Convert.ToDouble(lineItems[0].InnerText, _culture);
                }
                catch (Exception)
                {

                    return 0d;
                }
            }
        }

        /// <summary>
        /// Revenue
        /// </summary>
        /// <returns></returns>
        public double Revenue
        {
            get
            {
                string xPath = @"/ReportFinancialStatements[@Major='1']/FinancialStatements/AnnualPeriods/
                            FiscalPeriod[@Type='Annual' and @EndDate='@@date' and @FiscalYear='@@year']/
                            Statement[@Type='INC']//lineItem[@coaCode='SREV']";
                xPath = xPath.Replace("@@date", _date);
                xPath = xPath.Replace("@@year", Convert.ToString(_date[..4]));

                var lineItems = DocumentElement.SelectNodes(xPath);
                if (lineItems.Count != 1)
                {
                    return 0d;
                }

                try
                {
                    return Convert.ToDouble(lineItems[0].InnerText, _culture);
                }
                catch (Exception)
                {

                    return 0d;
                }
            }
        }

        /// <summary>
        /// OperatingIncome
        /// </summary>
        /// <returns></returns>
        public double OperatingIncome
        {
            get
            {
                string xPath = @"/ReportFinancialStatements[@Major='1']/FinancialStatements/AnnualPeriods/
                            FiscalPeriod[@Type='Annual' and @EndDate='@@date' and @FiscalYear='@@year']/
                            Statement[@Type='INC']//lineItem[@coaCode='SOPI']";
                xPath = xPath.Replace("@@date", _date);
                xPath = xPath.Replace("@@year", Convert.ToString(_date[..4]));

                var lineItems = DocumentElement.SelectNodes(xPath);
                if (lineItems.Count != 1)
                {
                    return 0d;
                }

                try
                {
                    return Convert.ToDouble(lineItems[0].InnerText, _culture);
                }
                catch (Exception)
                {

                    return 0d;
                }
            }
        }

        /// <summary>
        /// Eps
        /// </summary>
        /// <returns></returns>
        public double Eps
        {
            get
            {
                string xPath = @"/ReportFinancialStatements[@Major='1']/FinancialStatements/AnnualPeriods/
                            FiscalPeriod[@Type='Annual' and @EndDate='@@date' and @FiscalYear='@@year']/
                            Statement[@Type='INC']//lineItem[@coaCode='VDES']";
                xPath = xPath.Replace("@@date", _date);
                xPath = xPath.Replace("@@year", Convert.ToString(_date[..4]));

                var lineItems = DocumentElement.SelectNodes(xPath);
                if (lineItems.Count != 1)
                {
                    return 0d;
                }

                try
                {
                    return Convert.ToDouble(lineItems[0].InnerText, _culture);
                }
                catch (Exception)
                {

                    return 0d;
                }
            }
        }

        /// <summary>
        /// Equity
        /// </summary>
        /// <returns></returns>
        public double Equity
        {
            get
            {
                string xPath = @"/ReportFinancialStatements[@Major='1']/FinancialStatements/AnnualPeriods/
                            FiscalPeriod[@Type='Annual' and @EndDate='@@date' and @FiscalYear='@@year']/
                            Statement[@Type='BAL']//lineItem[@coaCode='QTLE']";
                xPath = xPath.Replace("@@date", _date);
                xPath = xPath.Replace("@@year", Convert.ToString(_date[..4]));

                var lineItems = DocumentElement.SelectNodes(xPath);
                if (lineItems.Count != 1)
                {
                    return 0d;
                }

                try
                {
                    return Convert.ToDouble(lineItems[0].InnerText, _culture);
                }
                catch (Exception)
                {

                    return 0d;
                }
            }
        }

        /// <summary>
        /// NetIncomeFromCashStatement
        /// </summary>
        /// <returns></returns>
        public double NetIncomeFromCashStatement
        {
            get
            {
                string xPath = @"/ReportFinancialStatements[@Major='1']/FinancialStatements/AnnualPeriods/
                            FiscalPeriod[@Type='Annual' and @EndDate='@@date' and @FiscalYear='@@year']/
                            Statement[@Type='CAS']//lineItem[@coaCode='ONET']";
                xPath = xPath.Replace("@@date", _date);
                xPath = xPath.Replace("@@year", Convert.ToString(_date[..4]));

                var lineItems = DocumentElement.SelectNodes(xPath);
                if (lineItems.Count != 1)
                {
                    return 0d;
                }

                try
                {
                    return Convert.ToDouble(lineItems[0].InnerText, _culture);
                }
                catch (Exception)
                {

                    return 0d;
                }
            }
        }

        /// <summary>
        /// OperatingCashFlow
        /// </summary>
        /// <returns></returns>
        public double OperatingCashFlow
        {
            get
            {
                string xPath = @"/ReportFinancialStatements[@Major='1']/FinancialStatements/AnnualPeriods/
                            FiscalPeriod[@Type='Annual' and @EndDate='@@date' and @FiscalYear='@@year']/
                            Statement[@Type='CAS']//lineItem[@coaCode='OTLO']";
                xPath = xPath.Replace("@@date", _date);
                xPath = xPath.Replace("@@year", Convert.ToString(_date[..4]));

                var lineItems = DocumentElement.SelectNodes(xPath);
                if (lineItems.Count != 1)
                {
                    return 0d;
                }

                try
                {
                    return Convert.ToDouble(lineItems[0].InnerText, _culture);
                }
                catch (Exception)
                {

                    return 0d;
                }
            }
        }

        /// <summary>
        /// InvestmentsInPropertyPlantAndEquipment
        /// </summary>
        /// <returns></returns>
        public double InvestmentsInPropertyPlantAndEquipment
        {
            get
            {
                string xPath = @"/ReportFinancialStatements[@Major='1']/FinancialStatements/AnnualPeriods/
                            FiscalPeriod[@Type='Annual' and @EndDate='@@date' and @FiscalYear='@@year']/
                            Statement[@Type='CAS']//lineItem[@coaCode='SCEX']";
                xPath = xPath.Replace("@@date", _date);
                xPath = xPath.Replace("@@year", Convert.ToString(_date[..4]));

                var lineItems = DocumentElement.SelectNodes(xPath);
                if (lineItems.Count != 1)
                {
                    return 0d;
                }

                try
                {
                    return Convert.ToDouble(lineItems[0].InnerText, _culture);
                }
                catch (Exception)
                {

                    return 0d;
                }
            }
        }
    }
}
