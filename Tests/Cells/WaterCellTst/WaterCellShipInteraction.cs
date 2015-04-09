using Core.BaseTypes;
using Core.Cells;
using Core.Enums;
using NUnit.Framework;

namespace Tests.Cells.WaterCellTst {
    [TestFixture]
    public class WaterCellShipInteraction {
        [Test]
        public void ShouldAcceptShips() {
            //Arrange
            var waterCell = new WaterCell(1, 1);
            var ship = new Ship(TeamType.Black, waterCell);

            //Act
            waterCell.ShipComes(ship);

            //Assert
            waterCell.Ship.ShouldBeNotNull();
        }

        [Test]
        public void ShouldReleaseShips() {
            //Arrange
            var waterCell = new WaterCell(1, 1);
            var ship = new Ship(TeamType.Black, waterCell);

            waterCell.ShipComes(ship);

            //Act
            waterCell.ShipLeaves();

            //Assert
            waterCell.Ship.ShouldBeNull();
        }
    }
}