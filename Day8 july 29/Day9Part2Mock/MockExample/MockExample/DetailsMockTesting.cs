using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

using Moq;

namespace MockExample
{
    [TestFixture]
    internal class DetailsMockTesting
    {
        [Test]
        public void TestShowCompany()
        {
            Mock<IDetails> obj = new Mock<IDetails>();
            obj.Setup(x => x.ShowCompany()).Returns("wipro hyd branch");
            Assert.AreEqual("wipro hyd branch",obj.Object.ShowCompany());
        }

        [Test]
        public void TestShowStudent()
        {
            Mock<IDetails> obj = new Mock<IDetails>();
            obj.Setup(x => x.ShowStudent()).Returns("greetings student method");
            Assert.AreEqual("greetings student method", obj.Object.ShowStudent());
        }
    }
}
