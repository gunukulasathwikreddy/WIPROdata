using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

using Moq;

namespace MockExampleEmploy
{
    [TestFixture]
    internal class EmployDAOMockTest
    {
        List<Employ> emplist = new List<Employ>()
        {
            new Employ{Empno=1,Name="Akhil",Basic=88323},
            new Employ{Empno=2,Name="Yash",Basic=91911},
            new Employ{Empno=3,Name="Manali",Basic=86444}
        };

        Employ e1 = new Employ { Empno = 1, Name = "Prathyusha", Basic = 84234 };
        Employ e2 = new Employ { Empno = 2, Name = "Rohith", Basic = 82234 };

        Employ e3 = null;

        [Test]
        public void TestShowEmp()
        {
            Mock<IEmployDAO> obj = new Mock<IEmployDAO>();
            obj.Setup(x => x.ShowEmploy()).Returns(emplist);
            Assert.AreEqual(3,obj.Object.ShowEmploy().Count);
        }

        [Test]

        public void TestSearchEmp()
        {
            Mock<IEmployDAO> obj = new Mock<IEmployDAO>();

            obj.Setup(x => x.SearchEmploy(1)).Returns(e1);
            Assert.IsNotNull(obj.Object.SearchEmploy(1));

            obj.Setup(x => x.SearchEmploy(2)).Returns(e2);
            Assert.IsNotNull(obj.Object.SearchEmploy(2));

            obj.Setup(x => x.SearchEmploy(3)).Returns(e3);
            Assert.IsNull(obj.Object.SearchEmploy(3));
        }
    }
}
