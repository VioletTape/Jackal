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

      
    }
}