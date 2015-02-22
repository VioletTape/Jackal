using System;
using Core;
using Core.BaseTypes;
using Core.Enums;
using NUnit.Framework;

namespace Tests {
    [TestFixture]
    public class PositionTests {
        [Test]
        public void PointsShouldBeSettedFromCtrn() {
            //Arrange
            var position = new Position(5, 14);

            //Assert
            position.Row.ShouldBeEqual(5);
            position.Column.ShouldBeEqual(14);
        }

        [Test]
        public void PointsMayBeSetFromAnotherPosition() {
            //Arrange
            var position = new Position(new Position(5, 14));

            //Assert
            position.Row.ShouldBeEqual(5);
            position.Column.ShouldBeEqual(14);
        }


        [Test]
        public void MaxSizeShouldBeKnownAndShared() {
            //Arrange
            var position = new Position(1, 1);

            //Act
            Position.MaxColumn = 5;
            Position.MaxRow = 6;

            //Assert
            position.StaticField("MaxColumn").ShouldBeEqual(5);
            position.StaticField("MaxRow").ShouldBeEqual(6);
        }

        [Test]
        public void RowAndColumnShouldBeReadOnly() {
            //Arrange
            var position = new Position(5, 14);

            //Assert
            position.Property("Row").ShouldBeReadonly();
            position.Property("Column").ShouldBeReadonly();
        }

        [Test]
        public void PositionsEquality() {
            //Arrange
            var position1 = new Position(5, 14);
            var position2 = new Position(5, 14);

            //Assert
            position1.ShouldBeEqual(position2);
        }


        [Test]
        public void PositionCanMoveToNorth() {
            //Arrange
            Position.MaxColumn = 10;
            Position.MaxRow = 10;
            var position = new Position(5, 5);

            //Act
            position.MoveN();

            //Assert
            position.Column.ShouldBeEqual(5);
            position.Row.ShouldBeEqual(4);
        }

        [Test]
        public void PositionCanNotMoveOverNorth() {
            //Arrange
            Position.MaxColumn = 10;
            Position.MaxRow = 10;
            var position = new Position(0, 5);

            //Act
            Action whenMoveN = position.MoveN;

            //Assert
            whenMoveN.ExpectException<MovementException>();

            position.Column.ShouldBeEqual(5);
            position.Row.ShouldBeEqual(0);
        }

        [Test]
        public void PositionCanMoveToSouth() {
            //Arrange
            Position.MaxColumn = 10;
            Position.MaxRow = 10;
            var position = new Position(5, 5);

            //Act
            position.MoveS();

            //Assert
            position.Column.ShouldBeEqual(5);
            position.Row.ShouldBeEqual(6);
        }

        [Test]
        public void PositionCanNotMoveOverSouth() {
            //Arrange
            Position.MaxColumn = 10;
            Position.MaxRow = 10;
            var position = new Position(9, 5);

            //Act
            Action whenMoveS = position.MoveS;

            //Assert
            whenMoveS.ExpectException<MovementException>();

            position.Column.ShouldBeEqual(5);
            position.Row.ShouldBeEqual(9);
        }


        [Test]
        public void PositionCanMoveToEast() {
            //Arrange
            Position.MaxColumn = 10;
            Position.MaxRow = 10;
            var position = new Position(5, 5);

            //Act
            position.MoveE();

            //Assert
            position.Column.ShouldBeEqual(6);
            position.Row.ShouldBeEqual(5);
        }

        [Test]
        public void PositionCanNotMoveOverEast() {
            //Arrange
            Position.MaxColumn = 10;
            Position.MaxRow = 10;
            var position = new Position(5, 9);

            //Act
            Action whenMoveE = position.MoveE;

            //Assert
            whenMoveE.ExpectException<MovementException>();

            position.Column.ShouldBeEqual(9);
            position.Row.ShouldBeEqual(5);
        }

        [Test]
        public void PositionCanMoveToWest() {
            //Arrange
            Position.MaxColumn = 10;
            Position.MaxRow = 10;
            var position = new Position(5, 5);

            //Act
            position.MoveW();

            //Assert
            position.Column.ShouldBeEqual(4);
            position.Row.ShouldBeEqual(5);
        }

        [Test]
        public void PositionCanNotMoveOverWest() {
            //Arrange
            Position.MaxColumn = 10;
            Position.MaxRow = 10;
            var position = new Position(5, 0);

            //Act
            Action whenMoveW = position.MoveW;

            //Assert
            whenMoveW.ExpectException<MovementException>();

            position.Column.ShouldBeEqual(0);
            position.Row.ShouldBeEqual(5);
        }

        [Test]
        public void PositionCanMoveToNE() {
            //Arrange
            Position.MaxColumn = 10;
            Position.MaxRow = 10;
            var position = new Position(5, 5);

            //Act
            position.MoveNE();

            //Assert
            position.Column.ShouldBeEqual(6);
            position.Row.ShouldBeEqual(4);
        }

        [Test]
        public void PositionCanMoveToNW() {
            //Arrange
            Position.MaxColumn = 10;
            Position.MaxRow = 10;
            var position = new Position(5, 5);

            //Act
            position.MoveNW();

            //Assert
            position.Column.ShouldBeEqual(4);
            position.Row.ShouldBeEqual(4);
        }

        [Test]
        public void PositionCanMoveToSE() {
            //Arrange
            Position.MaxColumn = 10;
            Position.MaxRow = 10;
            var position = new Position(5, 5);

            //Act
            position.MoveSE();

            //Assert
            position.Column.ShouldBeEqual(6);
            position.Row.ShouldBeEqual(6);
        }

        [Test]
        public void PositionCanMoveToSW() {
            //Arrange
            Position.MaxColumn = 10;
            Position.MaxRow = 10;
            var position = new Position(5, 5);

            //Act
            position.MoveSW();

            //Assert
            position.Column.ShouldBeEqual(4);
            position.Row.ShouldBeEqual(6);
        }

        [Test]
        public void PositionCanSayIfItCloseToAnotherOne() {
            //Arrange
            Position.MaxColumn = 10;
            Position.MaxRow = 10;
            var position1 = new Position(5, 5);
            var position2 = new Position(6, 6);
            var position3 = new Position(7, 6);

            //Act

            //Assert
            position1.IsCloseTo(position2).ShouldBeTrue();
            position1.IsCloseTo(position3).ShouldBeFalse();
        }

        [Test]
        public void CanDefineSouthDirection() {
            //Arrange
            Position.MaxColumn = 10;
            Position.MaxRow = 10;
            var positionPrev = new Position(5, 5);
            var positionCur = new Position(6, 5);

            // Act
            var direction = positionCur.GetDirectionFrom(positionPrev);

            // Assert
            direction.ShouldBeEqual(Direction.S);
        }

        [Test]
        public void CanDefineNorthDirection() {
            //Arrange
            Position.MaxColumn = 10;
            Position.MaxRow = 10;
            var positionPrev = new Position(5, 5);
            var positionCur = new Position(4, 5);

            // Act
            var direction = positionCur.GetDirectionFrom(positionPrev);

            // Assert
            direction.ShouldBeEqual(Direction.N);
        }

        [Test]
        public void CanDefineWestDirection() {
            //Arrange
            Position.MaxColumn = 10;
            Position.MaxRow = 10;
            var positionPrev = new Position(5, 5);
            var positionCur = new Position(5, 4);

            // Act
            var direction = positionCur.GetDirectionFrom(positionPrev);

            // Assert
            direction.ShouldBeEqual(Direction.W);
        }

        [Test]
        public void CanDefineEastDirection() {
            //Arrange
            Position.MaxColumn = 10;
            Position.MaxRow = 10;
            var positionPrev = new Position(5, 5);
            var positionCur = new Position(5, 6);

            // Act
            var direction = positionCur.GetDirectionFrom(positionPrev);

            // Assert
            direction.ShouldBeEqual(Direction.E);
        }

        [Test]
        public void CanDefineSouthWestDirection() {
            //Arrange
            Position.MaxColumn = 10;
            Position.MaxRow = 10;
            var positionPrev = new Position(5, 5);
            var positionCur = new Position(6, 4);

            // Act
            var direction = positionCur.GetDirectionFrom(positionPrev);

            // Assert
            direction.ShouldBeEqual(Direction.SW);
        }

        [Test]
        public void CanDefineSouthEastDirection() {
            //Arrange
            Position.MaxColumn = 10;
            Position.MaxRow = 10;
            var positionPrev = new Position(5, 5);
            var positionCur = new Position(6, 6);

            // Act
            var direction = positionCur.GetDirectionFrom(positionPrev);

            // Assert
            direction.ShouldBeEqual(Direction.SE);
        }

        [Test]
        public void CanDefineNorthEastDirection() {
            //Arrange
            Position.MaxColumn = 10;
            Position.MaxRow = 10;
            var positionPrev = new Position(5, 5);
            var positionCur = new Position(4, 6);

            // Act
            var direction = positionCur.GetDirectionFrom(positionPrev);

            // Assert
            direction.ShouldBeEqual(Direction.NE);
        }

        [Test]
        public void CanDefineNorthWestDirection() {
            //Arrange
            Position.MaxColumn = 10;
            Position.MaxRow = 10;
            var positionPrev = new Position(5, 5);
            var positionCur = new Position(4, 4);

            // Act
            var direction = positionCur.GetDirectionFrom(positionPrev);

            // Assert
            direction.ShouldBeEqual(Direction.NW);
        }
    }
}