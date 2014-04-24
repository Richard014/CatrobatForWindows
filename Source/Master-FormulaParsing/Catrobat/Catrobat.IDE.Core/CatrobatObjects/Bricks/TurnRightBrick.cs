﻿using System.ComponentModel;
using System.Globalization;
using System.Xml.Linq;
using Catrobat.IDE.Core.CatrobatObjects.Formulas;
using Catrobat.IDE.Core.FormulaEditor;

namespace Catrobat.IDE.Core.CatrobatObjects.Bricks
{
    public class TurnRightBrick : Brick
    {
        protected Formula _degrees;
        public Formula Degrees
        {
            get { return _degrees; }
            set
            {
                _degrees = value;
                RaisePropertyChanged();
            }
        }


        public TurnRightBrick() {}

        public TurnRightBrick(XElement xElement) : base(xElement) {}

        internal override void LoadFromXML(XElement xRoot)
        {
            _degrees = new Formula(xRoot.Element("degrees"));
        }

        internal override XElement CreateXML()
        {
            var xRoot = new XElement("turnRightBrick");

            var xVariable = new XElement("degrees");
            xVariable.Add(_degrees.CreateXML());
            xRoot.Add(xVariable);

            return xRoot;
        }

        internal override void LoadReference(XmlFormulaTreeConverter converter)
        {
            if (_degrees != null)
                _degrees.LoadReference(converter);
        }

        public override DataObject Copy()
        {
            var newBrick = new TurnRightBrick();
            newBrick._degrees = _degrees.Copy() as Formula;

            return newBrick;
        }

        public override bool Equals(DataObject other)
        {
            var otherBrick = other as TurnRightBrick;

            if (otherBrick == null)
                return false;

            return Degrees.Equals(otherBrick.Degrees);
        }
    }
}