using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using Core.BaseTypes;
using Core.Cells;
using Core.Enums;
using FluentAssertions;
using NUnit.Framework;

namespace Tests.Cells.ShipTst {
    [TestFixture]
    public class ShipCanMoveTo {
        private Ship ship;
        private WaterCell waterCell;

        [SetUp]
        public void TestInit() {
            waterCell = new WaterCell(1, 1);
            ship = new Ship(PlayerType.Black, waterCell);
        }

        [Test]
        public void OnlyWhenPirateOnShip() {
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
		    var blackShip = new Ship(PlayerType.Black, new WaterCell(1,5), Ship.ShipMovement.Vertical);

			// act
		    var cell = new WaterCell(1,6);
		    blackShip.MoveTo(cell);

			//assert
			blackShip.Cell.ShouldBeEqual(cell);
	    }

		[Test]
		public void AlongTheHorizontalLineIfOnHorizontal	()
		{
			var blackShip = new Ship(PlayerType.Black, new WaterCell(1, 5), Ship.ShipMovement.Horizontal);

			// act
			var cell = new WaterCell(2, 5);
			blackShip.MoveTo(cell);

			//assert
			blackShip.Cell.ShouldBeEqual(cell);
		}
	}


}	