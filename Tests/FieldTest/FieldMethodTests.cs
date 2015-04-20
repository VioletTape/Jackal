using Core.BaseTypes;
using NUnit.Framework;
using Tests.RulesForTesting;

namespace Tests.FieldTest {
    [TestFixture]
    public class FieldMethodTests {
      private Field field;

        [SetUp]
        public void ClassInit() {
            //Arrange 
            field = new Field(new TestEmptyRules());
        }
    }
}