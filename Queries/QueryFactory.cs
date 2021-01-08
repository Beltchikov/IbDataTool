using System;
using System.Collections.Generic;
using System.Text;

namespace IbDataTool.Queries
{
    /// <summary>
    /// QueryFactory
    /// </summary>
    public class QueryFactory
    {
        private static readonly object lockObject = new object();

        private static CompaniesWithoutDocumentQuery _companiesWithoutDocumentQuery;


        /// <summary>
        /// CompaniesWithoutDocumentQuery
        /// </summary>
        public static CompaniesWithoutDocumentQuery CompaniesWithoutDocumentQuery
        {
            get
            {
                lock (lockObject)
                {
                    if (_companiesWithoutDocumentQuery == null)
                    {
                        _companiesWithoutDocumentQuery = new CompaniesWithoutDocumentQuery();
                    }
                    return _companiesWithoutDocumentQuery;
                }
            }
        }

        

    }
}
