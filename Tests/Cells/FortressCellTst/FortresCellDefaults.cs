using Core.Cells;
using Core.Enums;
using NUnit.Framework;

namespace Tests.Cells.FortressCellTst {
    [TestFixture]
    public class FortresCellDefaults {
        private FortressCell fortressCell;

        [SetUp]
        public void Init() {
            fortressCell = new FortressCell(1, 1);
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
        public void ShouldBeFortresType() {
            // Assert
            fortressCell.CellType.ShouldBeEqual(CellType.Fortress);
        }

         [Test]
        public void ShouldBeNotMultistep() {
            // Assert
            fortressCell.MultiStep.ShouldBeFalse();
        }
    }
}