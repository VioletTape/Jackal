using Core.BaseTypes;
using Core.Enums;
using NUnit.Framework;
using Tests.DSL;
using Tests.RulesForTesting;

namespace Tests.Cells.BaseCell {
    [TestFixture]
    public class PirateCanMoveTo {
        private GreenField field;
        private Pirate pirate;

        [SetUp]
        public void TestInit() {
            field = new GreenField();
            pirate = field.CurrentPirate;
           
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
        public void WhenAddPirateShouldSetPosition() {
            //Arrange
            var pirate = Black.Pirate;
            var stubCell = new StubCell(3,4);

            //Act
            stubCell.AddPirate(pirate);

            //Assert
            pirate.Position
                .ShouldBeEqual(new Position(3, 4));
            
        }

        [Test]
        public void OldCellShouldReleasePirate() {
            //Arrange
            var cell = field.Cells(3, 4);
            cell.AddPirate(pirate);

            //Act
            field.MovePirateTo(pirate, field.Cells(4, 4));

            //Assert
            cell.Pirates
                .ShouldBeEmpty();
        }
    }
}