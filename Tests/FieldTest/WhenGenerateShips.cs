using System.Collections;
using Core.BaseTypes;
using NUnit.Framework;
using Tests.RulesForTesting;

namespace Tests.FieldTest {
    [TestFixture]
    public class WhenGenerateShips {
        private readonly TestEmptyRules rule = new TestEmptyRules();

        private Field Field {
            get { return new Field(rule); }
        }

        public IEnumerable GetShip {
            get {
                yield return new TestCaseData(Field.CurrentPlayer.GetTeam().Ship, new Position((rule.Size - 1) / 2, 0));

                Field.GetNextPlayer();
                yield return new TestCaseData(Field.CurrentPlayer.GetTeam().Ship, new Position(0, (rule.Size - 1) / 2));

                Field.GetNextPlayer();
                yield return new TestCaseData(Field.CurrentPlayer.GetTeam().Ship, new Position((rule.Size - 1) / 2, rule.Size - 1));

                Field.GetNextPlayer();
                yield return new TestCaseData(Field.CurrentPlayer.GetTeam().Ship, new Position(rule.Size - 1, (rule.Size - 1) / 2));
            }
        }

        [Test]
        [TestCaseSource("GetShip")]
        public void ShipsShouldStartAtMiddleOfBorder(Ship ship, Position pos) {
            //Assert
            ship.Position.ShouldBeEqual(pos);
        }

        [Test]
        [TestCaseSource("GetShip")]
        public void ShipShouldContain3Pirates(Ship ship, Position pos) {
            //Assert
            ship.Pirates.Count.ShouldBeEqual(3);
        }

        [Test]
        [TestCaseSource("GetShip")]
        public void ShipShouldBeLinkedToCell(Ship ship, Position pos) {
            
            //Assert
            //            ((WaterCell) Field.Cells(pos))
            //                .Ship
            //                .ShouldBeEqual(ship);
            Assert.Fail();
        }

        [Test]
        [TestCaseSource("GetShip")]
        public void ShipShouldNotContainGold(Ship ship, Position pos) {
            //Assert
            ship.Gold.ShouldBeEqual(0);
        }
    }
}