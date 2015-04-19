using Core.BaseTypes;
using NUnit.Framework;
using Tests.RulesForTesting;

namespace Tests.FieldTest {
    [TestFixture]
    public class FieldMethodTests {
      private Field field;
        private TestEmptyRules rule;

        [SetUp]
        public void ClassInit() {
            //Arrange 
            rule = new TestEmptyRules();
            field = new Field(rule);
        }

        [Test]
        public void ShouldGetChangedCells() {
            // Assert
                field.ChangedCells().Count
                    .ShouldBeEqual(3*4);
        }
    }
}