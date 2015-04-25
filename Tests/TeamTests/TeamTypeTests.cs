using Core.Enums;
using NUnit.Framework;
using Tests.RulesForTesting;

namespace Tests.TeamTests {
    [TestFixture]
    public class TeamTypeTests {
        [Test]
        public void ItemsShoulStartFromMinusOne() {
            //assert
            ((int) TeamType.None).ShouldBeEqual(-1);
        }

        [Test]
        public void ShouldDetectAliance() {
            // arrange
            var player1 = new Player(TeamType.Black, TeamType.Red, new TestEmptyRules());
            var team1 = player1.GetNextTeam();
            var team2 = player1.GetNextTeam();

            var player2 = new Player(TeamType.White, TeamType.Yellow, new TestEmptyRules());
            var team3 = player2.GetNextTeam();

            //assert
            team2.IsInAlianceWith(team1)
                .ShouldBeTrue();

            team3.IsInAlianceWith(team1)
                .ShouldBeFalse();
        }

        [Test]
        public void ShouldBeInAlianceWithItself() {
            var player = new Player(TeamType.Black, new TestEmptyRules());
            var team = player.GetNextTeam();

            //assert
            team.IsInAlianceWith(team)
                .ShouldBeTrue();
        }
    }
}