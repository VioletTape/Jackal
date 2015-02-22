using Core.Cells;
using NUnit.Framework;
using Tests.RulesForTesting;

namespace Tests.FieldTest {
    [TestFixture]
    public class FieldCellOperationsTests {

        [SetUp]
        public void TestInit() {
            
        }

        [Test]
        public void WhenDrawCellItShouldBeLinkedToField() {
            // Arrange
            var testEmptyRules = new TestEmptyRules();
            var field = testEmptyRules.Field;

            var iceCell = new IceCell(4, 3);
            iceCell.Field.ShouldBeNull();

            // Act
            field.Draw(iceCell);

            // Assert
            iceCell.Field.ShouldBeEqual(field);
        }
    }
}