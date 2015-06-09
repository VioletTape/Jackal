using Core.BaseTypes;
using Core.Cells;
using Core.Enums;
using NUnit.Framework;
using Tests.DSL;
using Tests.RulesForTesting;

namespace Tests.Cells.Arrow1CellTst {
    [TestFixture]
    public class WhenPirateComes {
         private Pirate black;

        [SetUp]
        public void Init() {
            Black.Reset();
            Red.Reset();

            black = Black.Pirate;
        }

        [Test]
        public void HeShouldContinueMovingInArrowDirection() {
            // Arrange

            var testEmptyRules = new TestEmptyRules();
            var field = new Field(testEmptyRules);


            var startCell = field.Cells(3,3);
            var arrow1Cell = new ArrowOneWayStraightCell(4, 3);
            arrow1Cell.SetField("direction", Direction.E);
            var endCell = field.Cells(5,3);

            field.Draw(arrow1Cell);
            field.SetPirateOnCell(black, startCell);
            

            // Act
            field.SelectPirate(startCell);
            field.MovePirateTo(black, arrow1Cell);

            // Assert
            field.Cells(startCell.Position).Pirates.ShouldBeEmpty();
            field.Cells(arrow1Cell.Position).Pirates.ShouldBeEmpty();
            field.Cells(endCell.Position).Pirates.ShouldContain().Exact(black);
        }

        [Test]
        public void HeShouldContinueMovingInArrowDirection_Back() {
            // Arrange

            var testEmptyRules = new TestEmptyRules();
            var field = new Field(testEmptyRules);


            var startCell = field.Cells(3,3);
            var arrow1Cell = new ArrowOneWayStraightCell(4, 3);
            arrow1Cell.SetField("direction", Direction.W);
            var endCell = field.Cells(5,3);

            field.Draw(arrow1Cell);
            field.SetPirateOnCell(black, startCell);
            

            // Act
            field.SelectPirate(startCell);
            field.MovePirateTo(black, arrow1Cell);

            // Assert
            field.Cells(startCell.Position).Pirates.ShouldContain().Exact(black);
            field.Cells(arrow1Cell.Position).Pirates.ShouldBeEmpty();
            field.Cells(endCell.Position).Pirates.ShouldBeEmpty();
        }
    }
}