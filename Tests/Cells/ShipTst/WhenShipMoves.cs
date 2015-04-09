using Core.BaseTypes;
using Core.Cells;
using Core.Enums;
using Core.Extensions;
using NUnit.Framework;

namespace Tests.Cells.ShipTst {
	[TestFixture]
	public class WhenShipMoves {
		[SetUp]
		public void TestInit() {}

		[Test]
		public void OldCellShouldReleaseShip() {
			// arrange
			var originalCell = new WaterCell(1,1);
			var ship = new Ship(PlayerType.Black, originalCell);

			// Act
			var newCell = new WaterCell(1,2);
			ship.MoveTo(newCell);

			// Assert
			originalCell.Ship.ShouldBeNull();
			newCell.Ship.ShouldBeNotNull();

		}
	}
}