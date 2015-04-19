using System.Collections;
using Core.BaseTypes;
using Core.Cells;
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
                yield return new TestCaseData(Field.Ships[0], new Position((rule.Size - 1)/2, 0));
                yield return new TestCaseData(Field.Ships[1], new Position(0, (rule.Size - 1)/2));
                yield return new TestCaseData(Field.Ships[2], new Position((rule.Size - 1)/2, rule.Size - 1));
                yield return new TestCaseData(Field.Ships[3], new Position(rule.Size - 1, (rule.Size - 1)/2));
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
            ((WaterCell) Field.Cells(pos))
                .Ship
                .ShouldBeEqual(ship);
        }

        [Test]
        [TestCaseSource("GetShip")]
        public void ShipShouldNotContainGold(Ship ship, Position pos) {
            //Assert
            ship.Gold.ShouldBeEqual(0);
        }
    }
}