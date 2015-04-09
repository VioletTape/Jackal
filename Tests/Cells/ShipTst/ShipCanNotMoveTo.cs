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
            ship = new Ship(PlayerType.Black, new WaterCell(1, 1));
        }

        [Test]  
        public void WhenThereIsNoPirates() {
            var cell = new WaterCell(1,2);
            ship.Pirates.Clear();

            // act
            ship.MoveTo(cell);

            // Assert
            ship.Cell
                .ShouldBeEqual(new WaterCell(1,1));
        }

		[Test]
		public void AlongTheVerticalLineIfOnHorizontal()
		{
			var originalCell = new WaterCell(1, 5);
			var blackShip = new Ship(PlayerType.Black, originalCell, Ship.ShipMovement.Horizontal);

			// act
			var destCell = new WaterCell(1, 6);
			blackShip.MoveTo(destCell);

			//assert
			blackShip.Cell.ShouldBeEqual(originalCell);
		}

		[Test]
		public void AlongTheHorizontalLineIfOnVertical()
		{
			var originalCell = new WaterCell(1, 5);
			var blackShip = new Ship(PlayerType.Black, originalCell, Ship.ShipMovement.Vertical);

			// act
			var destCell = new WaterCell(2, 5);
			blackShip.MoveTo(destCell);

			//assert
			blackShip.Cell.ShouldBeEqual(originalCell);
		}
	}	
}