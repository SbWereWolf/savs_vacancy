using System;
using AlienLanguageBL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class BlUnitTest
    {
        [TestMethod]
        public void TranslateTestA()
        {
            var businessLogic = new BusinessLogic();

            var result = businessLogic.Translate("z", 1);
            Assert.AreEqual(result,1);
        }
        [TestMethod]
        public void TranslateTestB()
        {
            const char symbol = 'a';
            var businessLogic = new BusinessLogic(symbol);

            var result = businessLogic.Translate(symbol.ToString(), 1);
            Assert.AreEqual(result, 1);
        }
        [TestMethod]
        public void TranslateTestC()
        {
            var businessLogic = new BusinessLogic();

            var result = businessLogic.Translate("zzzz", 1);
            Assert.AreEqual(result, 1);
        }
        [TestMethod]
        public void TranslateTestD()
        {
            var businessLogic = new BusinessLogic();

            var result = businessLogic.Translate("az", 1);
            Assert.AreEqual(result, 0);
        }
        [TestMethod]
        public void TranslateTestE()
        {
            var businessLogic = new BusinessLogic();

            var result = businessLogic.Translate("qwez", 3);
            Assert.AreEqual(result, 0);
        }
        [TestMethod]
        public void TranslateTestF()
        {
            var businessLogic = new BusinessLogic();

            var result = businessLogic.Translate("qwez", 4);
            Assert.AreEqual(result, 1);
        }
        [TestMethod]
        public void TranslateTestG()
        {
            var businessLogic = new BusinessLogic();

            var result = businessLogic.Translate("qwez", 6);
            Assert.AreEqual(result, 1);
        }
        [TestMethod]
        public void TranslateTestJ()
        {
            var businessLogic = new BusinessLogic();

            var result = businessLogic.Translate("qwez", 8);
            Assert.AreEqual(result, 2);
        }
        [TestMethod]
        public void TranslateTestK()
        {
            var businessLogic = new BusinessLogic();

            var result = businessLogic.Translate("qwerty", 19);
            Assert.AreEqual(result, 0);
        }
        [TestMethod]
        public void TranslateTestLongSBigN1()
        {
            var businessLogic = new BusinessLogic();

            var result = businessLogic.Translate("z012345678z012345678z012345678z012345678z012345678z012345678z012345678z012345678z012345678z012345678", (long)Math.Pow(10,12));
            Assert.AreEqual(result, (long)Math.Pow(10, 11));
        }
        [TestMethod]
        public void TranslateTestLongSBigN2()
        {
            var businessLogic = new BusinessLogic();

            var result = businessLogic.Translate("01234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567z", (long)Math.Pow(10, 12));
            Assert.AreEqual(result, (long)(Math.Pow(10, 12)/99));
        }
        [TestMethod]
        public void TranslateTestLongSBigN3()
        {
            var businessLogic = new BusinessLogic();

            var result = businessLogic.Translate("0123456789012345678901234567890123456789012345678z", (long)Math.Pow(10, 12));
            Assert.AreEqual(result, (long)Math.Pow(10, 12)/50);
        }
        [TestMethod]
        public void TranslateTestLongSBigN4()
        {
            var businessLogic = new BusinessLogic();

            var result = businessLogic.Translate("012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678a", (long)Math.Pow(10, 12));
            Assert.AreEqual(result, 0);
        }

    }
}
