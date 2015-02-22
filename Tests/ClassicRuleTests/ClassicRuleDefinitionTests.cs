using System.Linq;
using Core.BaseTypes;
using Core.Enums;
using NUnit.Framework;
using Tests.DSL;

namespace Tests.ClassicRuleTests {
    [TestFixture]
    public class ClassicRuleDefinitionTests {
        private ClassicRule classicRule;

        [TestFixtureSetUp]
        public void ClassInit() {
            classicRule = new ClassicRule();
        }

        [Test]
        public void SizeShouldBe13() {
            //Assert
            classicRule.Size.ShouldBeEqual(13);
        }

        [Test]
        public void FiledShouldBeCreated() {
            //Assert
            classicRule.Field.ShouldBeNotNull();
        }

        [Test]
        public void DefaultCellNumbers() {
            //Assert
            classicRule.Field.GetPlayableArea()
                .ShouldContain()
                .CellsOf(CellType.Amazon).Count()
                .ShouldBeEqual(1);

             classicRule.Field.GetPlayableArea()
                .ShouldContain()
                .CellsOf(CellType.Fortress).Count()
                .ShouldBeEqual(2);

             classicRule.Field.GetPlayableArea()
                .ShouldContain()
                .CellsOf(CellType.Death).Count()
                .ShouldBeEqual(1);

             classicRule.Field.GetPlayableArea()
                .ShouldContain()
                .CellsOf(CellType.Airplane).Count()
                .ShouldBeEqual(1);


             classicRule.Field.GetPlayableArea()
                .ShouldContain()
                .CellsOf(CellType.Rocks).Count()
                .ShouldBeEqual(1);

             classicRule.Field.GetPlayableArea()
                .ShouldContain()
                .CellsOf(CellType.Swamp).Count()
                .ShouldBeEqual(2);

            classicRule.Field.GetPlayableArea()
                .ShouldContain()
                .CellsOf(CellType.Sands).Count()
                .ShouldBeEqual(4);

            classicRule.Field.GetPlayableArea()
                .ShouldContain()
                .CellsOf(CellType.Jungle).Count()
                .ShouldBeEqual(5);

            classicRule.Field.GetPlayableArea()
                .ShouldContain()
                .CellsOf(CellType.Cannon).Count()
                .ShouldBeEqual(2);


            classicRule.Field.GetPlayableArea()
                .ShouldContain()
                .CellsOf(CellType.ArrowOneWayD).Count()
                .ShouldBeEqual(3);

            classicRule.Field.GetPlayableArea()
                .ShouldContain()
                .CellsOf(CellType.ArrowOneWayS).Count()
                .ShouldBeEqual(3);

            classicRule.Field.GetPlayableArea()
                .ShouldContain()
                .CellsOf(CellType.ArrowTwoWayD).Count()
                .ShouldBeEqual(3);

            classicRule.Field.GetPlayableArea()
                .ShouldContain()
                .CellsOf(CellType.ArrowTwoWayS).Count()
                .ShouldBeEqual(3);

            classicRule.Field.GetPlayableArea()
                .ShouldContain()
                .CellsOf(CellType.ArrowThreeWay).Count()
                .ShouldBeEqual(3);

            classicRule.Field.GetPlayableArea()
                .ShouldContain()
                .CellsOf(CellType.ArrowFourWayD).Count()
                .ShouldBeEqual(3);

            classicRule.Field.GetPlayableArea()
                .ShouldContain()
                .CellsOf(CellType.ArrowFourWayS).Count()
                .ShouldBeEqual(3);


            classicRule.Field.GetPlayableArea()
                .ShouldContain()
                .CellsOf(CellType.Gold1).Count()
                .ShouldBeEqual(5);

            classicRule.Field.GetPlayableArea()
                .ShouldContain()
                .CellsOf(CellType.Gold2).Count()
                .ShouldBeEqual(5);

            classicRule.Field.GetPlayableArea()
                .ShouldContain()
                .CellsOf(CellType.Gold3).Count()
                .ShouldBeEqual(3);

            classicRule.Field.GetPlayableArea()
                .ShouldContain()
                .CellsOf(CellType.Gold4).Count()
                .ShouldBeEqual(2);

            classicRule.Field.GetPlayableArea()
                .ShouldContain()
                .CellsOf(CellType.Gold5).Count()
                .ShouldBeEqual(1);
        }
    }
}