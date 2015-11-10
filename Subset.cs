using System;
using System.Collections.Generic;
using System.Xml;

namespace SheetSetManager
{
    public class Subset : AbstractSubset
    {
        internal XmlElement parent;

        public Subset(XmlElement nParent)
        {
            parent = nParent;            
            //
            subsetList = new List<Subset>();
            XmlNodeList wXMLList = parent.SelectNodes("./AcSmSubset");
            foreach (XmlNode xmln in wXMLList)
            {
                subsetList.Add(new Subset((XmlElement)xmln));
            }
            //
            sheetList = new List<Sheet>();
            wXMLList = parent.SelectNodes("./AcSmSheet");
            foreach (XmlNode xmln in wXMLList)
            {
                sheetList.Add(new Sheet((XmlElement)xmln));
            }
        }

        public override String Name
        {
            get
            {
                int res = this.GetAllSheetCount();
                return ShortName + "(" + res.ToString() + ") ";
            }
        }

        public String ShortName
        {
            get
            {
                XmlNode wNode = parent.SelectSingleNode("./AcSmProp[@propname=\"Name\"]");
                return wNode.InnerText;
            }
        }

    }
}
