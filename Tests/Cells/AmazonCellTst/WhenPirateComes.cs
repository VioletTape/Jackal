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
        private GreenField field;

        [SetUp]
        public void ClassInit() {
            field = new GreenField();

            pirate = field.CurrentPlayer.CurrentTeam.Pirates.Current;
            var cells = field.Cells(4,5);
            cells.AddPirate(pirate);
            
            amazonCell = new AmazonCell(5, 5);
            field.InsertCell(amazonCell);
        }


        [Test]
        public void HeMayComes() {
            // Act
            field.MovePirateTo(pirate, amazonCell);

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
            var player = new Player(TeamType.Red, TeamType.Black, new TestEmptyRules());
            var ally = player.GetNextTeam().Pirates.Current;
            
            pirate = player.GetNextTeam().Pirates.Current;

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
            var field = new Field(testEmptyRules);

            var startCell = field.Cells(3,3);
            var amazon = new AmazonCell(4, 3);

            field.Draw(amazon);
            field.SetPirateOnCell(pirate, startCell);
            

            // Act
            field.SelectPirate(startCell);
            field.MovePirateTo(pirate, amazon);

            // Assert
            field.Cells(startCell.Position).Pirates.ShouldBeEmpty();
            field.Cells(amazon.Position).Pirates.ShouldContain().Exact(pirate);

        }
    }
}