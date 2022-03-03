using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass()]
    public class RomanNumberTests
    {
        [TestMethod()]
        public void ToStringTest()
        {
         RomanNumber a = new RomanNumber(1);
         Assert.AreEqual("I", a.ToString());
         a = new RomanNumber(3999);
         Assert.AreEqual("MMMCMXCIX", a.ToString());
        }
        [TestMethod()]
        public void AddTest()
        {
            RomanNumber a = new RomanNumber(1);
            RomanNumber b;
            RomanNumber c;
            for (ushort i = 1; i < 3998; i++)
            {

                b = new RomanNumber(i);
                c = new RomanNumber(++i);
                Assert.AreEqual(c.ToString(), (a + b).ToString());
            }
        }
        [TestMethod()]
        public void SubTest()
        {
            RomanNumber a = new RomanNumber(1);
            RomanNumber b;
            RomanNumber c;
            for (ushort i = 3999; i >= 2; i--)
            {
                b = new RomanNumber(i);
                c = new RomanNumber(--i);
                Assert.AreEqual(c.ToString(), (b - a).ToString());
            }
        }
        [TestMethod()]
        public void MulTest()
        {
         
            RomanNumber a = new RomanNumber(2);
            RomanNumber b;
            RomanNumber c;
            for (ushort i = 1; i < 2000 ; i++)
            {
                b = new RomanNumber(i);
                c = new RomanNumber(Convert.ToUInt16(i * 2));
                Assert.AreEqual(c.ToString(), (a * b).ToString());
            }

        }
        [TestMethod()]
        public void DivTest()
        {
            RomanNumber a = new RomanNumber(2);
            RomanNumber b;
            RomanNumber c;
            for (ushort i = 3998; i >= 2; i-=2)
            {
                b = new RomanNumber(i);
                c = new RomanNumber(Convert.ToUInt16(i / 2));
                Assert.AreEqual(c.ToString(), (b / a).ToString());
            }
        }
        [TestMethod()]
        public void CloneTest()
        {
            RomanNumber a;
            for (ushort i = 1; i < 4000; i++)
            {
                a = new RomanNumber(i);
                var c = a.Clone();
                Assert.AreEqual(a.ToString(), c.ToString());
            }
        }
        [TestMethod()]
        public void ExceptionTest()
        {
            RomanNumber a;
            RomanNumber b;
            Assert.ThrowsException<RomanNumberException>(()=>a = new RomanNumber(0));
            Assert.ThrowsException<RomanNumberException>(()=>a = new RomanNumber(4000));
            Assert.ThrowsException<RomanNumberException>(()=>a = new RomanNumber(5273));
            a = new RomanNumber(1);
            b = new RomanNumber(3999);
            Assert.ThrowsException<RomanNumberException>(()=>(a + b).ToString());
            a = new RomanNumber(1);
            b = new RomanNumber(1);
            Assert.ThrowsException<RomanNumberException>(()=>(a - b).ToString());
            a = new RomanNumber(2);
            b = new RomanNumber(2000);
            Assert.ThrowsException<RomanNumberException>(()=>(a * b).ToString());
            a = new RomanNumber(1);
            b = new RomanNumber(2);
            Assert.ThrowsException<RomanNumberException>(() => (a / b).ToString());
        }

        [TestMethod()]
        public void CompareTest()
        {
            RomanNumber a;
            RomanNumber b;
            for (ushort i = 1; i < 4000; i++)
            {
                a = new RomanNumber(i);
                b = new RomanNumber(i);
                Assert.IsTrue(a.CompareTo(b) == 0);
            }
            a = new RomanNumber(1);
            for (ushort i = 2; i < 4000; i++)
            {
                b = new RomanNumber(i);
                Assert.IsTrue(a.CompareTo(b) != 0);
            }
        }

    }
}