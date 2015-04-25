using System.Linq;
using Core.BaseTypes;
using NUnit.Framework;
using Tests.RulesForTesting;

namespace Tests.FieldTest {
    [TestFixture]
    public class WhenStartTurn {
        private Field field;

        [SetUp]
        public void TestInit() {
            field = new Field(new TestEmptyRules());
        }

        [Test]
        public void AllPiratesShouldBeActive() {
            // act 
            field.GetNextPlayer();
            // Assert
            field.CurrentPlayer.CurrentTeam.Ship.Pirates
                .All(p => !p.IsTurnEnded)
                .ShouldBeTrue();
        }
    }
}