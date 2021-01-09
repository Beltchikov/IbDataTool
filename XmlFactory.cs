using IbDataTool.Model;
using IBSampleApp.messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace IbDataTool
{
    public class XmlFactory
    {
        private static XmlFactory _xmlFactory;
        private static readonly object lockObject = new object();

        XmlFactory() { }

        /// <summary>
        /// Instance
        /// </summary>
        public static XmlFactory Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (_xmlFactory == null)
                    {
                        _xmlFactory = new XmlFactory();
                    }
                    return _xmlFactory;
                }
            }
        }

        /// <summary>
        /// CreateXml
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public FundamentalsXmlDocument CreateXml(FundamentalsMessage obj, string date)
        {
            return new FundamentalsXmlDocument(obj.Data, date);
        }
    }
}
