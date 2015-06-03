using Core.BaseTypes;
using Core.Cells;
using Core.Enums;
using FluentAssertions;
using NUnit.Framework;
using Tests.RulesForTesting;

namespace Tests.Cells.ShipTst {
    [TestFixture]
    public class ShipCanNotMoveTo {
        private Ship ship;
        private Team teamBlack;

        [SetUp]
        public void TestInit() {
            teamBlack = new Team(TeamType.Black, new TestEmptyRules(4));

            ship = new Ship(teamBlack, new WaterCell(1, 1));
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
			var blackShip = new Ship(teamBlack, originalCell, Ship.ShipMovement.Horizontal);
            blackShip.Pirates.Add(teamBlack.Pirates.Current);

			// act
			var destCell = new WaterCell(1, 6);
			blackShip.MoveTo(destCell);

			//assert
		    blackShip.Pirates.Count.Should()
		        .BeGreaterOrEqualTo(1);
                
			blackShip.Cell.ShouldBeEqual(originalCell);
		}

		[Test]
		public void AlongTheHorizontalLineIfOnVertical()
		{
			var originalCell = new WaterCell(1, 5);
			var blackShip = new Ship(teamBlack, originalCell, Ship.ShipMovement.Vertical);
            blackShip.Pirates.Add(teamBlack.Pirates.Current);


			// act
			var destCell = new WaterCell(2, 5);
			blackShip.MoveTo(destCell);

			//assert
            blackShip.Pirates.Count.Should()
                .BeGreaterOrEqualTo(1);

			blackShip.Cell.ShouldBeEqual(originalCell);
		}
	}	
}