using Core.BaseTypes;
using Core.Cells;
using Core.Enums;
using NUnit.Framework;
using Tests.DSL;

namespace Tests.Cells.AirplaneCellTst {
    [TestFixture]
    public class WhenPirateComes {
        private AirplaneCell airplaneCell;
        private Pirate black;

        [SetUp]
        public void Init() {
            Black.Reset();
            Red.Reset();

            airplaneCell = new AirplaneCell(4, 5);
            black = Black.Pirate;
        }


        [Test]
        public void HeCanStay() {
            //Act
            airplaneCell.PirateComing(black);

            //Assert
            airplaneCell.Pirates.ShouldContain().Exact(black);

            black.State.ShouldBeEqual(PlayerState.Free);
            black.Position.ShouldBeEqual(new Position(4, 5));
        }

        [Test]
        public void HeMayKillFoes() {
            //Arrange
            var foe = Red.Pirate;

            airplaneCell.PirateComing(foe);

            //Act
            airplaneCell.PirateComing(black);

            //Assert
            airplaneCell.Pirates.ShouldContain().Exact(black);

            Assert.That(airplaneCell.Pirates, Is.EquivalentTo(new[] {black}));
        }


        [Test]
        public void AtFirstTimeHeMayBeTransferedToShip() {
            //Arrange
            airplaneCell.PirateComing(black);

            //Act
            airplaneCell.Transfer();

            //Assert
            black.State.ShouldBeEqual(PlayerState.OnShip);

            airplaneCell.Pirates.ShouldBeEmpty();
            airplaneCell.Active.ShouldBeFalse();
        }

       
        [Test]
        public void AtSecondTimeHeCantTransferedToShip() {
            //Arrange
            airplaneCell.PirateComing(black);

            //Act
            airplaneCell.Transfer();
            airplaneCell.PirateComing(black);
            airplaneCell.Transfer();
            
            //Assert
            black.State.ShouldBeEqual(PlayerState.Free);

            airplaneCell.Pirates.ShouldContain().Exact(black);
            black.Position.ShouldBeEqual(airplaneCell.Position);
        }
    }
}