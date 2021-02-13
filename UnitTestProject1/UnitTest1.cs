using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawRectangle;
using static DrawRectangle.RectangleShape;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {


        [TestMethod]
        public void TestAbsoluteValue()
        {

            MapPoint mouseClickPoint = new MapPoint();
            mouseClickPoint.X = 0;
            mouseClickPoint.Y = 0;

            MapPoint mouseReleasePoint = new MapPoint();
            mouseReleasePoint.X = 10;
            mouseReleasePoint.Y = 10;

            DrawRectangle.RectangleShape RB = new DrawRectangle.RectangleShape();
            //RB.CreateAnchor(mouseClickPoint, mouseReleasePoint);

            Assert.AreEqual(10, RB.Height);
      
        }
    }
}
