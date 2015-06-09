using Core.BaseTypes;
using Core.Cells;
using Core.Enums;
using NUnit.Framework;
using Tests.RulesForTesting;

namespace Tests.Cells.ShipTst {
    [TestFixture]
    public class WhenShipMoves {
        [SetUp]
        public void TestInit() {}

        [Test]
        public void OldCellShouldReleaseShip() {
            // arrange
            var originalCell = new WaterCell(1, 1);
            var team = new Team(TeamType.Black, new TestEmptyRules());
            var ship = new Ship(team, originalCell);
            ship.Pirates.Add(team.Pirates.Current);

            // Act
            var newCell = new WaterCell(1, 2);
            ship.MoveTo(newCell);

            // Assert
            ship.Cell
                .ShouldBeEqual(newCell);
        }

        [Test]
        public void AllPiratesShouldMoveWithShip() {
            // arrange
            var originalCell = new WaterCell(1, 1);
            var team = new Team(TeamType.Black, new TestEmptyRules());
            var ship = new Ship(team, originalCell);
            ship.Pirates.Add(team.Pirates.Current);
            ship.Pirates.Add(team.Pirates.GetNext());

            // Act
            var newCell = new WaterCell(1, 2);
            ship.MoveTo(newCell);

            // Assert
            foreach (var pirate in ship.Pirates) {
                pirate.Position
                    .ShouldBeEqual(newCell.Position);
            }
        }
    }
}