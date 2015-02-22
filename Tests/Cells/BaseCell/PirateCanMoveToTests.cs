using Core.BaseTypes;
using NUnit.Framework;
using Tests.RulesForTesting;

namespace Tests.Cells.BaseCell {
    [TestFixture]
    public class PirateCanMoveTo {
        private Field field;

        [SetUp]
        public void TestInit() {
            var testEmptyRules = new TestEmptyRules();
            field = testEmptyRules.Field;
        }

        [Test]
        public void ShouldProvideAllPossibleDirectionsInMiddleOfField() {
            // Arrange
            var cell = field.Cells(3, 4);

            // Act
            var pirateCanMoveTo = cell.PirateCanMoveTo();

            // Assert
            pirateCanMoveTo.Count.ShouldBeEqual(9);
        }

        [Test]
        public void ShouldTakeIntoAccountTopLeftCorner() {
            // Arrange
            var cell = field.Cells(0, 0);

            // Act
            var pirateCanMoveTo = cell.PirateCanMoveTo();

            // Assert
            pirateCanMoveTo.Count.ShouldBeEqual(4);
        }

        [Test]
        public void ShouldTakeIntoAccountTopRightCorner() {
            // Arrange
            var cell = field.Cells(0, 12);

            // Act
            var pirateCanMoveTo = cell.PirateCanMoveTo();

            // Assert
            pirateCanMoveTo.Count.ShouldBeEqual(4);
        }

        [Test]
        public void ShouldTakeIntoAccountBottomRightCorner() {
            // Arrange
            var cell = field.Cells(12, 12);

            // Act
            var pirateCanMoveTo = cell.PirateCanMoveTo();

            // Assert
            pirateCanMoveTo.Count.ShouldBeEqual(4);
        }

        [Test]
        public void ShouldTakeIntoAccountBottomLeftCorner() {
            // Arrange
            var cell = field.Cells(12, 0);

            // Act
            var pirateCanMoveTo = cell.PirateCanMoveTo();

            // Assert
            pirateCanMoveTo.Count.ShouldBeEqual(4);
        }

        [Test]
        public void ShouldTakeIntoAccountBottomBorder() {
            // Arrange
            var cell = field.Cells(6, 12);

            // Act
            var pirateCanMoveTo = cell.PirateCanMoveTo();

            // Assert
            pirateCanMoveTo.Count.ShouldBeEqual(2);
        }

        [Test]
        public void ShouldTakeIntoAccountTopBorder() {
            // Arrange
            var cell = field.Cells(6, 0);

            // Act
            var pirateCanMoveTo = cell.PirateCanMoveTo();

            // Assert
            pirateCanMoveTo.Count.ShouldBeEqual(2);
        }

        [Test]
        public void ShouldTakeIntoAccountLeftBorder() {
            // Arrange
            var cell = field.Cells(12, 6);

            // Act
            var pirateCanMoveTo = cell.PirateCanMoveTo();

            // Assert
            pirateCanMoveTo.Count.ShouldBeEqual(2);
        }

        [Test]
        public void ShouldTakeIntoAccountRightBorder() {
            // Arrange
            var cell = field.Cells(0, 6);

            // Act
            var pirateCanMoveTo = cell.PirateCanMoveTo();

            // Assert
            pirateCanMoveTo.Count.ShouldBeEqual(2);
        }
    }
}