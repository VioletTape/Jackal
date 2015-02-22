using Core.BaseTypes;
using Core.Enums;
using NUnit.Framework;
using Tests.DSL;

namespace Tests.PirateTst {
    [TestFixture]
    public class PirateActionTests {
        [SetUp]
        public void Init() {
            Black.Reset();
        }

        [Test]
        public void PathCannotBeModifiedDirectly() {
            //Arrange
            var pirate = Black.Pirate;

            //Assert
            pirate.Path.ShouldBeReadonlyCollection();
        }

        [Test]
        public void DefaultStateShouldBeOnShip() {
            //Arrange
            var pirate = Black.Pirate;

            //Assert
            pirate.State.ShouldBeEqual(PlayerState.OnShip);
        }


        [Test]
        public void ActionFreeShouldSetPirateFree() {
            //Arrange
            var pirate = Black.Pirate;

            //Act
            pirate.Free();

            //Assert
            pirate.State.ShouldBeEqual(PlayerState.Free);
        }

        [Test]
        public void ActionTrapShouldSetPirateTrapped() {
            //Arrange
            var pirate = Black.Pirate;

            //Act
            pirate.Trap();

            //Assert
            pirate.State.ShouldBeEqual(PlayerState.Trapped);
        }

        [Test]
        public void ActionKillShouldSetPirateDead() {
            //Arrange
            var pirate = Black.Pirate;

            //Act
            pirate.Kill();

            //Assert
            pirate.State.ShouldBeEqual(PlayerState.Dead);
        }

        [Test]
        public void ActionSwimShouldSetPirateSwimming() {
            //Arrange
            var pirate = Black.Pirate;

            //Act
            pirate.Swim();

            //Assert
            pirate.State.ShouldBeEqual(PlayerState.Swimming);
        }

        [Test]
        public void ActionOnShipShouldSetPirateOnShip() {
            //Arrange
            var pirate = Black.Pirate;
            pirate.Free();
            pirate.Position = new Position(2,2);

            //Act
            pirate.Ship();

            //Assert
            pirate.State.ShouldBeEqual(PlayerState.OnShip);
        }

        [Test]
        public void ActionSurrenderShouldSetPirateOnShip() {
            //Arrange
            var pirate = Black.Pirate;
            pirate.Free();
            pirate.Position = new Position(2,2);

            //Act
            pirate.Surrender();

            //Assert
            pirate.State.ShouldBeEqual(PlayerState.OnShip);
        }
    }
}
















