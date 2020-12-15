using adventofcode.dec15;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace adventofcodeTests.dec15
{
    [TestClass()]
    public class NumberGameTests
    {
        [TestMethod()]
        [DataRow(new[]{0,3,6}, 2020, 436)]
        [DataRow(new[]{0,3,6}, 30000000, 175594)]
        [DataRow(new[]{1,3,2 }, 30000000, 2578)]
        [DataRow(new[]{2,1,3}, 30000000, 3544142)]
        [DataRow(new[]{1,2,3} , 30000000, 261214)]
        [DataRow(new[]{2,3,1} , 30000000, 6895259)]
        [DataRow(new[]{3,2,1} , 30000000, 18)]
        [DataRow(new[]{3,1,2} , 30000000, 362)]
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