using Core.Cells;
using NUnit.Framework;
using Tests.DSL;

namespace Tests.Cells.AirplaneCellTst {
    [TestFixture]
    public class AirplaneDefailtSettingsTests {
        [SetUp]
        public void Init() {
            Black.Reset();
        }


        [Test]
        public void CellShouldNotBeTerminalByDefault() {
            //Arrange
            var airplaneCell = new AirplaneCell(1, 1);

            //Assert
            airplaneCell.Terminal.ShouldBeFalse();
        }

        [Test]
        public void CellShouldNotBeActiveByDefault() {
            //Arrange
            var airplaneCell = new AirplaneCell(1, 1);

            //Assert
            airplaneCell.Active.ShouldBeTrue();
        }
    }
}