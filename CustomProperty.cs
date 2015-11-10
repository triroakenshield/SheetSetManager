using System;
using System.Xml;

namespace SheetSetManager
{
    public class CustomProperty : MyNode
    {

        public CustomProperty(XmlElement nParent)
        {
            Parent = nParent;
        }

        public override String Name 
        {
            get { return Parent.GetAttribute("propname"); }
        }

        public String Value
        {
            get 
            {
                XmlNode pValue = Parent.SelectSingleNode("./AcSmProp[@propname=\"Value\"]");
                if (pValue != null)
                {
                    return pValue.InnerText;
                }
                else { return ""; };                
            }
        }

    }
}
