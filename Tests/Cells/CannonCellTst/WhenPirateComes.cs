using Core.BaseTypes;
using Core.Cells;
using Core.Cells.CellTypes;
using NUnit.Framework;
using Tests.DSL;
using Tests.RulesForTesting;

namespace Tests.Cells.CannonCellTst {
    [TestFixture]
    public class WhenPirateComes {
        private Pirate black;

        [SetUp]
        public void Init() {
            Black.Reset();

            black = Black.Pirate;
        }

        [Test]
        public void HeShouldBeShootedToTheEdgeE() {
            // Arrange
            var testEmptyRules = new TestEmptyRules();
            var field = testEmptyRules.Field;

            var startCell = field.Cells(3, 3);
            var cannonCell = new CannonCell(4, 3);
            cannonCell.SetField("cannonDirection", CannonDirection.East);
            var endCell = field.Cells(12, 3);

            field.Draw(cannonCell);
            field.SetPirateOnCell(black, startCell);

            // Act
            field.SelectPirate(startCell);
            field.MovedTo(cannonCell);

            // Assert
            field.Cells(startCell.Position).Pirates.ShouldBeEmpty();
            field.Cells(cannonCell.Position).Pirates.ShouldBeEmpty();
            field.Cells(endCell.Position).Pirates.ShouldContain().Exact(black);
        }

        [Test]
        public void HeShouldBeShootedToTheEdgeW() {
            // Arrange
            var testEmptyRules = new TestEmptyRules();
            var field = testEmptyRules.Field;

            var startCell = field.Cells(3, 3);
            var cannonCell = new CannonCell(4, 3);
            cannonCell.SetField("cannonDirection", CannonDirection.West);
            var endCell = field.Cells(0, 3);

            field.Draw(cannonCell);
            field.SetPirateOnCell(black, startCell);

            // Act
            field.SelectPirate(startCell);
            field.MovedTo(cannonCell);

            // Assert
            field.Cells(startCell.Position).Pirates.ShouldBeEmpty();
            field.Cells(cannonCell.Position).Pirates.ShouldBeEmpty();
            field.Cells(endCell.Position).Pirates.ShouldContain().Exact(black);
        }

        [Test]
        public void HeShouldBeShootedToTheEdgeS() {
            // Arrange
            var testEmptyRules = new TestEmptyRules();
            var field = testEmptyRules.Field;

            var startCell = field.Cells(3, 3);
            var cannonCell = new CannonCell(4, 3);
            cannonCell.SetField("cannonDirection", CannonDirection.South);
            var endCell = field.Cells(4, 12);

            field.Draw(cannonCell);
            field.SetPirateOnCell(black, startCell);
            
            // Act
            field.SelectPirate(startCell);
            field.MovedTo(cannonCell);

            // Assert
            field.Cells(startCell.Position).Pirates.ShouldBeEmpty();
            field.Cells(cannonCell.Position).Pirates.ShouldBeEmpty();
            field.Cells(endCell.Position).Pirates.ShouldContain().Exact(black);
        }

        [Test]
        public void HeShouldBeShootedToTheEdgeN() {
            // Arrange
            var testEmptyRules = new TestEmptyRules();
            var field = testEmptyRules.Field;
            
            var startCell = field.Cells(3, 3);
            var cannonCell = new CannonCell(4, 3);
            cannonCell.SetField("cannonDirection", CannonDirection.North);
            var endCell = field.Cells(4, 0);

            field.Draw(cannonCell);
            field.SetPirateOnCell(black, startCell);
            
            // Act
            field.SelectPirate(startCell);
            field.MovedTo(cannonCell);

            // Assert
            field.Cells(startCell.Position).Pirates.ShouldBeEmpty();
            field.Cells(cannonCell.Position).Pirates.ShouldBeEmpty();
            field.Cells(endCell.Position).Pirates.ShouldContain().Exact(black);
        }
    }
}