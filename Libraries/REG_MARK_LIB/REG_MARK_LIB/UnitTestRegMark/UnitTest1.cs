using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestRegMark
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetFalseNumber()
        {
            //arrange
            string vin = "P999PP999";
            Boolean expectid = false;
            //act
            REG_MARK_LIB.Class1 VIN = new REG_MARK_LIB.Class1();
            Boolean actual = VIN.CheckMark(vin);
            //accert
            Assert.AreEqual(expectid, actual);
        }
        [TestMethod]
        public void GetNextNumber()
        {
            //arrange
            string vin = "P543BP99";
            string expectid = "P544BP99";
            //act
            REG_MARK_LIB.Class1 VIN = new REG_MARK_LIB.Class1();
            string actual = VIN.GetNextMarkAfter(vin);
            //accert
            Assert.AreEqual(expectid, actual);
        }
    }
}
