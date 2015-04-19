using Core.BaseTypes;
using Core.Cells;
using Core.Enums;
using NUnit.Framework;
using Tests.RulesForTesting;

namespace Tests.Cells.ShipTst {
    [TestFixture]
    public class ShipEqualityTests {
        private Team team;

        [SetUp]
        public void TestInit() {
            team = new Team(TeamType.Black, new TestEmptyRules(4));
        }

        [Test]
        public void ShipNotEqualToNull() {

            // Assert
            new Ship(team, new WaterCell(1, 1))
                .Equals(null)
                .ShouldBeFalse();
        }

        [Test]
        public void ShipEqualToItself() {
            // Assert
            var ship = new Ship(team, new WaterCell(1, 1));
            ship
                .Equals(ship)
                .ShouldBeTrue();
        }

        [Test]
        public void HashCodeShouldBeEqualToPlayerHashCode() {
            var ship = new Ship(team, new WaterCell(1, 1));
            
            ship.GetHashCode()
                .ShouldBeEqual(TeamType.Black.GetHashCode());
        }
    }
}