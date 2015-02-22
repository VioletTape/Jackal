using Core.BaseTypes;
using Core.Cells;
using NUnit.Framework;
using Tests.Cells.BaseCell;
using Tests.DSL;

namespace Tests.Cells.BaloonCellTst {
    [TestFixture]
    public class WhenPirateComes {
        private BaloonCell baloonCell;
        private Pirate black;

        [SetUp]
        public void Init() {
            Black.Reset();
            Red.Reset();

            baloonCell = new BaloonCell(4, 5);
            black = Black.Pirate;
        }


        [Test]
        public void HeShouldBeTransferedToShip() {
            //Arrange
            var stubCell = new StubCell(4, 4);
            stubCell.PirateComing(black);
            black.Position.ShouldBeEqual(stubCell.Position);

            //Act
            baloonCell.PirateComing(black);

            //Assert
            baloonCell.Pirates.ShouldBeEmpty();
            black.Position.ShouldBeEqual(Black.Ship.Position);
        }
    }
}