using adventofcode.dec5;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace adventofcodeTests.dec5
{
    [TestClass()]
    public class SeatFinderTests
    {
        [TestClass]
        public class FindRow
        {
            private SeatFinder _instance;

            [TestInitialize]
            public void Initialize()
            {
                _instance = new SeatFinder();
            }

            [TestMethod]
            [DataRow("FBFBBFFRLR", 44)]
            public void When_InputIsCorrect_Expect_CorrectOutput(string input, int expected)
            {
                var result = _instance.FindRow(input, 0, SeatFinder.NbRows - 1);

                Assert.AreEqual(expected, result);

            }
        }

        [TestClass]
        public class FindColumn
        {
            private SeatFinder _instance;

            [TestInitialize]
            public void Initialize()
            {
                _instance = new SeatFinder();
            }

            [TestMethod]
            [DataRow("RLR", 5)]
            public void When_InputIsCorrect_Expect_CorrectOutput(string input, int expected)
            {
                var result = _instance.FindColumn(input, 0, SeatFinder.NbColumns - 1);

                Assert.AreEqual(expected, result);

            }
        }
    }
}