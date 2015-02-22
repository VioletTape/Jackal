using System.Linq;
using Core.BaseTypes;
using Core.Cells;
using Core.Enums;
using NUnit.Framework;
using Tests.DSL;
using Tests.PirateTst;

namespace Tests.Cells.DeathCellTst {
    [TestFixture]
    public class WhenPirateComes {
        private Pirate pirate;
        private DeathCell deathCell;

        [SetUp]
        public void ClassInit() {
            Black.Reset();
            Red.Reset();
            pirate = Black.Pirate;

            deathCell = new DeathCell(2, 2);
        }

        [Test]
        public void HeShouldSetDead() {
            // Act
            deathCell.PirateComing(pirate);

            // Assert
            pirate.State.ShouldBeEqual(PlayerState.Dead);
        }

        [Test]
        public void HeMayComes() {
            // Act
            deathCell.PirateComing(pirate);

            // Assert
            deathCell.Pirates.ShouldBeEmpty();
        }

        [Test]
        public void HeShouldDie() {
            // Act
            deathCell.PirateComing(pirate);

            // Assert
            Black.Ship.Pirates.Count.ShouldBeEqual(3);
            Black.Ship.Pirates.Where(p => p.State == PlayerState.Dead).Count().ShouldBeEqual(1);
        }

        [Test]
        public void HeShouldLostGold() {
            // Arrange
            pirate.SetWithGold();

            // Act
            deathCell.PirateComing(pirate);

            // Assert
            pirate.IsWithGold().ShouldBeFalse();
        }
    }
}