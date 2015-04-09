using Core.BaseTypes;
using Core.Cells;
using Core.Enums;
using NUnit.Framework;
using Tests.DSL;
using Tests.RulesForTesting;

namespace Tests.Cells.AmazonCellTst {
    [TestFixture]
    public class WhenPirateComes {
        private Pirate pirate;
        private AmazonCell amazonCell;

        [SetUp]
        public void ClassInit() {
            Black.Reset();
            Red.Reset();
            pirate = Black.Pirate;

            amazonCell = new AmazonCell(2, 2);
        }


        [Test]
        public void HeShouldSetFree() {
            // Act
            amazonCell.PirateComing(pirate);

            // Assert
            pirate.State.ShouldBeEqual(PlayerState.Free);
        }

        [Test]
        public void HeMayComes() {
            // Act
            amazonCell.PirateComing(pirate);

            // Assert
            amazonCell.Pirates.ShouldContain().Exact(pirate);
        }

        [Test]
        public void HeCanNotStayIfThereAreFoes() {
            var foe = Red.Pirate;
            amazonCell.PirateComing(foe);

            var stubCell = new StubCell();
            stubCell.AddPirate(pirate);

            // Act
            amazonCell.PirateCanComeFrom(stubCell);

            // Assert
            amazonCell.Pirates.ShouldContain().Exact(foe);
        }

        [Test]
        public void HeCanStayIfThereAreAlly() {
            var ally = Red.Pirate;
            ally.Aliance = TeamType.Black;
            pirate.Aliance = TeamType.Red;

            amazonCell.PirateComing(ally);

            var stubCell = new StubCell();
            stubCell.AddPirate(pirate);

            // Act
            amazonCell.PirateCanComeFrom(stubCell);
            amazonCell.PirateComing(pirate);

            // Assert
            amazonCell.Pirates.ShouldContain().Elements(ally, pirate);
        }

        [Test]
        public void CanComeFrom() {
             // Arrange
            var testEmptyRules = new TestEmptyRules();
            var field = testEmptyRules.Field;

            var startCell = field.Cells(3,3);
            var amazon = new AmazonCell(4, 3);

            field.Draw(amazon);
            field.SetPirateOnCell(pirate, startCell);
            

            // Act
            field.SelectPirate(startCell);
            field.MovedTo(amazon);

            // Assert
            field.Cells(startCell.Position).Pirates.ShouldBeEmpty();
            field.Cells(amazon.Position).Pirates.ShouldContain().Exact(pirate);

        }
    }
}