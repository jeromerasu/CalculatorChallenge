using CalculatorChallenge;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CalculatorChallengeTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        ///Test 1st Criteria
        public void TestMethod1()
        {
            FormatOutput format = new FormatOutput();
            var result = format.GetNumbersFromArgument("1, 2", false, Environment.NewLine, 1000, 1, false);
            Assert.AreEqual(3, result.Total);
        }

        [TestMethod]
        public void TestStringTwo()
        {
            FormatOutput format = new FormatOutput();
            var result = format.GetNumbersFromArgument("1, x, 2", false, Environment.NewLine, 1000, 1, false);
            Assert.AreEqual(3, result.Total);
        }

        [TestMethod]
        public void TestStringUnlimited()
        {
            FormatOutput format = new FormatOutput();
            var result = format.GetNumbersFromArgument("1, 2, 3,4,5,6,7,8,9,10,11,12", false, Environment.NewLine, 1000, 1, false);
            Assert.AreEqual(78, result.Total);

        }

        [TestMethod]
        public void TestStringUnlimitedCharacters()
        {
            FormatOutput format = new FormatOutput();
            var result = format.GetNumbersFromArgument("1, 2, 3,4,5,6,7,8,9,10,11,12, x, x, x, 13", false, Environment.NewLine, 1000, 1, false);
            Assert.AreEqual(91, result.Total);
        }

        [TestMethod]
        public void TestStringSpace()
        {
            FormatOutput format = new FormatOutput();
            var result = format.GetNumbersFromArgument("1" + Environment.NewLine + "13, 3 ", false, Environment.NewLine, 1000, 1, false);
            Assert.AreEqual(17, result.Total);
        }
        [TestMethod]
        [ExpectedException(typeof(NegativeNumberException))]
        public void TestStringNegatives()
        {
            FormatOutput format = new FormatOutput();
            String[] test = new string[] { "-1", "2", "3" };
            var result = format.TestCalculateProductLine(test);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void TestNumbersAboveThousand()
        {
            FormatOutput format = new FormatOutput();
            var result = format.GetNumbersFromArgument("1" + Environment.NewLine + " 1000, 1001" + Environment.NewLine + "2", false, Environment.NewLine, 1000, 1, false);
            Assert.AreEqual(1003, result.Total);
        }


        [TestMethod]
        public void TestNumbersCustomDelim()
        {
            FormatOutput format = new FormatOutput();
            var result = format.GetNumbersFromArgument("//[.]" + Environment.NewLine + "1.2.3" + Environment.NewLine + "2", false, Environment.NewLine, 1000, 1, false);
            Assert.AreEqual(8, result.Total);
        }

        [TestMethod]
        public void TestNumbersCustomUnlimitedDelim()
        {
            FormatOutput format = new FormatOutput();
            var result = format.GetNumbersFromArgument("//[...]" + Environment.NewLine + "1...23" + Environment.NewLine + "2", false, Environment.NewLine, 1000, 1, false);
            Assert.AreEqual(26, result.Total);
        }


        [TestMethod]
        public void TestNumbersCustomUnlimitedDelims()
        {
            FormatOutput format = new FormatOutput();
            var result = format.GetNumbersFromArgument("//[...][;.']" + Environment.NewLine + "1...23;.'1" + Environment.NewLine + "2", false, Environment.NewLine, 1000, 1, false);
            Assert.AreEqual(27, result.Total);
        }

        [TestMethod]
        public void TestNumbersCustomUnlimitedDelimsCustomDelimInput()
        {
            FormatOutput format = new FormatOutput();
            var result = format.GetNumbersFromArgument("//[...][;.']" + Environment.NewLine + "1...23;.'1.2.1", false, ".", 1000, 1, false);
            Assert.AreEqual(28, result.Total);
        }

        [TestMethod]
        public void TestNumbersCustomUnlimitedDelimsCustomDelimInputSubt()
        {
            FormatOutput format = new FormatOutput();
            var result = format.GetNumbersFromArgument("//[...][;.']" + Environment.NewLine + "1...23;.'1.2.1", true, ".", 1000, 2, false);
            Assert.AreEqual(-26, result.Total);
        }
        [TestMethod]
        public void TestNumbersCustomUnlimitedDelimsCustomDelimInputMult()
        {
            FormatOutput format = new FormatOutput();
            var result = format.GetNumbersFromArgument("//[...][;.']" + Environment.NewLine + "1...2;.'-3.1", true, ".", 1000, 3, false);
            Assert.AreEqual(-6, result.Total);
        }
        [TestMethod]
        public void TestNumbersCustomUnlimitedDelimsCustomDelimInputDiv()
        {
            FormatOutput format = new FormatOutput();
            var result = format.GetNumbersFromArgument("//[...][;.']" + Environment.NewLine + "8...1;.'1.2", true, ".", 1000, 4, false);
            Assert.AreEqual(4, result.Total);
        }

        [TestMethod]
        public void TestNumbersCustomUnlimitedDelimsCustomDelimInputSmallUpperBound()
        {
            FormatOutput format = new FormatOutput();
            var result = format.GetNumbersFromArgument("//[...][;.']" + Environment.NewLine + "11...1;.'1.2", true, ".", 10, 4, false);
            Assert.AreEqual(0, result.Total);
        }
    }
}
