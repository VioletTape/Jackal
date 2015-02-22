using Core.Cells;
using Core.Enums;
using NUnit.Framework;

namespace Tests.Cells.Arrow1CellTst {
    [TestFixture]
    public class Arrow1CellDefaultsTests {
         private ArrowOneWayStraightCell arrowCell;

        [SetUp]
        public void TestInit() {
            arrowCell = new ArrowOneWayStraightCell(1, 1);
        }

        [Test]
        public void ShouldBeOfCrocoType() {
            // Assert
            arrowCell.CellType.ShouldBeEqual(CellType.ArrowOneWayS);
        }

        [Test]
        public void ShouldNotBeDiscovered() {
            // Assert
            arrowCell.Discoverd.ShouldBeFalse();
        }

        [Test]
        public void ShouldNotBeTerminal() {
            // Assert
            arrowCell.Terminal.ShouldBeFalse();
        }

        [Test]
        public void ShouldNotBeMultistep() {
            // Assert
            arrowCell.MultiStep.ShouldBeFalse();
        }
    }
}