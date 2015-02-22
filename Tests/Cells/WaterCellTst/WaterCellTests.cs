using Core.Cells;
using Core.Enums;
using NUnit.Framework;
using Tests.DSL;

namespace Tests.Cells.WaterCellTst {
    [TestFixture]
    public class WaterCellTests {
        [Test]
        public void ShouldBeOfWaterType() {
            //Arrange
            var waterCell = new WaterCell(1, 1);

            //Assert
            waterCell.CellType.ShouldBeEqual(CellType.Water);
        }

        [Test]
        public void ShouldBeDiscoverdByDefault() {
            //Arrange
            var waterCell = new WaterCell(1, 1);

            //Assert
            waterCell.Discoverd.ShouldBeTrue();
        }

        [Test]
        public void ShouldBeTerminal() {
            //Arrange
            var waterCell = new WaterCell(1, 1);

            //Assert
            waterCell.Terminal.ShouldBeTrue();
        }



        [Test]
        public void PirateCanComeFromCannon() {
            //Arrange

            //Act

            //Assert
        }
    }
}