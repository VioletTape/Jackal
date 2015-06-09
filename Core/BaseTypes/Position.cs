using System;
using Core.Enums;

namespace Core.BaseTypes {
    public class Position {
        public static int MaxRow;
        public static int MaxColumn;

        public int Row { get; private set; }
        public int Column { get; private set; }

        public Position(int column, int row) {
            Row = row;
            Column = column;
        }

        public Position(Position position) : this(position.Column, position.Row) {}

        public void Move(Direction direction) {
            switch (direction) {
                case Direction.N:
                    MoveN();
                    break;
                case Direction.S:
                    MoveS();
                    break;
                case Direction.E:
                    MoveE();
                    break;
                case Direction.W:
                    MoveW();
                    break;
                case Direction.SE:
                    MoveSE();
                    break;
                case Direction.SW:
                    MoveSW();
                    break;
                case Direction.NE:
                    MoveNE();
                    break;
                case Direction.NW:
                    MoveNW();
                    break;
            }
        }

        public void MoveN() {
            if (OnNorthBorder())
                throw new MovementException();

            Row--;
        }

        public void MoveNW() {
            if (OnNorthBorder() || OnWestBorder())
                throw new MovementException();

            Row--;
            Column--;
        }

        public void MoveNE() {
            if (OnNorthBorder() || OnEastBorder())
                throw new MovementException();

            Row--;
            Column++;
        }

        public void MoveS() {
            if (OnSouthBorder())
                throw new MovementException();

            Row++;
        }

        public void MoveSW() {
            if (OnSouthBorder() || OnWestBorder())
                throw new MovementException();

            Row++;
            Column--;
        }

        public void MoveSE() {
            if (OnSouthBorder() || OnEastBorder())
                throw new MovementException();

            Row++;
            Column++;
        }

        public void MoveW() {
            if (OnWestBorder())
                throw new MovementException();

            Column--;
        }

        public void MoveE() {
            if (OnEastBorder())
                throw new MovementException();

            Column++;
        }

        private bool OnNorthBorder() {
            return Row == 0;
        }

        private bool OnSouthBorder() {
            return Row == MaxRow-1;
        }

        private bool OnWestBorder() {
            return Column == 0;
        }

        private bool OnEastBorder() {
            return Column == MaxColumn-1;
        }

        public bool IsCloseTo(Position other) {
            return Math.Abs(other.Row - Row) < 2 &&
                   Math.Abs(other.Column - Column) < 2;
        }

        #region Equality

        public bool Equals(Position other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.Row == Row && other.Column == Column;
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Position)) return false;
            return Equals((Position) obj);
        }

        public override int GetHashCode() {
            unchecked {
                return (Row*397) ^ Column;
            }
        }

        public static bool operator ==(Position left, Position right) {
            return Equals(left, right);
        }

        public static bool operator !=(Position left, Position right) {
            return !Equals(left, right);
        }

        #endregion

        public Direction GetDirectionFrom(Position prevPosition) {
            var row = prevPosition.Row - Row;
            var col = prevPosition.Column - Column;

            if (row <= -1 && col == 0) {
                return Direction.S;
            }

            if (row >= 1 && col == 0) {
                return Direction.N;
            }

            if (row == 0 && col >= 1) {
                return Direction.W;
            }

            if (row == 0 && col <= -1) {
                return Direction.E;
            }

            if (row <= -1 && col >= 1) {
                return Direction.SW;
            }

            if (row <= -1 && col <= -1) {
                return Direction.SE;
            }

            if (row >= 1 && col <= -1) {
                return Direction.NE;
            }

            if (row >= 1 && col >= 1) {
                return Direction.NW;
            }

            if (row == 0 && col == 0) {
                return Direction.None;
            }

            throw new NotSupportedException("");
        }

        public override string ToString() {
            return String.Format("{0}-{1}", Column, Row);
        }
    }
}