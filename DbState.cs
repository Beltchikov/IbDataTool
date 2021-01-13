using System;
using System.Collections.Generic;
using System.Text;

namespace IbDataTool
{
    /// <summary>
    /// DbState
    /// </summary>
    public class DbState
    {
        /// <summary>
        /// StocksTotal
        /// </summary>
        public static int StocksTotal { get; set; }

        /// <summary>
        /// Companies without all set of financial documents
        /// </summary>
        public static List<string> CompaniesWoDocuments { get; set; }

        /// <summary>
        /// Companies without all set of financial documents and without IB symbol
        /// </summary>
        public static List<string> CompaniesWoDocumentsAndIbSymbol { get; set; }

        /// <summary>
        /// Companies without all set of financial documents, without IB symbol and without entries in table NotResolved, NotUnique.
        /// </summary>
        public static List<string> CompaniesWoDocumentsIbSymbolNotResolvedNotUnique { get; set; }

        /// <summary>
        /// CompaniesWoDocumentsButWithIbSymbol
        /// </summary>
        public static List<string> CompaniesWoDocumentsButWithIbSymbol { get; set; }
    }
}
