using Core.BaseTypes;
using Core.Cells;
using NUnit.Framework;
using Tests.RulesForTesting;

namespace Tests.FieldTest {
    [TestFixture]
    public class FieldCellOperationsTests {
        private TestEmptyRules rule;
        private FieldStub field;

        [SetUp]
        public void TestInit() {
            rule = new TestEmptyRules();
            field = new FieldStub(rule);
        }

        [Test]
        public void WhenDrawCellItShouldBeLinkedToField() {
            // Arrange
            var iceCell = new IceCell(4, 3);
            iceCell.Field.ShouldBeNull();
                
            // Act
            field.Draw(iceCell);

            // Assert
            iceCell.Field.ShouldBeEqual(field);
        }
    }
}