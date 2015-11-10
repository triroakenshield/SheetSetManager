using System;
using System.Xml;

namespace SheetSetManager
{
    public abstract class MyNode
    {
        public XmlElement Parent;

        public abstract String Name { get; }
    }
}
