using Core.Cells;
using Core.Enums;
using NUnit.Framework;

namespace Tests.Cells.TrapCellTst {
    [TestFixture]
    public class TrapCellDefaultsTests {
        private TrapCell trapCell;

        [SetUp]
        public void TestInit() {
            trapCell = new TrapCell(1,1);
        }

        [Test]
        public void ShouldBeTerminal() {
            // Assert
            trapCell.Terminal.ShouldBeTrue();
        }

        [Test]
        public void ShouldNotBeDiscovered() {
            // Assert
            trapCell.Discoverd.ShouldBeFalse();
        }

        [Test]
        public void ShouldBeTrapType() {
            // Assert
            trapCell.CellType.ShouldBeEqual(CellType.Trap);
        }

        [Test]
        public void ShouldNotBeMultiStep() {
            // Assert
            trapCell.MultiStep.ShouldBeFalse();
        }
    }
}