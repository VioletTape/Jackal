using Core.BaseTypes;
using Core.Cells;
using Core.Enums;
using NUnit.Framework;
using Tests.RulesForTesting;

namespace Tests.Cells.ShipTst {
	[TestFixture]
	public class WhenFriendlyPirateComes {
	    private Ship blackShip;
	    private Ship redShip;

	    [SetUp]
		public void TestInit() {
			var waterCell = new WaterCell(1, 1);
            var teamBlack = new Team(TeamType.Black, new TestEmptyRules(4));
            var teamRed = new Team(TeamType.Red, new TestEmptyRules(4));

			
			blackShip = new Ship(teamBlack, waterCell);
			redShip = new Ship(teamRed, new WaterCell(2, 2));

			blackShip.Pirates.Clear();
			var redPirate = redShip.Pirates[0];

			// act
			waterCell.AddPirate(redPirate);
		}

		[Test]
		public void ShipShouldRecognizeFriendlyPirate() {
			var waterCell = new WaterCell(1,1);

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