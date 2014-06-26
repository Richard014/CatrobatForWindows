﻿using Catrobat.IDE.Core.Models.Bricks;
using Catrobat.IDE.Core.ExtensionMethods;
using Context = Catrobat.IDE.Core.Xml.Converter.XmlProjectConverter.ConvertContext;

// ReSharper disable once CheckNamespace
namespace Catrobat.IDE.Core.Xml.XmlObjects.Bricks.ControlFlow
{
    partial class XmlForeverLoopEndBrick
    {
        protected override Brick ToModel2(Context context)
        {
            var result = new EndForeverBrick();
            context.Bricks[this] = result;
            result.Begin = LoopBeginBrick == null ? null : (ForeverBrick) LoopBeginBrick.ToModel(context);
            return result;
        }
    }
}