using Core.BaseTypes;
using Core.Cells;
using Core.Enums;
using FluentAssertions;
using NUnit.Framework;

namespace Tests.Cells.ShipTst {
    [TestFixture]
    public class ShipCanMoveTo {
        private Ship ship;

        [SetUp]
        public void TestInit() {
            ship = new Ship(Player.Black, new WaterCell(1, 1));
        }

        [Test]
        public void OnlyWhenPirateOnShip() {
            var cell = new WaterCell(1,2);

            // act
            ship.MovedTo(cell);

            // Assert
            ship.Pirates.Count
                .Should()
                .BeGreaterOrEqualTo(1);

            ship.Cell
                .ShouldBeEqual(cell);
        }
    }
}