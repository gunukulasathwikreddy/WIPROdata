using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

using Moq;

namespace MockExample2
{
    [TestFixture]
    internal class CalculationMockTest
    {
        [Test]
        public void TestAdd()
        { 
            Mock<Calculation> obj = new Mock<Calculation>();
            obj.Setup(x => x.Sum(5,2)).Returns(5+2);
            Assert.AreEqual(7,obj.Object.Sum(5,2));
        }

        [Test]
        public void TestSub()
        {
            Mock<Calculation> obj = new Mock<Calculation>();
            obj.Setup(x => x.Sub(5, 2)).Returns(5-2);
            Assert.AreEqual(3, obj.Object.Sub(5, 2));
        }

        [Test]
        public void TestMul()
        {
            Mock<Calculation> obj = new Mock<Calculation>();
            obj.Setup(x => x.Mult(5, 2)).Returns(5*2);
            Assert.AreEqual(10, obj.Object.Mult(5, 2));
        }
    }
}
