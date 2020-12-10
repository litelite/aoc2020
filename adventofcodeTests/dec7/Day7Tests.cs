using adventofcode.utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace adventofcodeTests.dec7
{
    [TestClass()]
    public class Day7Tests
    {
        private IFileReader _fileReader;
        private adventofcode.dec7.Day7 _instance;

        [TestInitialize]
        public void Initialize()
        {
            _fileReader = Substitute.For<IFileReader>();
            _instance = new adventofcode.dec7.Day7(_fileReader);
        }

        [TestMethod]
        public void When_CalledWithExample_Expect_CorrectAnswer()
        {
            // Arrange
            var data = new[]
            {
                "light red bags contain 1 bright white bag, 2 muted yellow bags.",
                "dark orange bags contain 3 bright white bags, 4 muted yellow bags.",
                "bright white bags contain 1 shiny gold bag.",
                "muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.",
                "shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.",
                "dark olive bags contain 3 faded blue bags, 4 dotted black bags.",
                "vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.",
                "faded blue bags contain no other bags.",
                "dotted black bags contain no other bags.",
            };
            _fileReader.ReadLineByLine(Arg.Any<string>()).Returns(data);

            //Act
            var (part1, _) = _instance.GetAnswers();

            //Assert
            Assert.AreEqual(4, part1);
        }

        [TestMethod]
        public void When_CalledWithExample2_Expect_CorrectAnswer()
        {
            // Arrange
            var data = new[]
            {
                "shiny gold bags contain 2 dark red bags.",
                "dark red bags contain 2 dark orange bags.",
                "dark orange bags contain 2 dark yellow bags.",
                "dark yellow bags contain 2 dark green bags.",
                "dark green bags contain 2 dark blue bags.",
                "dark blue bags contain 2 dark violet bags.",
                "dark violet bags contain no other bags.",
            };
            _fileReader.ReadLineByLine(Arg.Any<string>()).Returns(data);

            //Act
            var (_, part2) = _instance.GetAnswers();

            //Assert
            Assert.AreEqual(126, part2);
        }
    }
}