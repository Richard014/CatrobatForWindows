﻿using System.Xml.Linq;
using Catrobat.IDE.Core.Xml.XmlObjects.Formulas;

namespace Catrobat.IDE.Core.Xml.XmlObjects.Bricks.Properties
{
    public partial class XmlSetGhostEffectBrick : XmlBrick
    {
        public XmlFormula Transparency { get; set; }

        public XmlSetGhostEffectBrick() {}

        public XmlSetGhostEffectBrick(XElement xElement) : base(xElement) {}

        internal override void LoadFromXml(XElement xRoot)
        {
            Transparency = new XmlFormula(xRoot.Element(XmlConstants.Transparency));
        }

        internal override XElement CreateXml()
        {
            var xRoot = new XElement(XmlConstants.Brick);
            xRoot.SetAttributeValue(XmlConstants.Type, XmlConstants.XmlSetGhostEffectBrickType);

            var xElement = Transparency.CreateXml();
            xElement.SetAttributeValue(XmlConstants.Category, XmlConstants.Transparency);
            xRoot.Add(xElement);

            return xRoot;
        }

        internal override void LoadReference()
        {
            if (Transparency != null)
                Transparency.LoadReference();
        }
    }
}