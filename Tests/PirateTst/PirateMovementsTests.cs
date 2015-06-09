using Core.BaseTypes;
using Core.Cells;
using Core.Enums;
using FluentAssertions;
using NUnit.Framework;
using Tests.DSL;

namespace Tests.PirateTst {
    [TestFixture]
    public class PirateMovementsTests {
        [SetUp]
        public void Init() {
            Black.Reset();
        }

        [Test]
        public void PirateShouldBeKilledWhenPathExceed20Steps() {
            //Arrange
            var pirate = Black.Pirate;

            //Act
            for (var i = 0; i < 21; i++) {
                pirate.AddPathPoint(new Position(1, 1));
            }

            //Assert
            pirate.State.ShouldBeEqual(PlayerState.Dead);
        }

        [Test]
        public void PathShouldBeClearedAtTheStartOfTurn() {
            //Arrange
            var pirate = Black.Pirate;
            for (var i = 0; i < 15; i++) {
                pirate.AddPathPoint(new Position(1, 1));
            }


            //Act
            pirate.StartTurn();

            //Assert
            pirate.Path.
                ShouldBeEquivalentTo(new[] {new Position(0, 6)});
        }

        [Test]
        public void PathShouldNotBeClearedAtTheEndOfTurn() {
            //Arrange
            var pirate = Black.Pirate;
            for (var i = 0; i < 15; i++) {
                pirate.AddPathPoint(new Position(1, 1));
            }


            //Act
            pirate.EndTurn();

            //Assert
            pirate.Path.Count.ShouldBeEqual(15);
        }

        [Test]
        public void PirateCanMoveOnlyFromWaterToWater() {
            //Arrange
            var field = new GreenField();
            var pirate = field.CurrentPirate;
            pirate.Position = new Position(0,0);

            var waterCell = new WaterCell(1,0);
            field.InsertCell(waterCell);

            //Act
            field.MovePirateTo(pirate, waterCell);

            //Assert
            pirate.Position.ShouldBeEqual(waterCell.Position);
        }
    }
}