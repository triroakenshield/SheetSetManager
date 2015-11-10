using System;
using System.Xml;

namespace SheetSetManager
{
    public class Property : MyNode
    {

        public Property(XmlElement nParent)
        {
            Parent = nParent;
        }

        public override String Name 
        {
            get { return Parent.GetAttribute("propname"); }
        }

        public String Value
        {
            get { return Parent.InnerText; }
        }

    }
}
