using Core.BaseTypes;
using Core.Cells;
using Core.Enums;
using FluentAssertions;
using NUnit.Framework;

namespace Tests.Cells.ShipTst {
    [TestFixture]
    public class ShipCanNotMoveTo {
        private Ship ship;

        [SetUp]
        public void TestInit() {
            ship = new Ship(Player.Black, new WaterCell(1, 1));
        }

        [Test]  
        public void WhenThereIsNoPirates() {
            var cell = new WaterCell(1,2);
            ship.Pirates.Clear();

            // act
            ship.MovedTo(cell);

            // Assert
            ship.Cell
                .ShouldBeEqual(new WaterCell(1,1));
        }
    }
}