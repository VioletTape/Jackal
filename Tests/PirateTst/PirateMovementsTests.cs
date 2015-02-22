using Core.BaseTypes;
using Core.Enums;
using NUnit.Framework;
using Tests.DSL;

namespace Tests.PirateTst {
    [TestFixture]
    public class PirateMovementsTests {
        [SetUp]
        public void Init() {
            Black.Reset();
        }

        [Test]
        public void PirateShouldBeKilledWhenPathExceed20Steps() {
            //Arrange
            var pirate = Black.Pirate;

            //Act
            for (var i = 0; i < 21; i++) {
                pirate.AddPathPoint(new Position(1, 1));
            }

            //Assert
            pirate.State.ShouldBeEqual(PlayerState.Dead);
        }

        [Test]
        public void PathCanBeCleared() {
            //Arrange
            var pirate = Black.Pirate;
            for (var i = 0; i < 15; i++) {
                pirate.AddPathPoint(new Position(1, 1));
            }

            //Act
            pirate.ClearPath();

            //Assert
            pirate.Path.ShouldBeEmpty();
        }

        [Test]
        public void PirateCanIndicateFoes() {
            //Arrange
            var black = Black.Pirate;
            var red = Red.Pirate;

            //Assert
            black.IsFriend(red).ShouldBeFalse();
        }

        [Test]
        public void PirateCanIndicateAliance() {
            //Arrange
            var black = Black.Pirate;
            var red = Red.Pirate;

            //Act
            black.Aliance = Player.Red;

            //Assert
            black.IsFriend(red).ShouldBeTrue();
        }

        [Test]
        public void PirateCanIndicateFriends() {
            //Arrange
            var black1 = Black.Pirate;
            var black2 = Black.Pirate;

            //Assert
            black1.IsFriend(black2).ShouldBeTrue();
        }
    }
}