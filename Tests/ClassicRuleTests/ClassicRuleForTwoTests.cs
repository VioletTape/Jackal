using Core.BaseTypes;
using NUnit.Framework;

namespace Tests.ClassicRuleTests {
    [TestFixture]
    public class ClassicRuleForTwoTests {
        private ClassicRuleForTwo classicRuleForTwo;

        [SetUp]
        public void TestInit() {
            classicRuleForTwo = new ClassicRuleForTwo();
        }

        [Test]
        public void ShouldBeTwoPlayers() {
            // Assert
            classicRuleForTwo.NumberOfPlayers.ShouldBeEqual(2);
        }
    }
}