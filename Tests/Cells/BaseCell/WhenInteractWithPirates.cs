using Core.BaseTypes;
using Core.Enums;
using NUnit.Framework;
using Tests.DSL;

namespace Tests.Cells.BaseCell {
    [TestFixture]
    public class WhenInteractWithPirates {
        private Pirate pirate;
        private StubCell stubCell;

        [SetUp]
        public void Init() {
            pirate = Black.Pirate;
            stubCell = new StubCell();
        }

        [Test]
        public void HeCanBeAddedToCell() {
            //Act
            stubCell.PirateComing(pirate);

            //Assert
            stubCell.Pirates.ShouldContain().Exact(pirate);
        }

        [Test]
        public void HeCanBeRemovedFromCell() {
            //Arrange
            stubCell.PirateComing(pirate);

            //Act
            stubCell.PirateWent(pirate);

            //Assert
            stubCell.Pirates.ShouldBeEmpty();
        }

        [Test]
        public void ShouldBeAbleGetOwnPirate() {
            //Arrange
            stubCell.PirateComing(pirate);

            //Act
            var pirateForPlayer = stubCell.GetPirateForPlayer(PlayerType.Black);

            //Assert
            pirateForPlayer.ShouldBeEqual(pirate);
        }

        [Test]
        public void ShouldNotBeAbleGetOtherPirate() {
            //Arrange
            stubCell.PirateComing(pirate);

            //Act
            var pirateForPlayer = stubCell.GetPirateForPlayer(PlayerType.Red);

            //Assert
            pirateForPlayer.ShouldBeNull();
        }

        [Test]
        public void ShouldAbleKillAllOtherPiratesWhenComing() {
            //Arrange
            stubCell.PirateComing(pirate);

            //Act
            stubCell.PirateComing(Red.Pirate);

            //Assert
            stubCell.Pirates.ShouldContain().Exact(Red.Pirate);
        }


    }
}