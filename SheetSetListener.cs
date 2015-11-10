using System;
using System.Collections.Generic;
using System.Xml;

namespace SheetSetManager
{
    public class SheetSetListener : AbstractSubset
    {
        public new AcSmXml Parent;

        public SheetSetListener(string nfilename)
        {
            Parent = new AcSmXml();
            Parent.LoadFromDstFile(nfilename);
            //
            subsetList = new List<Subset>();
            sheetList = new List<Sheet>();
            if (Parent.isReady)
            {
                XmlNodeList wXMLList = Parent.SelectNodes(".//AcSmSheetSet/AcSmSubset");
                foreach (XmlNode xmln in wXMLList)
                {
                    subsetList.Add(new Subset((XmlElement)xmln));
                }
                //                
                wXMLList = Parent.SelectNodes(".//AcSmSheetSet/AcSmSheet");
                foreach (XmlNode xmln in wXMLList)
                {
                    sheetList.Add(new Sheet((XmlElement)xmln));
                }
            }
        }
        
        public SheetSetListener(AcSmXml nParent)
        {
            Parent = nParent;
            //
            subsetList = new List<Subset>();
            sheetList = new List<Sheet>();
            if (Parent.isReady) {
                XmlNodeList wXMLList = Parent.SelectNodes(".//AcSmSheetSet/AcSmSubset");
                foreach (XmlNode xmln in wXMLList)
                {
                    subsetList.Add(new Subset((XmlElement)xmln));
                }
                //                
                wXMLList = Parent.SelectNodes(".//AcSmSheetSet/AcSmSheet");
                foreach (XmlNode xmln in wXMLList)
                {
                    sheetList.Add(new Sheet((XmlElement)xmln));
                }
            }
        }

        public void ReLoad()
        {
            if (Parent.isReady) {
                XmlNodeList wXMLList = Parent.SelectNodes(".//AcSmSheetSet/AcSmSubset");
                foreach (XmlNode xmln in wXMLList)
                {
                    subsetList.Add(new Subset((XmlElement)xmln));
                }
                //                
                wXMLList = Parent.SelectNodes(".//AcSmSheetSet/AcSmSheet");
                foreach (XmlNode xmln in wXMLList)
                {
                    sheetList.Add(new Sheet((XmlElement)xmln));
                }
            }
        }

        public override String Name
        {
            get { 
                string [] wArr = Parent.filename.Split((char)92);
                if (Parent.isReady)
                {
                    int res = this.GetAllSheetCount();
                    return wArr[wArr.GetUpperBound(0)] + "(" + res.ToString() + ") ";
                }
                else return wArr[wArr.GetUpperBound(0)];        
            }
        }

        public XmlNode GetXMLSheetSet()
        {
            if (Parent.isReady)
            {
                return Parent.SelectSingleNode(".//AcSmSheetSet");
            }
            else return null;
        }

        public List<Property> GetPropertyList()
        {
            List<Property> wList = new List<Property>();
            if (Parent.isReady)
            {
                XmlNodeList wXMLList = Parent.SelectNodes(".//AcSmSheetSet/AcSmProp");
                foreach (XmlNode xmln in wXMLList)
                {
                    wList.Add(new Property((XmlElement)xmln));
                }
            }
            return wList;
        }

        public List<CustomProperty> GetCustomPropertyList()
        {
            List<CustomProperty> wList = new List<CustomProperty>();
            if (Parent.isReady)
            {
                XmlNode wXMLNode = Parent.SelectSingleNode(".//AcSmSheetSet/AcSmCustomPropertyBag");
                foreach (XmlNode xmln in wXMLNode.ChildNodes)
                {
                    wList.Add(new CustomProperty((XmlElement)xmln));
                }
            }
            return wList;
        }

        public bool isReady
        {
            get { return Parent.isReady; }
        }

    }
}
