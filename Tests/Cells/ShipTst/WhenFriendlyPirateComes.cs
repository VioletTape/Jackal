using Core.BaseTypes;
using Core.Cells;
using Core.Enums;
using NUnit.Framework;

namespace Tests.Cells.ShipTst {
	[TestFixture]
	public class WhenFriendlyPirateComes {
		[SetUp]
		public void TestInit() {
			var waterCell = new WaterCell(1, 1);
			
			var blackShip = new Ship(PlayerType.Black, waterCell);
			var redShip = new Ship(PlayerType.Red, new WaterCell(2, 2));

			blackShip.Pirates.Clear();
			var redPirate = redShip.Pirates[0];

			// act
			waterCell.AddPirate(redPirate);
		}

		[Test]
		public void ShipShouldRecognizeFriendlyPirate() {
			var waterCell = new WaterCell(1,1);

			var blackShip = new Ship(PlayerType.Black, waterCell);
			var redShip = new Ship(PlayerType.Red, new WaterCell(2,2));

			blackShip.Pirates.Clear();
			var redPirate = redShip.Pirates[0];

			// act
			waterCell.AddPirate(redPirate);

			// assert
			redPirate.State.ShouldBeEqual(PlayerState.Dead);
			waterCell.Pirates.ShouldBeEmpty();

			Assert.Fail();
		}
	}
}