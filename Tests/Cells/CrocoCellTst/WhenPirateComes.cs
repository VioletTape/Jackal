using Core.BaseTypes;
using Core.Cells;
using NUnit.Framework;
using Tests.DSL;
using Tests.RulesForTesting;

namespace Tests.Cells.CrocoCellTst {
    [TestFixture]
    public class WhenPirateComes {
        private Pirate pirate;

        [SetUp]
        public void TestInit() {
            Black.Reset();
            pirate = Black.Pirate;
        }

        [Test]
        public void HeCanNotStayOnCrocoCell() {
            // Arrange
            var testEmptyRules = new TestEmptyRules();
            var field = new Field(testEmptyRules);

            var startCell = field.Cells(3, 3);
            var crocoCell = new CrocoCell(4, 3);

            field.Draw(crocoCell);
            field.SetPirateOnCell(pirate, startCell);

            // Act
            field.SelectPirate(startCell);
            field.MovedPirateTo(pirate, crocoCell);

            // Assert
            startCell.Pirates.ShouldContain().Exact(pirate);
            crocoCell.Pirates.ShouldBeEmpty();
        }

        [Test]
        public void PathShouldContainCroco() {
            // Arrange
            var testEmptyRules = new TestEmptyRules();
            var field = new Field(testEmptyRules);

            var startCell = field.Cells(3, 3);
            var crocoCell = new CrocoCell(4, 3);

            field.Draw(crocoCell);
            field.SetPirateOnCell(pirate, startCell);

            // Act
            field.SelectPirate(startCell);
            field.MovedPirateTo(pirate, crocoCell);

            // Assert
            pirate.Path.ShouldContain().Elements(startCell.Position, crocoCell.Position, crocoCell.Position, startCell.Position);
        }
    }
}