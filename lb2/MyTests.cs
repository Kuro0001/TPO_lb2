using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace lb2
{
    [TestFixture]
    class MyTests
    {
        static MyMath exprs;
        [SetUp]
        public void SetUpClass()
        {
            exprs = new MyMath();
        }
        double Count_result_MyMath(double x)
        {
            return exprs.CalculateResult(MyMath.Sin, MyMath.Cos, MyMath.Ln, MyMath.Log, x);
        }
        double Count_result_Math(double x)
        {
            return exprs.CalculateResult(Math.Sin, Math.Cos, Math.Log, Math.Log, x);
        }

        [Test]
        public void Cos()
        {
            for (double x = -10; x <= 10; x += 0.01)
            {
                Assert.AreEqual
                (
                    Math.Round(MyMath.Cos(x), 10, MidpointRounding.AwayFromZero),
                    Math.Round(Math.Cos(x), 10, MidpointRounding.AwayFromZero)
                );
            }
        }
        [Test]
        public void Sin()
        {
            for (double x = -10; x <= 0; x += 0.01)
            {
                Assert.AreEqual
                (
                    Math.Round(MyMath.Sin(x), 9, MidpointRounding.AwayFromZero),
                    Math.Round(Math.Sin(x), 9, MidpointRounding.AwayFromZero)
                );
            }
        }
        [Test]
        public void Cot()
        {
            double e_left = -(Math.PI / (double)2);
            double e_right = Math.PI / (double)2;
            for (double x = e_left; x <= e_right; x += 0.01)
            {
                Assert.AreEqual
                (
                    Math.Round(MyMath.Cot(x), 8, MidpointRounding.AwayFromZero),
                    Math.Round(1 / Math.Tan(x), 8, MidpointRounding.AwayFromZero)
                );
            }
        }
        [Test]
        public void Ln()
        {
            for (double x = -10; x <= 10; x += 0.1)
            {
                Assert.AreEqual
            (
                Math.Round(MyMath.Ln(x), 3, MidpointRounding.AwayFromZero),
                Math.Round(Math.Log(x), 3, MidpointRounding.AwayFromZero)
            );
            }
        }
        [Test]
        public void Log()
        {
            for (int y = -10; y <= 10; y += 1)
            {
                for (int x = -10; x <= 10; x += 1)
                {
                    Assert.AreEqual
                (
                    Math.Round(MyMath.Log(x, y), 3, MidpointRounding.AwayFromZero),
                    Math.Round(Math.Log(x, y), 3, MidpointRounding.AwayFromZero)
                );
                }
            }
        }
        [Test]
        public void Count_result_Where_X_IsLessOrEqualZero()
        {
            for (double x = -10; x < -0.01; x += 0.01)
            {
                if (x == 0)
                {
                    x += 0.1;
                }
                Assert.AreEqual
                (
                    Math.Round(Count_result_MyMath(x), 4, MidpointRounding.AwayFromZero),
                    Math.Round(Count_result_Math(x), 4, MidpointRounding.AwayFromZero)
                );
            }
        }
        [Test]
        public void Count_result_Where_X_IsMoreThanZero()
        {
            for (double x = 0.01; x <= 10; x += 0.01)
            {
                if (x == 0)
                {
                    x += 0.1;
                }
                Assert.AreEqual
                (
                    Math.Round(Count_result_MyMath(x), 4, MidpointRounding.AwayFromZero),
                    Math.Round(Count_result_Math(x), 4, MidpointRounding.AwayFromZero)
                );
            }
        }
    }
}
