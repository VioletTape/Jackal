using Core.BaseTypes;
using Core.Cells;
using NUnit.Framework;
using Tests.DSL;
using Tests.RulesForTesting;

namespace Tests.Cells.IceCellTst {
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
        public void HeShouldContinueMovingInPrevDirection() {
            // Arrange
            var testEmptyRules = new TestEmptyRules();
            var field = testEmptyRules.Field;

            var startCell = field.Cells(3,3);
            var iceCell = new IceCell(4, 3);
            var endCell = field.Cells(5,3);

            field.Draw(iceCell);
            field.SetPirateOnCell(black, startCell);

            // Act
            field.SelectPirate(startCell);
            field.MovedTo(iceCell);

            // Assert
            field.Cells(startCell.Position).Pirates.ShouldBeEmpty();
            field.Cells(iceCell.Position).Pirates.ShouldBeEmpty();
            field.Cells(endCell.Position).Pirates.ShouldContain().Exact(black);
        }

        [Test]
        public void HeShouldContinueMovingInPrevDirectionX2IceHor() {
            // Arrange
            var testEmptyRules = new TestEmptyRules();
            var field = testEmptyRules.Field;

            var startCell = field.Cells(3,3);
            var iceCell1 = new IceCell(4, 3);
            var iceCell2 = new IceCell(5, 3);
            var endCell = field.Cells(6,3);

            field.Draw(iceCell1);
            field.Draw(iceCell2);
            field.SetPirateOnCell(black, startCell);

            // Act
            field.SelectPirate(startCell);
            field.MovedTo(iceCell1);

            // Assert
            field.Cells(startCell.Position).Pirates.ShouldBeEmpty();
            field.Cells(iceCell1.Position).Pirates.ShouldBeEmpty();
            field.Cells(iceCell2.Position).Pirates.ShouldBeEmpty();
            field.Cells(endCell.Position).Pirates.ShouldContain().Exact(black);
        }

        [Test]
        public void HeShouldContinueMovingInPrevDirectionX2IceVert() {
            // Arrange
            var testEmptyRules = new TestEmptyRules();
            var field = testEmptyRules.Field;

            var startCell = field.Cells(3,3);
            var iceCell1 = new IceCell(3, 4);
            var iceCell2 = new IceCell(3, 5);
            var endCell = field.Cells(3,6);

            field.Draw(iceCell1);
            field.Draw(iceCell2);
            field.SetPirateOnCell(black, startCell);

            // Act
            field.SelectPirate(startCell);
            field.MovedTo(iceCell1);

            // Assert
            field.Cells(startCell.Position).Pirates.ShouldBeEmpty();
            field.Cells(iceCell1.Position).Pirates.ShouldBeEmpty();
            field.Cells(iceCell2.Position).Pirates.ShouldBeEmpty();
            field.Cells(endCell.Position).Pirates.ShouldContain().Exact(black);
        }
    }
}