﻿using System.Xml.Linq;
using Catrobat.IDE.Core.Xml.XmlObjects.Formulas;

namespace Catrobat.IDE.Core.Xml.XmlObjects.Bricks.Properties
{
    public partial class XmlTurnRightBrick : XmlBrick
    {
        public XmlFormula Degrees { get; set; }

        public XmlTurnRightBrick() {}

        public XmlTurnRightBrick(XElement xElement) : base(xElement) {}

        internal override void LoadFromXml(XElement xRoot)
        {
            Degrees = new XmlFormula(xRoot.Element(XmlConstants.TurnRightDegrees));
        }

        internal override XElement CreateXml()
        {
            var xRoot = new XElement(XmlConstants.Brick);
            xRoot.SetAttributeValue(XmlConstants.Type, XmlConstants.XmlTurnRightBrickType);

            var xElement = Degrees.CreateXml();
            xElement.SetAttributeValue(XmlConstants.Category, XmlConstants.TurnRightDegrees);
            xRoot.Add(xElement);

            return xRoot;
        }

        internal override void LoadReference()
        {
            if (Degrees != null)
                Degrees.LoadReference();
        }
    }
}