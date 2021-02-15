    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using DrawRectangle;
    using static DrawRectangle.RectangleShape;

    namespace UnitTestProject2
    {
        [TestClass]
        public class UnitTest1
        {


            [TestMethod]
            public void TestRectangle()
            {

                RectangleShape rectangle = new RectangleShape();

                rectangle.Height = 4;
                rectangle.Width = 6;



                Assert.AreEqual(24, rectangle.Width * rectangle.Height);

            }
        
            [TestMethod]
            public void TestSquare()
            {

                RectangleShape square = new SquareShape();

                square.Height = 4;
                square.Width = 6;



                Assert.AreEqual(16, square.Width * square.Height);

            }
    
        }
    }


