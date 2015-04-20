using Core.BaseTypes;
using Core.Cells;
using Core.Enums;
using Core.Extensions;
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
			var originalCell = new WaterCell(1,1);
            var team = new Team(TeamType.Black, new TestEmptyRules(4));
			var ship = new Ship(team, originalCell);

			// Act
			var newCell = new WaterCell(1,2);
			ship.MoveTo(newCell);

            Assert.Fail();
			// Assert
//			originalCell.Ship.ShouldBeNull();
//			newCell.Ship.ShouldBeNotNull();

		}
	}
}