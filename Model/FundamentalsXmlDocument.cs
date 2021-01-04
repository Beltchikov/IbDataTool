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
    }
}
