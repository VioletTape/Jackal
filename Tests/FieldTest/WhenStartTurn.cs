using System.Linq;
using Core.BaseTypes;
using NUnit.Framework;
using Tests.RulesForTesting;

namespace Tests.FieldTest {
    [TestFixture]
    public class WhenStartTurn {
        private GreenField field;

        [SetUp]
        public void TestInit() {
            field = new GreenField();
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