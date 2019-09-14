using CalculatorChallenge;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            var result = format.GetNumbersFromArgument("1, 2");
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void TestStringTwo()
        {
            FormatOutput format = new FormatOutput();
            var result = format.GetNumbersFromArgument("1, x, 2");
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void TestStringUnlimited()
        {
            FormatOutput format = new FormatOutput();
            var result = format.GetNumbersFromArgument("1, 2, 3,4,5,6,7,8,9,10,11,12");
            Assert.AreEqual(78, result);

        }

        [TestMethod]
        public void TestStringUnlimitedCharacters()
        {
            FormatOutput format = new FormatOutput();
            var result = format.GetNumbersFromArgument("1, 2, 3,4,5,6,7,8,9,10,11,12, x, x, x, 13");
            Assert.AreEqual(91, result);
        }
    }
}
