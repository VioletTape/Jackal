using NUnit.Framework;
using Tests.DSL;

namespace Tests.PirateTst {
    [TestFixture]
    public class PirateCommonTests {
        [Test]
        public void PiratesStateCanNotBeSetDirectly() {
            //Arrange
            var pirate = Black.Pirate;

            //Assert
            pirate.Property("State").ShouldBeReadonly();
        }

        [Test]
        public void PiratesPlayerCanNotBeSetDirectly() {
            //Arrange
            var pirate = Black.Pirate;

            //Assert
            pirate.Property("Player").ShouldBeReadonly();
        }
    }
}