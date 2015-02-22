using Core.Cells;
using Core.Enums;
using NUnit.Framework;

namespace Tests.Cells.CannonCellTst {
    [TestFixture]
    public class CannonCellDefaultsTests {
         private CannonCell cannonCell;

        [SetUp]
        public void TestInit() {
            cannonCell = new CannonCell(1, 1);
        }

        [Test]
        public void ShouldBeOfCannonType() {
            // Assert
            cannonCell.CellType.ShouldBeEqual(CellType.Cannon);
        }

        [Test]
        public void ShouldNotBeDiscovered() {
            // Assert
            cannonCell.Discoverd.ShouldBeFalse();
        }

        [Test]
        public void ShouldNotBeTerminal() {
            // Assert
            cannonCell.Terminal.ShouldBeFalse();
        }

        [Test]
        public void ShouldNotBeMultistep() {
            // Assert
            cannonCell.MultiStep.ShouldBeFalse();
        }
    }
}