using Core.BaseTypes;
using Core.Cells;
using Core.Enums;
using NUnit.Framework;

namespace Tests.Cells.ShipTst {
    [TestFixture]
    public class ShipEqualityTests {
        [SetUp]
        public void TestInit() {}

        [Test]
        public void ShipNotEqualToNull() {
            // Assert
            new Ship(TeamType.Black, new WaterCell(1, 1))
                .Equals(null)
                .ShouldBeFalse();
        }

        [Test]
        public void ShipEqualToItself() {
            // Assert
            var ship = new Ship(TeamType.Black, new WaterCell(1, 1));
            ship
                .Equals(ship)
                .ShouldBeTrue();
        }

        [Test]
        public void HashCodeShouldBeEqualToPlayerHashCode() {
            var ship = new Ship(TeamType.Black, new WaterCell(1, 1));
            
            ship.GetHashCode()
                .ShouldBeEqual(TeamType.Black.GetHashCode());
        }
    }
}