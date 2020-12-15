using adventofcode.dec15;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace adventofcodeTests.dec15
{
    [TestClass()]
    public class NumberGameTests
    {
        [TestMethod()]
        [DataRow(new[]{0,3,6}, 2020, 436)]
        public void FindNthSpokenNumberTest(int[] seed, int turns, int expected)
        {
            // Arrange
            var game = new NumberGame();
            
            //Act
            var result = game.FindNthSpokenNumber(seed, turns);
            
            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}