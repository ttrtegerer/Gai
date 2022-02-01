using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestVinLib
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ChekTrueVin()
        {
            //arrange
            string vin = "WDBA33AZAB0215060";
            Boolean expectid = true;
            //act
            VIN_LIB.Class1 VIN = new VIN_LIB.Class1();
            Boolean actual = VIN.CheckVIN(vin);
            //accert
            Assert.AreEqual(expectid, actual);

        }
        [TestMethod]
        public void ChekFalseVin()
        {
            //arrange
            string vin = "2DBA33AZAB0215060";
            Boolean expectid = false;
            //act
            VIN_LIB.Class1 VIN = new VIN_LIB.Class1();
            Boolean actual = VIN.CheckVIN(vin);
            //accert
            Assert.AreEqual(expectid, actual);

        }
        [TestMethod]
        public void GetVINCountryGermani()
        {
            //arrange
            string vin = "WDBA33AZAB0215060";
            string expectid = "Германия";
            //act
            VIN_LIB.Class1 VIN = new VIN_LIB.Class1();
            string actual = VIN.GetVINCountry(vin);
            //accert
            Assert.AreEqual(expectid, actual);

        }
        [TestMethod]
        public void GetVINCountry()
        {
            //arrange
            string vin = "JABA33AZAB0215060";
            string expectid = "Япония";
            //act
            VIN_LIB.Class1 VIN = new VIN_LIB.Class1();
            string actual = VIN.GetVINCountry(vin);
            //accert
            Assert.AreEqual(expectid, actual);

        }
        [TestMethod]
        public void GetTransportYear0()
        {
            //arrange
            string vin = "JABA33AZAB0215060";
            int expectid =0;
            //act
            VIN_LIB.Class1 VIN = new VIN_LIB.Class1();
            int actual = VIN.GetTransportYear(vin);
            //accert
            Assert.AreEqual(expectid, actual);

        }
    }
}
