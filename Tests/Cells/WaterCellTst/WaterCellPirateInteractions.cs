using Core.BaseTypes;
using Core.Cells;
using Core.Enums;
using NUnit.Framework;
using Tests.DSL;
using Tests.PirateTst;

namespace Tests.Cells.WaterCellTst {
    [TestFixture]
    public class WaterCellPirateInteractions {
        [Test]
        public void WhenPirateComeHeShouldLostGold() {
            //Arrange
             var pirate = Black.Pirate;

             pirate.SetWithGold();
            var waterCell = new WaterCell(1, 1);

            //Act
            waterCell.PirateComing(pirate);

            //Assert
            pirate.IsWithGold().ShouldBeFalse();
        }

        [Test]
        public void PirateShouldNotLostGoldIfThereIsShip() {
            //Arrange
            var waterCell = new WaterCell(1, 1);
            var ship = new Ship(PlayerType.Yellow, waterCell);
            ship.Pirates[0].SetWithGold();

            //Act
            waterCell.PirateComing(ship.Pirates[0]);

            //Assert
            ship.Pirates[0].IsWithGold().ShouldBeFalse();
            ship.Gold.ShouldBeEqual(1);
        }
    }
}