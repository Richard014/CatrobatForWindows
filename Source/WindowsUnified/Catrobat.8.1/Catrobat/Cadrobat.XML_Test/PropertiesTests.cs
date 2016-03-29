﻿using System;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Catrobat.IDE.Core.Xml.XmlObjects.Bricks.Properties;
using Catrobat.IDE.Core;
using Catrobat.IDE.Core.Xml.XmlObjects.Formulas;
using System.IO;

namespace Catrobat.XML_Test
{
    [TestClass]
    public class PropertiesTest
    {
         [TestMethod]
        public void XmlChangeBrightnessBrickTest()
        {
            TextReader sr = new StringReader("<brick type=\"ChangeBrightnessByNBrick\"><formulaList><formula category=\"CHANGE_BRIGHTNESS\"><type>NUMBER</type><value>25</value></formula></formulaList></brick>");
            var xRoot = XElement.Load(sr);

            var testObject = new XmlChangeBrightnessBrick(xRoot);

            var referenceObject = new XmlChangeBrightnessBrick()
            {
                ChangeBrightness = new XmlFormula(xRoot, XmlConstants.ChangeBrightness),
            };

            Assert.AreEqual(referenceObject, testObject);
        }

         [TestMethod]
         public void XmlChangeGhostEffectBrickTest()
         {
             TextReader sr = new StringReader("<brick type=\"ChangeGhostEffectByNBrick\"><formulaList><formula category=\"TRANSPARENCY_CHANGE\"><type>NUMBER</type><value>2.5</value></formula></formulaList></brick>");
             var xRoot = XElement.Load(sr);

             var testObject = new XmlChangeGhostEffectBrick(xRoot);

             var referenceObject = new XmlChangeGhostEffectBrick()
             {
                 ChangeGhostEffect = new XmlFormula(xRoot, XmlConstants.ChangeGhostEffect),
             };

             Assert.AreEqual(referenceObject, testObject);
         }

         [TestMethod]
         public void XmlChangeSizeByNBrickTest()
         {
             TextReader sr = new StringReader("<brick type=\"ChangeSizeByNBrick\"> <formulaList> <formula category=\"SIZE_CHANGE\"> <type>NUMBER</type> <value>1.5</value> </formula> </formulaList> </brick>");
             var xRoot = XElement.Load(sr);

             var testObject = new XmlChangeSizeByNBrick(xRoot);

             var referenceObject = new XmlChangeSizeByNBrick()
             {
                 Size = new XmlFormula(xRoot, XmlConstants.SizeChange),
             };

             Assert.AreEqual(referenceObject, testObject);
         }

        [TestMethod]
         public void XmlChangeXByBrickTest()
         {
             TextReader sr = new StringReader("<brick type=\"ChangeXByNBrick\"> <formulaList> <formula category=\"X_POSITION_CHANGE\"> <type>USER_VARIABLE</type> <value>x speed</value> </formula> </formulaList> </brick>");
             var xRoot = XElement.Load(sr);

             var testObject = new XmlChangeXByBrick(xRoot);

             var referenceObject = new XmlChangeXByBrick()
             {
                 XMovement = new XmlFormula(xRoot, XmlConstants.XPositionChange),
             };

             Assert.AreEqual(referenceObject, testObject);
         }

        [TestMethod]
        public void XmlChangeYByBrickTest()
        {
            TextReader sr = new StringReader("<brick type=\"ChangeYByNBrick\"> <formulaList> <formula category=\"Y_POSITION_CHANGE\"> <type>USER_VARIABLE</type> <value>x speed</value> </formula> </formulaList> </brick>");
            var xRoot = XElement.Load(sr);

            var testObject = new XmlChangeYByBrick(xRoot);

            var referenceObject = new XmlChangeYByBrick()
            {
                YMovement = new XmlFormula(xRoot, XmlConstants.YPositionChange),
            };

            Assert. AreEqual(referenceObject, testObject);
        }

        [TestMethod]
        public void XmlClearGraphicEffectBrickTest()
        {
            TextReader sr = new StringReader("<brick type=\"ClearGraphicEffectBrick\"></brick>");
            var xRoot = XElement.Load(sr);

            var testObject = new XmlClearGraphicEffectBrick(xRoot);

            var referenceObject = new XmlClearGraphicEffectBrick(xRoot);

            Assert.AreEqual(referenceObject, testObject);
        }

        [TestMethod]
        public void XmlPlaceAtBrickTest()
        {
            TextReader sr = new StringReader("<brick type=\"PlaceAtBrick\">  <formulaList>  <formula category=\"Y_POSITION\"> <rightChild> <type>NUMBER</type> <value>80</value> </rightChild> <type>OPERATOR</type> <value>MINUS</value>  </formula>  <formula category=\"X_POSITION\"> <rightChild> <type>NUMBER</type> <value>115</value> </rightChild> <type>OPERATOR</type> <value>MINUS</value>  </formula>  </formulaList>  </brick>");
            var xRoot = XElement.Load(sr);

            var testObject = new XmlPlaceAtBrick(xRoot);

            var referenceObject = new XmlPlaceAtBrick()
            {
                XPosition = new XmlFormula(xRoot, XmlConstants.XPosition),
                YPosition = new XmlFormula(xRoot, XmlConstants.YPosition),
            };

            Assert.AreEqual(referenceObject, testObject);
        }
    }
}
