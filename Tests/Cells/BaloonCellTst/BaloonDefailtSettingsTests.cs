using Core.Cells;
using Core.Enums;
using NUnit.Framework;
using Tests.DSL;

namespace Tests.Cells.BaloonCellTst {
    [TestFixture]
    public class BaloonDefailtSettingsTests {
        private BaloonCell airplaneCell;

        [SetUp]
        public void Init() {
            Black.Reset();

            airplaneCell = new BaloonCell(1, 1);
        }

        [Test]
        public void CellShouldNotBeTerminalByDefault() {
            //Assert
            airplaneCell.Terminal.ShouldBeFalse();
        }

        [Test]
        public void CellTypeShouldBeBaloon() {
            //Assert
            airplaneCell.CellType.ShouldBeEqual(CellType.Baloon);
        }

        [Test]
        public void ShouldNotBeDiscovered() {
            //Assert
            airplaneCell.Discoverd.ShouldBeFalse();
        }
    }
}