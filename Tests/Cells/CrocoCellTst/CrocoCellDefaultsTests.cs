using Core.Cells;
using Core.Enums;
using NUnit.Framework;

namespace Tests.Cells.CrocoCellTst {
    [TestFixture]
    public class CrocoCellDefaultsTests {
        private CrocoCell crocoCell;

        [SetUp]
        public void TestInit() {
            crocoCell = new CrocoCell(1, 1);
        }

        [Test]
        public void ShouldBeOfCrocoType() {
            // Assert
            crocoCell.CellType.ShouldBeEqual(CellType.Croco);
        }

        [Test]
        public void ShouldNotBeDiscovered() {
            // Assert
            crocoCell.Discoverd.ShouldBeFalse();
        }

        [Test]
        public void ShouldNotBeTerminal() {
            // Assert
            crocoCell.Terminal.ShouldBeFalse();
        }

        [Test]
        public void ShouldNotBeMultistep() {
            // Assert
            crocoCell.MultiStep.ShouldBeFalse();
        }


    }
}