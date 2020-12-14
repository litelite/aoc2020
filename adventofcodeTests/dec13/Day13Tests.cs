using adventofcode.dec13;
using adventofcode.utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace adventofcodeTests.dec13
{
    [TestClass()]
    public class Day13Tests
    {
        private IFileReader _fileReader;
        private Day13 _instance;

        [TestInitialize]
        public void Initialize()
        {
            _fileReader = Substitute.For<IFileReader>();
            _instance = new Day13(_fileReader);
        }

        [TestMethod()]
        public void Day12Test()
        {
            // Arrange
            var data = new[]
            {
                "939",
                "7,13,x,x,59,x,31,19",
            };
            _fileReader.ReadLineByLine(Arg.Any<string>()).Returns(data);

            //Act
            var (part1, part2) = _instance.GetAnswers();

            //Assert
            Assert.AreEqual(295, part1);
            Assert.AreEqual(1068781, part2);
        }
    }
}