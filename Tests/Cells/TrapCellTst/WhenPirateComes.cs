using Core.BaseTypes;
using Core.Cells;
using Core.Enums;
using NUnit.Framework;
using Tests.DSL;

namespace Tests.Cells.TrapCellTst {
    [TestFixture]
    public class WhenPirateComes {
        private Pirate pirate;
        private Pirate pirate2;
        private TrapCell trapCell;

        [SetUp]
        public void TestInit() {
            Black.Reset();
            pirate = Black.Pirate;
            pirate2 = Black.Pirate2;

            trapCell = new TrapCell(1, 1);
        }

        [Test]
        public void HeCanCome() {
            // Act
            trapCell.PirateComing(pirate);

            // Assert
            trapCell.Pirates.ShouldContain().Exact(pirate);
        }

        [Test]
        public void HeCanNotLeftCellByHimself() {
            // Arrange
            trapCell.PirateComing(pirate);

            // Act
            trapCell.PirateWent(pirate);

            // Assert
            trapCell.Pirates.ShouldContain().Exact(pirate);
        }

        [Test]
        public void HeShouldBeTrapped() {
            // Act
            trapCell.PirateComing(pirate);

            // Assert
            pirate.State.ShouldBeEqual(PlayerState.Trapped);
        }

        [Test]
        public void HeCanSaveTrappedFriends() {
            // Arrange
            trapCell.PirateComing(pirate);

            // Act
            trapCell.PirateComing(pirate2);

            // Assert
            trapCell.Pirates.ShouldContain().Elements(pirate, pirate2);
            pirate.State.ShouldBeEqual(PlayerState.Free);
            pirate2.State.ShouldBeEqual(PlayerState.Free);
        }

         [Test]
        public void HeCanSaveTrappedAlly() {
            // Arrange
             var pirate1 = Red.Pirate;
//             pirate1.Aliance = TeamType.Black;
//             pirate2.Aliance = TeamType.Red;
             trapCell.PirateComing(pirate1);

            // Act
            trapCell.PirateComing(pirate2);

            // Assert
            trapCell.Pirates.ShouldContain().Elements(pirate1, pirate2);
            pirate1.State.ShouldBeEqual(PlayerState.Free);
            pirate2.State.ShouldBeEqual(PlayerState.Free);
        }
    }
}