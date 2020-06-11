using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FastFup_Prove_Eksamen_1;

namespace TransportCalcTest
{
    [TestClass]
    public class TransportCalcTest
    {
        private TransportCalc transportCalc;
    
        [TestMethod]
        public void TotalMethodTest() //Test af Total-metoden fra TransportCalc class.
        {
            transportCalc = new TransportCalc();
            int result = TransportCalc.Total("1 2 3");

            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void AverageMethodTest() //Test af Average-metoden fra TransportCalc class.
        {
            transportCalc = new TransportCalc();
            double result = TransportCalc.Average(100, 20.0);

            Assert.AreEqual(500, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AverageMethodTestException() //Test af Average-metoden fra TransportCalc class og forventning af outofrange exception, hvis Average falder udenfor det tilladte interval som er 0-2000.
        {
            transportCalc = new TransportCalc();
            double result = TransportCalc.Average(200000, 20.0);

            Assert.AreEqual(200, result); //bruger den ikke - da den kaster en outofrange execption
        }
    }
}
