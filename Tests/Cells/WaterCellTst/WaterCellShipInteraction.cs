using Core.BaseTypes;
using Core.Cells;
using Core.Enums;
using NUnit.Framework;
using Tests.RulesForTesting;

namespace Tests.Cells.WaterCellTst {
    [TestFixture]
    public class WaterCellShipInteraction {
        private WaterCell waterCell;
        private Ship ship;

        [SetUp]
        public void Init() {
            //Arrange
            waterCell = new WaterCell(1, 1);
            var team = new Team(TeamType.Black, new TestEmptyRules(4));

            ship = new Ship(team, waterCell);
        }

        [Test]
        public void ShouldAcceptShips() {
            //Act
            waterCell.ShipComes(ship);

            //Assert
            waterCell.Ship.ShouldBeNotNull();
        }

        [Test]
        public void ShouldReleaseShips() {
            //Arrange
            waterCell.ShipComes(ship);

            //Act
            waterCell.ShipLeaves();

            //Assert
            waterCell.Ship.ShouldBeNull();
        }
    }
}