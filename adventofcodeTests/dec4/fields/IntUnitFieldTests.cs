using adventofcode.dec4.fields;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace adventofcodeTests.dec4.fields
{
    [TestClass()]
    public class IntUnitFieldTests
    {
        [TestClass]
        public class IsValid
        {
            [TestMethod]
            [DataRow("60in", "in", 59, 76, true)]
            [DataRow("190cm", "cm", 150, 193, true)]
            [DataRow("190in", "in", 59, 76, false)]
            [DataRow("190", "cm", 150, 193, false)]
            public void When_Called_Expect_CorrectResult(string value, string unit, int min, int max, bool expected)
            {
                // Arrange
                var field = new IntUnitField("key", value, new IntUnitField.UnitBound(unit, min, max));

                //Act
                var result = field.IsValid();

                //Assert
                Assert.AreEqual(expected, result);
            }
        }
    }
}