using Core.BaseTypes;
using NUnit.Framework;
using Tests.RulesForTesting;

namespace Tests.Cells.BaseCell {
    [TestFixture]
    public class CanMoveFromShip {
        private Field field;

        [SetUp]
        public void TestInit()
        {
            var testEmptyRules = new TestEmptyRules();
            field = new Field(testEmptyRules);
        }

        [Test]
        public void ShouldTakeIntoAccountBottomBorder()
        {
            // Arrange
            var cell = field.Cells(6, 12);

            // Act
            var pirateCanMoveTo = cell.PirateCanMoveTo();

            // Assert
            pirateCanMoveTo.Count.ShouldBeEqual(4);
        }

        [Test]
        public void ShouldTakeIntoAccountTopBorder()
        {
            // Arrange
            var cell = field.Cells(6, 0);

            // Act
            var pirateCanMoveTo = cell.PirateCanMoveTo();

            // Assert
            pirateCanMoveTo.Count.ShouldBeEqual(4);
        }

        [Test]
        public void ShouldTakeIntoAccountLeftBorder()
        {
            // Arrange
            var cell = field.Cells(12, 6);

            // Act
            var pirateCanMoveTo = cell.PirateCanMoveTo();

            // Assert
            pirateCanMoveTo.Count.ShouldBeEqual(4);
        }

        [Test]
        public void ShouldTakeIntoAccountRightBorder()
        {
            // Arrange
            var cell = field.Cells(0, 6);

            // Act
            var pirateCanMoveTo = cell.PirateCanMoveTo();

            // Assert
            pirateCanMoveTo.Count.ShouldBeEqual(4);
        }
    }
}