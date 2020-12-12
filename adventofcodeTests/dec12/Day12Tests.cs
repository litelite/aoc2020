using adventofcode.dec12;
using adventofcode.utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace adventofcodeTests.dec12
{
    [TestClass()]
    public class Day12Tests
    {
        private IFileReader _fileReader;
        private Day12 _instance;

        [TestInitialize]
        public void Initialize()
        {
            _fileReader = Substitute.For<IFileReader>();
            _instance = new Day12(_fileReader);
        }

        [TestMethod()]
        public void Day12Test()
        {
            // Arrange
            var data = new[]
            {
                "F10",
                "N3",
                "F7",
                "R90",
                "F11",
            };
            _fileReader.ReadLineByLine(Arg.Any<string>()).Returns(data);

            //Act
            var (part1, part2) = _instance.GetAnswers();

            //Assert
            Assert.AreEqual(25, part1);
            Assert.AreEqual(0, part2);
        }
    }
}