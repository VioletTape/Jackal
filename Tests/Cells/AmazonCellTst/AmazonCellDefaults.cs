using Core.Cells;
using Core.Enums;
using NUnit.Framework;

namespace Tests.Cells.AmazonCellTst {
    [TestFixture]
    public class AmazonCellDefaults {
        private AmazonCell fortressCell;

        [SetUp]
        public void Init() {
            fortressCell = new AmazonCell(1, 1);
        }

        [Test]
        public void ShouldBeNotDiscovered() {
            // Assert
            fortressCell.Discoverd.ShouldBeFalse();
        }

        [Test]
        public void ShouldBeTerminal() {
            // Assert
            fortressCell.Terminal.ShouldBeTrue();
        }

        [Test]
        public void ShouldBeAmazonType() {
            // Assert
            fortressCell.CellType.ShouldBeEqual(CellType.Amazon);
        }

        [Test]
        public void ShouldBeNotMultistep() {
            // Assert
            fortressCell.MultiStep.ShouldBeFalse();
        }
    }
}