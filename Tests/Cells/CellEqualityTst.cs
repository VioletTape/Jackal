using Core.BaseTypes;
using Core.Cells;
using FluentAssertions;
using NUnit.Framework;

namespace Tests.Cells {
    [TestFixture]
    public class CellEqualityTst {
        [SetUp]
        public void TestInit() {}

        [Test]
        public void CellsEqualByPostition() {
            var cell1 = new WaterCell(1, 1);
            var cell2 = new WaterCell(1, 1);
            // Assert
            cell1.Equals(cell2).Should().BeTrue();
        }

        [Test]
        public void CellsEqualByPostition1() {
            var cell1 = new WaterCell(1, 1);
            var cell2 = new WaterCell(1, 1);
            // Assert
            (cell1 == cell2).Should().BeTrue();
        }

        [Test]
        public void CellsEqualByType() {
            var cell1 = new WaterCell(1, 1);
            var cell2 = new WaterCell(1, 1);
            var cell3 = new GrassCell(1, 1);
            // Assert
            (cell1 == cell2).Should().BeTrue();
            (cell1 == cell3).Should().BeFalse();
        }
    }
}