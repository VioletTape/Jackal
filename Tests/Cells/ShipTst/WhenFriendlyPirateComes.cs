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
	    private Team teamRed;

	    [SetUp]
		public void TestInit() {
	        var player = new Player(TeamType.Black, TeamType.Red, new TestEmptyRules());

	        var teamBlack = player.CurrentTeam;
	        teamRed = player.GetNextTeam();
			
			blackShip = new Ship(teamBlack, new WaterCell(1, 1));
	        blackShip.Pirates.Add(teamBlack.Pirates.Current);

	        redShip = new Ship(teamRed, new WaterCell(2, 2));
	    }

		[Test]
		public void ShipShouldRecognizeFriendlyPirate() {
            // precondition
            blackShip.Pirates.Count
               .ShouldBeEqual(1);

            // arrange
			var waterCell = new WaterCell(1,2);
		    var pirateRed = teamRed.Pirates.Current;
            waterCell.AddPirate(pirateRed);

            // act
		    blackShip.MoveTo(waterCell);

            // assert
            blackShip.Pirates.Count
                .ShouldBeEqual(2);
		}
	}
}