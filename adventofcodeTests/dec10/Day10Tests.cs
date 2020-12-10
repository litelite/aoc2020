using adventofcode.dec10;
using adventofcode.utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace adventofcodeTests.dec10
{
    [TestClass()]
    public class Day10Tests
    {
        private IFileReader _fileReader;
        private Day10 _instance;

        [TestInitialize]
        public void Initialize()
        {
            _fileReader = Substitute.For<IFileReader>();
            _instance = new Day10(_fileReader);
        }

        [TestMethod]
        public void When_CalledWithExample_Expect_CorrectAnswer()
        {
            // Arrange
            var data = new[]
            {
                "28",
                "33",
                "18",
                "42",
                "31",
                "14",
                "46",
                "20",
                "48",
                "47",
                "24",
                "23",
                "49",
                "45",
                "19",
                "38",
                "39",
                "11",
                "1",
                "32",
                "25",
                "35",
                "8",
                "17",
                "7",
                "9",
                "4",
                "2",
                "34",
                "10",
                "3",
            };
            _fileReader.ReadLineByLine(Arg.Any<string>()).Returns(data);

            //Act
            var (part1, part2) = _instance.GetAnswers();

            //Assert
            Assert.AreEqual(220, part1);
            Assert.AreEqual(19208, part2);
        }
    }
}