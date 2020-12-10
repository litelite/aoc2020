using adventofcode.dec9;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace adventofcodeTests.dec9
{
    [TestClass()]
    public class DecoderTests
    {
        [TestMethod]
        public void When_DecodeCalled_Expect_CorrectOutput()
        {
            // Arrange
            var input = new long[]
            {
                35,
                20,
                15,
                25,
                47,
                40,
                62,
                55,
                65,
                95,
                102,
                117,
                150,
                182,
                127,
                219,
                299,
                277,
                309,
                576,
            };

            //Act
            var result = new Decoder().Decode(input, 5);

            //Assert
            Assert.AreEqual(127, result);
        }

        [TestMethod]
        public void When_FindRangeCalled_Expect_CorrectOutput()
        {
            // Arrange
            var input = new long[]
            {
                35,
                20,
                15,
                25,
                47,
                40,
                62,
                55,
                65,
                95,
                102,
                117,
                150,
                182,
                127,
                219,
                299,
                277,
                309,
                576,
            };

            //Act
            var result = new Decoder().FindRange(input, 127);

            //Assert
            Assert.AreEqual(62, result);
        }
    }
}