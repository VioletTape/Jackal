using System.Collections.Generic;
using Core.Enums;
using NUnit.Framework;

///////////////////////////////////////////

namespace Tests {
    [TestFixture]
    public class DirectionHelperTests {
        private DirectionHelper helper;

        [SetUp]
        public void TestInit() {
            helper = new DirectionHelper();
        }

        [Test]
        public void CanGetOppositeDirection() {
            // Assert
            helper.GetOppositeDirection(Direction.S).ShouldBeEqual(Direction.N);
            helper.GetOppositeDirection(Direction.E).ShouldBeEqual(Direction.W);
            helper.GetOppositeDirection(Direction.NE).ShouldBeEqual(Direction.SW);
        }

        [Test]
        public void CanGetOppositePair_DirAndOpposite() {
            helper.GetOppositePair(Direction.S)
                  .ShouldContain()
                  .Elements(Direction.S, Direction.N);

            helper.GetOppositePair(Direction.SW)
                  .ShouldContain()
                  .Elements(Direction.SW, Direction.NE);
        }

        [Test]
        public void ShouldReturnAllDirections() {
            helper.GetAllDirections()
                  .ShouldContain()
                  .Elements(
                      Direction.N,
                      Direction.NE,
                      Direction.E,
                      Direction.SE,
                      Direction.S,
                      Direction.SW,
                      Direction.W,
                      Direction.NW
                );
        }

        [Test]
        public void ShouldReturnEmptyDirListIfNoIntersections() {
            helper.TurnListTo(Direction.N, new List<Direction>())
                .ShouldBeEmpty();
        }


        [Test]
        public void CanTurnList1() {
            // Arrange
            var list = new List<Direction> {
                                               Direction.N,
                                               Direction.NE
                                           };

            // Act
            var turnListTo = helper.TurnListTo(Direction.W, list);

            // Assert
            turnListTo.ShouldContain().Elements(Direction.W, Direction.NW);
        }

        [Test]
        public void CanTurnList2() {
            // Arrange
            var list = new List<Direction> {
                                               Direction.N,
                                               Direction.NE
                                           };

            // Act
            var turnListTo = helper.TurnListTo(Direction.NE, list);

            // Assert
            turnListTo.ShouldContain().Elements(Direction.NE, Direction.E);
        }
    }
}