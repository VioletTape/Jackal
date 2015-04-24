using System.Linq;
using Core.BaseTypes;
using Core.Enums;
using FluentAssertions;
using NUnit.Framework;
using Tests.RulesForTesting;

namespace Tests.TeamTests {
    [TestFixture]
    public class WhenCreateTeam {
        private Field field;
        private TestRules rule;

        [SetUp]
        public void Init() {
            rule = new TestRules();
        }

        [Test]
        public void TeamTypesShouldBeProcessed() {
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
            team.Pirates.Select(i => i.TeamType)
                .Distinct()
                .ShouldBeEquivalentTo(new[] {
                                                TeamType.Black
                                            });
        }

        [Test]
        public void ShouldCreateShip() {
            // act
            var team = new Team(TeamType.Black, rule);

            // Assert
            team.Ship.ShouldBeNotNull();
            team.Ship.TeamType.ShouldBeEqual(TeamType.Black);
        }

        [Test]
        public void BlackTeamShoudBeOnWest() {
            //act
            var team = new Team(TeamType.Black, rule);

            //assert
            team.Ship.Position.ShouldBeEqual(new Position(rule.Size / 2, 0));
        }

        [Test]
        public void WhiteTeamShoudBeOnNorth() {
            //act
            var team = new Team(TeamType.White, rule);

            //assert
            team.Ship.Position.ShouldBeEqual(new Position(0, rule.Size / 2));
        }

        [Test]
        public void YellowTeamShoudBeOnEast() {
            //act
            var team = new Team(TeamType.Yellow, rule);

            //assert
            team.Ship.Position.ShouldBeEqual(new Position(rule.Size / 2, rule.Size - 1));
        }

        [Test]
        public void RedTeamShoudBeOnSouth() {
            //act
            var team = new Team(TeamType.Red, rule);

            //assert
            team.Ship.Position.ShouldBeEqual(new Position(rule.Size - 1, rule.Size / 2));
        }

        [Test]
        public void ShipShouldContainPirates() {
            var team = new Team(TeamType.Black, rule);

            team.Ship.Pirates.Count.ShouldBeEqual(3);
        }
    }
}