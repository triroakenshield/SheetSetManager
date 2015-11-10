using System;
using System.Collections.Generic;
using System.Xml;

namespace SheetSetManager
{
    public class CustomPropertyBag : MyNode
    {

        public List<CustomProperty> wList;

        public CustomPropertyBag(XmlElement nParent)
        {
            Parent = nParent;
            wList = new List<CustomProperty>();
            //
            foreach (XmlNode xmln in this.Parent)
            {
                wList.Add(new CustomProperty((XmlElement)xmln));
            }
        }

        public override String Name
        {
            get
            {
                return "CustomPropertyBag";
            }
        }

        public CustomProperty GetCustomProperty(string CustomPropertyName)
        {
            return wList.Find(x => x.Name == CustomPropertyName);
        }

    }
}
