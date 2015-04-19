using System.Collections.Generic;
using System.Linq;
using Core.BaseTypes;
using Core.Enums;
using NUnit.Framework;
using Tests.DSL;
using Tests.RulesForTesting;

namespace Tests.FieldTest {
    [TestFixture]
    public class WhenCreatePlayableField {
        [Test]
        public void ShouldBeAbleCreateAmazoneCell() {
            //Arrange
            var rule = new TestEmptyRules {
                                              Amazon = 3
                                          };
            var field = new Field(rule);

            //Assert
            field.GetPlayableArea()
                 .ShouldContain()
                 .CellsOf(CellType.Amazon).Count()
                 .ShouldBeEqual(3);
        }

        [Test]
        public void ShouldCreateMostPossibleCells() {
            //Arrange
            var rule = new TestEmptyRules {
                                              Amazon = 30000
                                          };
            var field = new Field(rule);


            //Act

            //Assert
            field.GetPlayableArea()
                 .ShouldContain()
                 .OnlyCellsOf(CellType.Amazon);
        }

        [Test]
        public void ShouldNotFillWater() {
            //Arrange
            var rule = new TestEmptyRules {
                                              Amazon = 30000
                                          };
            var field = new Field(rule);


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
        public void ShouldBeAbleCreateDeathCell() {
            //Arrange
            var rule = new TestEmptyRules {
                                              Death = 3
                                          };
            var field = new Field(rule);


            //Assert
            field.GetPlayableArea()
                 .ShouldContain()
                 .CellsOf(CellType.Death).Count()
                 .ShouldBeEqual(3);
        }

        [Test]
        public void ShouldBeAbleCreateAirplaneCell() {
            //Arrange
            var rule = new TestEmptyRules {
                                              Airplane = 3
                                          };
            var field = new Field(rule);


            //Assert
            field.GetPlayableArea()
                 .ShouldContain()
                 .CellsOf(CellType.Airplane).Count()
                 .ShouldBeEqual(3);
        }

        [Test]
        public void ShouldBeAbleCreateJungleCell() {
            //Arrange
            var rule = new TestEmptyRules {
                                              Jungle = 3
                                          };
            var field = new Field(rule);


            //Assert
            field.GetPlayableArea()
                 .ShouldContain()
                 .CellsOf(CellType.Jungle).Count()
                 .ShouldBeEqual(3);
        }

        [Test]
        public void ShouldBeAbleCreateSandsCell() {
            //Arrange
            var rule = new TestEmptyRules {
                                              Sands = 3
                                          };
            var field = new Field(rule);


            //Assert
            field.GetPlayableArea()
                 .ShouldContain()
                 .CellsOf(CellType.Sands).Count()
                 .ShouldBeEqual(3);
        }

        [Test]
        public void ShouldBeAbleCreateSwampCell() {
            //Arrange
            var rule = new TestEmptyRules {
                                              Swamp = 3
                                          };
            var field = new Field(rule);


            //Assert
            field.GetPlayableArea()
                 .ShouldContain()
                 .CellsOf(CellType.Swamp).Count()
                 .ShouldBeEqual(3);
        }

        [Test]
        public void ShouldBeAbleCreateRocksCell() {
            //Arrange
            var rule = new TestEmptyRules {
                                              Rocks = 3
                                          };
            var field = new Field(rule);


            //Assert
            field.GetPlayableArea()
                 .ShouldContain()
                 .CellsOf(CellType.Rocks).Count()
                 .ShouldBeEqual(3);
        }

        [Test]
        public void ShouldBeAbleCreateCannonCell() {
            //Arrange
            var rule = new TestEmptyRules {
                                              Cannon = 3
                                          };
            var field = new Field(rule);


            //Assert
            field.GetPlayableArea()
                 .ShouldContain()
                 .CellsOf(CellType.Cannon).Count()
                 .ShouldBeEqual(3);
        }

        [Test]
        public void ShouldBeAbleCreateGoldCell() {
            //Arrange
            var rule = new TestEmptyRules {
                                              Golds = new List<int> {
                                                                        5,
                                                                        4,
                                                                        3,
                                                                        2,
                                                                        1
                                                                    }
                                          };
            var field = new Field(rule);


            //Assert
            field.GetPlayableArea()
                 .ShouldContain()
                 .CellsOf(CellType.Gold1).Count()
                 .ShouldBeEqual(5);
        }

        [Test]
        public void ShouldBeAbleCreateIceCell() {
            //Arrange
            var rule = new TestEmptyRules {
                                              Ice = 4
                                          };

            // Act
            var field = new Field(rule);

            //Assert
            field.GetPlayableArea()
                 .ShouldContain()
                 .CellsOf(CellType.Ice).Count()
                 .ShouldBeEqual(4);
        }

        [Test]
        public void ShouldBeAbleCreateFortressCell() {
            //Arrange
            var rule = new TestEmptyRules {
                                              Fortress = 4
                                          };

            // Act
            var field = new Field(rule);


            //Assert
            field.GetPlayableArea()
                 .ShouldContain()
                 .CellsOf(CellType.Fortress).Count()
                 .ShouldBeEqual(4);
        }

        [Test]
        public void ShouldBeAbleCreateBaloonCell() {
            //Arrange
            var rule = new TestEmptyRules {
                                              Baloon = 2
                                          };

            // Act
            var field = new Field(rule);


            //Assert
            field.GetPlayableArea()
                 .ShouldContain()
                 .CellsOf(CellType.Baloon).Count()
                 .ShouldBeEqual(2);
        }

        [Test]
        public void ShouldBeAbleCreateTrapCell() {
            //Arrange
            var rule = new TestEmptyRules {
                                              Trap = 2
                                          };

            // Act
            var field = new Field(rule);


            //Assert
            field.GetPlayableArea()
                 .ShouldContain()
                 .CellsOf(CellType.Trap).Count()
                 .ShouldBeEqual(2);
        }

        [Test]
        public void ShouldBeAbleCreateArrow1Cell() {
            //Arrange
            var rule = new TestEmptyRules {
                                              ArrowOneWayS = 2
                                          };

            // Act
            var field = new Field(rule);


            //Assert
            field.GetPlayableArea()
                 .ShouldContain()
                 .CellsOf(CellType.ArrowOneWayS).Count()
                 .ShouldBeEqual(2);
        }
    }
}