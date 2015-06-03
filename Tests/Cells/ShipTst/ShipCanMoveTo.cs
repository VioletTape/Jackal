using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using Core.BaseTypes;
using Core.Cells;
using Core.Enums;
using FluentAssertions;
using NUnit.Framework;
using Tests.RulesForTesting;

namespace Tests.Cells.ShipTst {
    [TestFixture]
    public class ShipCanMoveTo {
        private Ship ship;
        private WaterCell waterCell;
        private Team teamBlack;

        [SetUp]
        public void TestInit() {
            waterCell = new WaterCell(1, 1);
            teamBlack = new Team(TeamType.Black, new TestEmptyRules());

        }

        [Test]
        public void OnlyWhenPirateOnShip() {
            ship = new Ship(teamBlack, waterCell);
            ship.Pirates.Add(teamBlack.Pirates.Current);

            var destinationCell = new WaterCell(1, 2);

            // act
            ship.MoveTo(destinationCell);

            // Assert
            ship.Pirates.Count
                .Should()
                .BeGreaterOrEqualTo(1);

            ship.Cell
                .ShouldBeEqual(destinationCell);
        }

        [Test]
        public void WhenPiratesOnShip() {
            var destinationCell = new WaterCell(1, 2);

            ship.Pirates.Add(teamBlack.Pirates.GetNext());
            // act
            ship.MoveTo(destinationCell);

            // Assert
            ship.Pirates.Count
                .Should()
                .BeGreaterThan(1);

            ship.Cell
                .ShouldBeEqual(destinationCell);
        }

	    [Test]
	    public void AlongTheVerticalLineIfOnVertical() {
		    var blackShip = new Ship(teamBlack, new WaterCell(1,5), Ship.ShipMovement.Vertical);
            blackShip.Pirates.Add(teamBlack.Pirates.Current);

			// act
		    var cell = new WaterCell(1,6);
		    blackShip.MoveTo(cell);

			//assert
			blackShip.Cell.ShouldBeEqual(cell);
	    }

		[Test]
		public void AlongTheHorizontalLineIfOnHorizontal	()
		{
			var blackShip = new Ship(teamBlack, new WaterCell(1, 5), Ship.ShipMovement.Horizontal);
            blackShip.Pirates.Add(teamBlack.Pirates.Current);

			// act
			var cell = new WaterCell(2, 5);
			blackShip.MoveTo(cell);

			//assert
			blackShip.Cell.ShouldBeEqual(cell);
		}
	}


}	