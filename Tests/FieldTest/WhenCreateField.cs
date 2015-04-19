using System.Collections.Generic;
using System.Linq;
using Core.BaseTypes;
using Core.Cells;
using Core.Enums;
using Core.Extensions;
using NUnit.Framework;
using Tests.DSL;
using Tests.RulesForTesting;

namespace Tests.FieldTest {
    [TestFixture]
    public class WhenCreateField {
        private Field field;
        private TestEmptyRules rule;

        [TestFixtureSetUp]
        public void ClassInit() {
            //Arrange 
            rule = new TestEmptyRules();
            field = new Field(rule);
        }

        [Test]
        public void MaxSizeShouldBeDefined() {
            //Assert
            Position.MaxColumn.ShouldBeEqual(rule.Size);
            Position.MaxRow.ShouldBeEqual(rule.Size);
        }

        [Test]
        public void FieldShouldBeCreated() {
            //Assert
            field.ShouldBeNotNull();
        }

        [Test]
        public void ShouldGenerateSeaOnBorder() {
            //Assert
            field.GetColumns().First()
                .ShouldContain()
                .OnlyCellsOf(CellType.Water);

            field.GetColumns().Last()
                .ShouldContain()
                .OnlyCellsOf(CellType.Water);

            field.GetRows().First()
                .ShouldContain()
                .OnlyCellsOf(CellType.Water);

            field.GetRows().Last()
                .ShouldContain()
                .OnlyCellsOf(CellType.Water);
        }

        [Test]
        public void InnerCornerCellShouldBeWater() {
            // x x x x x x x x
            // x x . . . . x x
            // x . . . . . . x
            // x . . . . . . x
            // x . . . . . . x
            // x x . . . . x x
            // x x x x x x x x

            //Assert
            field.GetColumn(1)
                .ShouldContain()
                .CellsOf(CellType.Water).Count()
                .ShouldBeEqual(4);

            field.GetColumn(Position.MaxColumn - 2)
                .ShouldContain()
                .CellsOf(CellType.Water).Count()
                .ShouldBeEqual(4);
        }

        [Test]
        public void ItShouldBeGrassByDefault() {
            //Assert
            field.GetPlayableArea()
                .ShouldContain()
                .OnlyCellsOf(CellType.Grass);


            var playableArea = field.GetPlayableArea();
            Assert.IsTrue(playableArea.All(cells => cells.CellType == CellType.Grass));
        
            Assert.IsTrue(field.GetPlayableArea()
                .All(cells => cells.CellType == CellType.Grass));
         }


        [Test]
        public void ShouldGenerateShips() {
            // Assert
            field.GetColumns()
                .First()
                .Count(cell => ((WaterCell) cell).Ship.IsNotNull())
                .ShouldBeEqual(1);

            field.GetColumns()
                .Last()
                .Count(cell => ((WaterCell) cell).Ship.IsNotNull())
                .ShouldBeEqual(1);


            field.GetRows()
                .First()
                .Count(cell => ((WaterCell) cell).Ship.IsNotNull())
                .ShouldBeEqual(1);

            field.GetRows()
                .Last()
                .Count(cell => ((WaterCell) cell).Ship.IsNotNull())
                .ShouldBeEqual(1);
        }

        [Test]
        public void ShouldCreatePlayersByRule   () {
                field.NumberOfPlayers
                    .ShouldBeEqual(rule.NumberOfPlayers);

            for (int i = 0; i < field.NumberOfPlayers; i++) {
                field.NextPlayer();
                field.CurrentPlayer.ShouldBeNotNull();
            }

        }
    }
}