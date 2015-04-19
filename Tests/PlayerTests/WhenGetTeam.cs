using System.Collections.Generic;
using Core.Enums;
using FluentAssertions;
using NUnit.Framework;
using Tests.RulesForTesting;

namespace Tests.PlayerTests {
    [TestFixture]
    public class WhenGetTeam {
        [SetUp]
        public void TestInit() {}

        [Test]
        public void WithOneItemItShouldReturnTheSameAllTheTime() {
            // arrange
            var player = new Player(TeamType.Black, new TestRules());

            // act
            var result = new List<Team> {
                                            player.GetTeam(),
                                            player.GetTeam()
                                        };

            // assert
            result[0].ShouldBeEqual(result[1]);
        }

        [Test]
        public void WithTwoItemsItShouldReturnItemsInCycle() {
            // arrange
            var player = new Player(TeamType.Black, TeamType.Red, new TestRules());

            // act
            var result = new List<Team> {
                                            player.GetTeam(),
                                            player.GetTeam(),
                                            player.GetTeam(),
                                            player.GetTeam()
                                        };

            // assert
            result[0].ShouldBeEqual(result[2]);
            result[1].ShouldBeEqual(result[3]);
            result[0].Should().NotBe(result[1]);
        }

        [Test]
        public void PlayerShouldBeAttachedToTeam() {
            var player = new Player(TeamType.Black, new TestRules());
            var team = player.GetTeam();

            //assert 
            team.Player.ShouldBeNotNull();
            team.Player.ShouldBeEqual(player);
        }
    }
}