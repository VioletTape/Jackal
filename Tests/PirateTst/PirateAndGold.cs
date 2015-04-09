using Core.BaseTypes;
using NUnit.Framework;
using Tests.DSL;

namespace Tests.PirateTst {
    [TestFixture]
    public class PirateAndGold {
        [SetUp]
        public void Init() {
            Black.Reset();
        }

        [Test]
        public void PirateMayAccrueGoldIfHeEmpty() {
            //Arrange
            var pirate = Black.Pirate;
            pirate.IsWithGold().ShouldBeFalse();

            //Act
            var accrued = pirate.AccureGold();

            //Assert
            pirate.IsWithGold().ShouldBeTrue();
            accrued.ShouldBeTrue();
        }

        [Test]
        public void PirateMayLostGold() {
            //Arrange
            var pirate = Black.Pirate;
            pirate.SetWithGold();

            //Act
            pirate.LostGold();

            //Assert
            pirate.IsWithGold().ShouldBeFalse();
        }


        [Test]
        public void PirateShoulnNotAccrueGoldIfWithGold() {
            //Arrange
            var pirate = Black.Pirate;
            pirate.SetWithGold();

            //Act
            var accrued = pirate.AccureGold();

            //Assert
            pirate.IsWithGold().ShouldBeTrue();
            accrued.ShouldBeFalse();
        }

        [Test]
        public void PirateShouldLostGoldIfHeSurrender() {
            //Arrange
            var pirate = Black.Pirate;
            pirate.SetWithGold();
            pirate.Position = new Position(2, 2);

            //Act
            pirate.Surrender();

            //Assert
            pirate.IsWithGold().ShouldBeFalse();
            Black.Ship.Gold.ShouldBeEqual(0);
        }

        [Test]
        public void PirateShouldLostGoldIfHeSwim() {
            //Arrange
            var pirate = Black.Pirate;
            pirate.SetWithGold();
            pirate.Position = new Position(2, 2);

            //Act
            pirate.Swim();

            //Assert
            pirate.IsWithGold().ShouldBeFalse();
            Black.Ship.Gold.ShouldBeEqual(0);
        }

        [Test]
        public void PirateShouldLostGoldIfHeKilled() {
            //Arrange
            var pirate = Black.Pirate;
            pirate.SetWithGold();
            pirate.Position = new Position(2, 2);

            //Act
            pirate.Kill();

            //Assert
            pirate.IsWithGold().ShouldBeFalse();
            Black.Ship.Gold.ShouldBeEqual(0);
        }

        [Test]
        public void PirateShouldLostGoldIfHeOnShip() {
            //Arrange
            var pirate = Black.Pirate;
            pirate.SetWithGold();
            pirate.Position = new Position(2, 2);

            //Act
            pirate.Ship();

            //Assert
            pirate.IsWithGold().ShouldBeFalse();
            Black.Ship.Gold.ShouldBeEqual(1);
        }

    }
}