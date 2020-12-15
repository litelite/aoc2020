using adventofcode.dec14;
using adventofcode.utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace adventofcodeTests.dec14
{
    [TestClass()]
    public class Day14Tests
    {
        private IFileReader _fileReader;
        private Day14 _instance;

        [TestInitialize]
        public void Initialize()
        {
            _fileReader = Substitute.For<IFileReader>();
            _instance = new Day14(_fileReader);
        }

        [TestMethod()]
        public void Day14TestPart1()
        {
            // Arrange
            var data = new[]
            {
                "mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X",
                "mem[8] = 11",
                "mem[7] = 101",
                "mem[8] = 0"
            };
            _fileReader.ReadLineByLine(Arg.Any<string>()).Returns(data);

            //Act
            var (part1, _) = _instance.GetAnswers();

            //Assert
            Assert.AreEqual(165, part1);
        }
        
        [TestMethod()]
        public void Day14TestPart2()
        {
            // Arrange
            var data = new[]
            {
                "mask = 000000000000000000000000000000X1001X",
                "mem[42] = 100",
                "mask = 00000000000000000000000000000000X0XX",
                "mem[26] = 1",
            };
            _fileReader.ReadLineByLine(Arg.Any<string>()).Returns(data);

            //Act
            var (_, part2) = _instance.GetAnswers();

            //Assert
            Assert.AreEqual(208, part2.Value);
        }
    }
}