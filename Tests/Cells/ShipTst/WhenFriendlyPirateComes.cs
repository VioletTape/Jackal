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
	    private GreenField field;

	    [SetUp]
		public void TestInit() {
	        field = new GreenField(new TestEmptyRules(2), 1);
            field.GeneratePlayers(new TestEmptyRules(2));

	        var player = field.CurrentPlayer;

	        var teamBlack = player.CurrentTeam;
	        teamRed = player.GetNextTeam();

	        blackShip = teamBlack.Ship;
            blackShip.SetStrategy(Ship.ShipMovement.None);
	        redShip = teamRed.Ship;
	    }

		[Test]
		public void ShipShouldRecognizeFriendlyPirate() {
            // precondition
		    var oldCrew = blackShip.Pirates.Count;


		    // arrange
		    var waterCell = (WaterCell)field.Cells(1, 2);
		    var pirateRed = teamRed.Pirates.Current;
            waterCell.AddPirate(pirateRed);

            // act
		    blackShip.MoveTo(waterCell);

            // assert
            blackShip.Pirates.Count
                .ShouldBeEqual(oldCrew+1);
		}
	}
}