using Core.BaseTypes;
using Core.Enums;
using NUnit.Framework;
using Tests.RulesForTesting;

namespace Tests.TeamTests {
    [TestFixture]
    public class WhenCreateTeam  {
        private Field field;
        private TestRules rule;

        [SetUp]
        public void Init() {
            rule = new TestRules();
        }

        [Test]
        public void TeamTypesShouldBePassed() {
            // act
            var team = new Team(TeamType.Black, rule);

            // Assert
            team.Type.ShouldBeEqual(TeamType.Black);
        }

        [Test]
        public void ShouldCreatePiratesTeam() {
            // act
            var team = new Team(TeamType.Black, rule);
   
            // Assert
            team.Pirates.Count.ShouldBeEqual(3);
        }

        [Test]
        public void ShouldCreateShip() {
            // act
            var team = new Team(TeamType.Black, rule);

            // Assert
            team.Ship.ShouldBeNotNull();
            team.Ship.TeamType = TeamType.Black;
            
        }
    }
}