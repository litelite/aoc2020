using adventofcode.dec6;
using adventofcode.utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace adventofcodeTests.dec6
{
    [TestClass()]
    public class Day6Tests
    {
        private IFileReader _fileReader;
        private adventofcode.dec6.Day6 _instance;

        [TestInitialize]
        public void Initialize()
        {
            _fileReader = Substitute.For<IFileReader>();
            _instance = new adventofcode.dec6.Day6(_fileReader);
        }

        [TestMethod]
        public void When_CalledWithExample_Expect_CorrectAnswer()
        {
            // Arrange
            var data = new[]
            {
                "abc",
                "",
                "a",
                "b",
                "c",
                "",
                "ab",
                "ac",
                "",
                "a",
                "a",
                "a",
                "a",
                "",
                "b",
            };
            _fileReader.ReadLineByLine(Arg.Any<string>()).Returns(data);

            //Act
            var (part1, part2) = _instance.GetAnswers();

            //Assert
            Assert.AreEqual(11, part1);
            Assert.AreEqual(6, part2);
        }
    }
}