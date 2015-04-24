using Core;
using Core.BaseTypes;
using Core.Cells;
using Core.Enums;
using NUnit.Framework;
using Tests.RulesForTesting;

namespace Tests.Cells.ShipTst {
    [TestFixture]
    public class WhenCreateShip {
        private Ship ship;

        [SetUp]
        public void TestInit() {
            ship = new Ship(new Team(TeamType.Black, new TestEmptyRules()), (WaterCell)CellFactory.Create(CellType.Water, 1, 1));
        }

        [Test]
        public void ShouldSetGoldToZero() {
            // Assert
            ship.Gold
                .ShouldBeEqual(0);
        }

        [Test]
        public void ShouldSetProperTeamType() {
            ship.TeamType
                .ShouldBeEqual(TeamType.Black);
        }

        [Test]
        public void ShouldSetCellInfo() {
            ship.Cell
                .ShouldBeNotNull();
        }

        [Test]
        public void ShouldNotContainPirates() {
             ship.Pirates
                 .ShouldBeEmpty();
        }
    }
}