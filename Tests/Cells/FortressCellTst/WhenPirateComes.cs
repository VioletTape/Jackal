using Core.BaseTypes;
using Core.Cells;
using Core.Enums;
using NUnit.Framework;
using Tests.Cells.BaseCell;
using Tests.DSL;

namespace Tests.Cells.FortressCellTst {
    [TestFixture]
    public class WhenPirateComes {
        private Pirate pirate;
        private FortressCell fortressCell;

        [SetUp]
        public void ClassInit() {
            Black.Reset();
            Red.Reset();
            pirate = Black.Pirate;

            fortressCell = new FortressCell(2, 2);
        }


        [Test]
        public void HeMayComes() {
            // Act
            fortressCell.PirateComing(pirate);

            // Assert
            fortressCell.Pirates.ShouldContain().Exact(pirate);
        }

        [Test]
        public void HeCanNotStayIfThereAreFoes() {
            var foe = Red.Pirate;
            fortressCell.PirateComing(foe);

            var stubCell = new StubCell();
            stubCell.AddPirate(pirate);

            // Act
            fortressCell.PirateCanComeFrom(stubCell);

            // Assert
            fortressCell.Pirates.ShouldContain().Exact(foe);
        }

        [Test]
        public void HeCanStayIfThereAreAlly() {
            var ally = Red.Pirate;
//            ally.Aliance = TeamType.Black;
//            pirate.Aliance = TeamType.Red;

            fortressCell.PirateComing(ally);

            var stubCell = new StubCell();
            stubCell.AddPirate(pirate);

            // Act
            fortressCell.PirateCanComeFrom(stubCell);
            fortressCell.PirateComing(pirate);

            // Assert
            fortressCell.Pirates.ShouldContain().Elements(ally, pirate);
        }
    }
}