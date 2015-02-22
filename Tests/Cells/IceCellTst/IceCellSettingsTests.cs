using Core.Cells;
using Core.Enums;
using NUnit.Framework;

namespace Tests.Cells.IceCellTst {
    [TestFixture]
    public class IceCellSettingsTests {
        private IceCell iceCell;

        [SetUp]
        public void TestInit() {
            iceCell = new IceCell(1, 1);
        }

        [Test]
        public void ShouldBeTypeOfIce() {
            // Assert
            iceCell.CellType.ShouldBeEqual(CellType.Ice);
        }

        [Test]
        public void ShouldNotBeTerminal() {
            // Assert
            iceCell.Terminal.ShouldBeFalse();
        }

         [Test]
        public void ShouldBeNotMultistep() {
            // Assert
            iceCell.MultiStep.ShouldBeFalse();
        }
    }
}