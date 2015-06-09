using Core.BaseTypes;
using NUnit.Framework;

namespace Tests.Cells.BaseCell {
    [TestFixture]
    public class WhenCreateCell {
        [Test]
        public void ItShouldBeNotDiscovered() {
            //Arrange
            var stubCell = new StubCell();

            //Assert
            stubCell.Discoverd.ShouldBeFalse();
        }

        [Test]
        public void ItShouldBeTerminal() {
            //Arrange
            var stubCell = new StubCell();

            //Assert
            stubCell.Terminal.ShouldBeTrue();
        }

        [Test]
        public void ItShouldNotBeMultistep() {
            //Arrange
            var stubCell = new StubCell();

            //Assert
            stubCell.MultiStep.ShouldBeFalse();
        }

        [Test]
        public void ItShouldBeWithoutPirates() {
            //Arrange
            var stubCell = new StubCell();

            //Assert
            stubCell.Pirates.ShouldBeEmpty();
        }

        [Test]
        public void PirateShouldBeReadonly() {
            //Arrange
            var stubCell = new StubCell();

            //Assert
            stubCell.Pirates.ShouldBeReadonlyCollection();
        }

        [Test]
        public void ItShouldCreatePosition() {
            //Arrange
            var stubCell = new StubCell(3, 4);

            //Assert
            stubCell.Position.ShouldBeNotNull();
            stubCell.Position.ShouldBeEqual(new Position(3, 4));
        }
    }
}