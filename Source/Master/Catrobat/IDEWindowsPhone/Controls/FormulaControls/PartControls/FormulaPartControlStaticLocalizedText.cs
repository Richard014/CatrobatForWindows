﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Catrobat.IDECommon.Resources;
using Catrobat.IDECommon.Resources.IDE.Editor;
using Catrobat.IDECommon.Resources.IDE.Formula;

namespace Catrobat.IDEWindowsPhone.Controls.FormulaControls.PartControls
{
    public class FormulaPartControlStaticLocalizedText : FormulaPartControl
    {
        private static LocalizedStrings _localizedStrings;

        public string LocalizedResourceName { get; set; }

        protected override Grid CreateControls(int fontSize, bool isParentSelected, bool isSelected, bool isError)
        {
            string text = LocalizedResourceName != null ? GetText() : "RESOURCE MISSING";

            var textBlock = new TextBlock
            {
                Text = text,
                FontSize = fontSize
            };

            var grid = new Grid { DataContext = this };
            grid.Children.Add(textBlock);

            return grid;
        }

        private string GetText()
        {
            if (_localizedStrings == null)
                _localizedStrings = Application.Current.Resources["LocalizedStrings"] as LocalizedStrings;

            var text = (string)typeof(FormulaResources).GetProperty(LocalizedResourceName).GetValue(_localizedStrings.Formula);

            return text;
        }

        public override int GetCharacterWidth()
        {
            return GetText().Length;
        }

        public override FormulaPartControl Copy()
        {
            return new FormulaPartControlStaticLocalizedText
            {
                Style = Style,
                LocalizedResourceName = this.LocalizedResourceName
            };
        }
    }
}
