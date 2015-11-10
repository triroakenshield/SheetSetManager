using System;
using System.Xml;

namespace SheetSetManager
{
    public class Layout : MyNode
    {

        public Layout(XmlElement nParent)
        {
            Parent = nParent;
        }

        public String Handle
        {
            get
            {
                XmlNode wNode = Parent.SelectSingleNode("./AcSmProp[@propname=\"AcDbHandle\"]");
                return wNode.InnerText;
            }
        }

        public String FileName
        {
            get
            {
                XmlNode wNode = Parent.SelectSingleNode("./AcSmProp[@propname=\"FileName\"]");
                return wNode.InnerText;
            }
        }

        public override String Name
        {
            get
            {
                XmlNode wNode = Parent.SelectSingleNode("./AcSmProp[@propname=\"Name\"]");
                return wNode.InnerText;
            }
        }

    }
}
