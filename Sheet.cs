using System;
using System.Collections.Generic;
using System.Xml;

namespace SheetSetManager
{
    public class Sheet : MyNode
    {

        public CustomPropertyBag wCustomPropertyBag;
        public Layout layout;

        public Sheet(XmlElement nParent)
        {
            Parent = nParent;
            XmlNode wNode = Parent.SelectSingleNode("./AcSmAcDbLayoutReference");
            layout = new Layout((XmlElement)wNode);
            wNode = Parent.SelectSingleNode("./AcSmCustomPropertyBag");
            wCustomPropertyBag = new CustomPropertyBag((XmlElement)wNode);
        }

        public override String Name
        {
            get { return Number.ToString() + " " + Title; }
        }

        public String Title
        {
            get
            {
                XmlNode wNode = Parent.SelectSingleNode("./AcSmProp[@propname=\"Title\"]");
                return wNode.InnerText;
            }
        }

        public String Number
        {
            get
            {
                XmlNode wNode = Parent.SelectSingleNode("./AcSmProp[@propname=\"Number\"]");
                if (wNode != null)
                {
                    return wNode.InnerText;
                }
                else { return ""; }
            }
        }

        public List<CustomProperty> GetCustomPropertyList()
        {
            List<CustomProperty> wList = new List<CustomProperty>();
            XmlNode wXMLNode = Parent.SelectSingleNode("./AcSmCustomPropertyBag");
            foreach (XmlNode xmln in wXMLNode.ChildNodes)
            {
                wList.Add(new CustomProperty((XmlElement)xmln));
            }
            return wList;
        }

    }
}
