using System.Linq;
using Core.BaseTypes;
using Core.Cells;
using Core.Enums;
using NUnit.Framework;
using Tests.PirateTst;
using Tests.RulesForTesting;

namespace Tests.Cells.WaterCellTst {
    [TestFixture]
    public class WaterCellPirateInteractions {
        private TestEmptyRules rule;
        private FieldStub field;
        private Team team;

        [SetUp]
        public void TestInit() {
            rule = new TestEmptyRules();
            field = new FieldStub(rule);
            field.GeneratePlayers(rule);

            team = field.CurrentPlayer.CurrentTeam;
            team.Ship.SetStrategy();
        }

        [Test]
        public void WhenPirateComeHeShouldLostGold() {
            //Arrange
            var pirate = team.Pirates.Current;

            pirate.SetWithGold();
            var waterCell = field.Cells(1, 1);

            //Act
            waterCell.PirateComing(pirate);

            //Assert
            pirate.IsWithGold()
                  .ShouldBeFalse();
        }

        [Test]
        public void PirateShouldNotLostGoldIfThereIsShip() {
            //Arrange
            var pirate = team.Pirates.Current;
            pirate.SetWithGold();

            var waterCell = (WaterCell) field.Cells(1, 1);
            team.Ship.MoveTo(waterCell);

            //Act
            waterCell.PirateComing(pirate);

            //Assert
            team.Ship.Pirates.First().IsWithGold().ShouldBeFalse();
            team.Ship.Gold.ShouldBeEqual(1);
        }

        [Test]
        public void PirateCanNotJumpInWaterFromShip() {
            //Arrange
            var pirate = team.Pirates.Current;
            team.Ship.Pirates.Add(pirate);


            var waterCell = (WaterCell) field.Cells(1, 1);
            team.Ship.MoveTo(waterCell);


            //Act
            var tmp = field.Cells(1, 2).PirateCanComeFrom(waterCell);

            //Assert
            tmp.ShouldBeFalse();
            field.Cells(1, 2).Pirates.Count
                 .ShouldBeEqual(0);
        }

        [Test]
        public void PirateCanMoveFromWaterToWaterCell() {
            // arrange
            var pirate = team.Pirates.Current;
            var cells = (WaterCell)field.Cells(1,1);
            cells.AddPirate(pirate);

            // act
            var targetCell = field.Cells(1, 2);
            field.MovePirateTo(pirate, targetCell);

            // assert
            cells.Pirates.Count
                .ShouldBeEqual(0);
            targetCell.Pirates.Count
                .ShouldBeEqual(1);
        }
    }
}