using Core.Cells;
using NUnit.Framework;

namespace Tests.Cells.GoldCellTst {
    [TestFixture]
    public class GoldCellDerrivedTests {
        [Test]
        public void GoldCellOneShouldContainOneCoin() {
            // Assert
            new GoldCellOne(1, 1).GoldCoins.ShouldBeEqual(1);
        }

        [Test]
        public void GoldCellTwoShouldContainTwoCoin() {
            // Assert
            new GoldCellTwo(1, 1).GoldCoins.ShouldBeEqual(2);
        }

        [Test]
        public void GoldCellThreeShouldContainThreeCoin() {
            // Assert
            new GoldCellThree(1, 1).GoldCoins.ShouldBeEqual(3);
        }

        [Test]
        public void GoldCellFourShouldContainFourCoin() {
            // Assert
            new GoldCellFour(1, 1).GoldCoins.ShouldBeEqual(4);
        }

        [Test]
        public void GoldCellFiveShouldContainFiveCoin() {
            // Assert
            new GoldCellFive(1, 1).GoldCoins.ShouldBeEqual(5);
        }
    }
}