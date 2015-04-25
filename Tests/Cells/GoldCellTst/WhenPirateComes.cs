using Core.BaseTypes;
using Core.Cells;
using Core.Enums;
using NUnit.Framework;
using Tests.DSL;
using Tests.PirateTst;

namespace Tests.Cells.GoldCellTst {
    [TestFixture]
    public class WhenPirateComes {
        private Pirate pirate;
        private GoldCellOne goldCellOne;

        [SetUp]
        public void TestInit() {
            Black.Reset();
            Red.Reset();
            pirate = Black.Pirate;

            goldCellOne = new GoldCellOne(2, 2);
        }

        [Test]
        public void HeMayStay() {
            // Act
            goldCellOne.PirateComing(pirate);

            // Assert
            goldCellOne.Pirates.ShouldContain().Exact(pirate);
        }

        [Test]
        public void HeShouldBeAbleToGetGold() {
            // Arrange
            goldCellOne.PirateComing(pirate);

            // Act
            goldCellOne.GiveGoldToPirate(pirate);

            // Assert
            pirate.IsWithGold().ShouldBeTrue();
        }

        [Test]
        public void GoldCellOneShouldContainOneCoin() {
            // Assert
            goldCellOne.GoldCoins.ShouldBeEqual(1);
        }
    }
}