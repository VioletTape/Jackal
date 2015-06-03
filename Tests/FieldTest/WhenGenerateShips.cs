using System.Collections;
using System.ComponentModel;
using System.Resources;
using Core.BaseTypes;
using NUnit.Framework;
using Tests.RulesForTesting;

namespace Tests.FieldTest {
    [TestFixture]
    public class WhenGenerateShips {
        private class Foo {
            private static readonly TestEmptyRules Rule = new TestEmptyRules();
            public static Field Field = new Field(new TestEmptyRules());

            public static IEnumerable GetShip {
                get {
                    yield return new TestCaseData(Field.CurrentPlayer.CurrentTeam.Ship, new Position((Rule.Size - 1) / 2, 0));

                    Field.GetNextPlayer();
                    yield return new TestCaseData(Field.CurrentPlayer.CurrentTeam.Ship, new Position(0, (Rule.Size - 1) / 2));

                    Field.GetNextPlayer();
                    yield return new TestCaseData(Field.CurrentPlayer.CurrentTeam.Ship, new Position((Rule.Size - 1) / 2, Rule.Size - 1));

                    Field.GetNextPlayer();
                    yield return new TestCaseData(Field.CurrentPlayer.CurrentTeam.Ship, new Position(Rule.Size - 1, (Rule.Size - 1) / 2));

                    Field = new Field(Rule);
                }
            }
        }


        [Test]
        [TestCaseSource(typeof(Foo),"GetShip")]
        public void ShipsShouldStartAtMiddleOfBorder(Ship ship, Position pos) {
            //Assert
            ship.Position.ShouldBeEqual(pos);
        }

        [Test]
        [TestCaseSource(typeof(Foo),"GetShip")]
        public void ShipShouldContain3Pirates(Ship ship, Position pos) {
            //Assert
            ship.Pirates.Count.ShouldBeEqual(3);
        }

        [Test]
        [TestCaseSource(typeof(Foo),"GetShip")]
        public void ShipShouldBeLinkedToCell(Ship ship, Position pos) {
            //Assert
            var cells = Foo.Field.Cells(pos);
            cells.Equals(ship.Cell)
                 .ShouldBeTrue();
        }
    }
}