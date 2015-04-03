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
            ship = new Ship(Player.Black, waterCell);
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

//        public static IEnumerable<TestCaseData> CellProvider() {
//            var values = (IList) Enum.GetValues(typeof (CellType));
//            for (var i = 0; i < values.Count; i++) {
//                var cellType = (CellType) values[i];
//                var cell = CellFactory.Create(cellType, 1, 1);
//                if (cellType == CellType.Water) {
//                    yield return new TestCaseData(cell, true);
//                }
//                else {
//                    yield return new TestCaseData(cell, false);
//                }
//            }
//        }
//
//        [Test]
//        [TestCaseSource("CellProvider")]
//        public void OnlyOtherWaterCell(Cell cell, bool isValid) {
//            // act
//            ship.MoveTo(cell);
//
//            // Assert
//            if (isValid)
//                ship.Cell
//                    .ShouldBeEqual(cell);
//            else {
//                ship.Cell.ShouldBeEqual(waterCell);
//            }
//        }

	    [Test]
	    public void AlongTheVerticalLineIfOnVertical() {
		    var blackShip = new Ship(Player.Black, new WaterCell(1,5), Ship.ShipMovement.Vertical);

			// act
		    var cell = new WaterCell(1,6);
		    blackShip.MoveTo(cell);

			//assert
			blackShip.Cell.ShouldBeEqual(cell);
	    }

		[Test]
		public void AlongTheHorizontalLineIfOnHorizontal	()
		{
			var blackShip = new Ship(Player.Black, new WaterCell(1, 5), Ship.ShipMovement.Horizontal);

			// act
			var cell = new WaterCell(2, 5);
			blackShip.MoveTo(cell);

			//assert
			blackShip.Cell.ShouldBeEqual(cell);
		}
	}


}	