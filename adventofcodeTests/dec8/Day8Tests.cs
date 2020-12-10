using adventofcode.dec8;
using adventofcode.utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace adventofcodeTests.dec8
{
    [TestClass()]
    public class Day8Tests
    {
        private IFileReader _fileReader;
        private Day8 _instance;

        [TestInitialize]
        public void Initialize()
        {
            _fileReader = Substitute.For<IFileReader>();
            _instance = new Day8(_fileReader);
        }

        [TestMethod]
        public void When_CalledWithExample_Expect_CorrectAnswer()
        {
            // Arrange
            var data = new[]
            {
                "nop +0",
                "acc +1",
                "jmp +4",
                "acc +3",
                "jmp -3",
                "acc -99",
                "acc +1",
                "jmp -4",
                "acc +6"
            };
            _fileReader.ReadLineByLine(Arg.Any<string>()).Returns(data);

            //Act
            var (part1, part2) = _instance.GetAnswers();

            //Assert
            Assert.AreEqual(5, part1);
            Assert.AreEqual(8, part2);
        }

    }
}