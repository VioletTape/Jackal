using System;
using System.Collections.Generic;
using System.Linq;
using Core.Extensions;

namespace Core.Enums {
    public enum Direction {
        N,
        NE,
        E,
        SE,
        S,
        SW,
        W,
        NW,

        None
    }

    public class DirectionHelper {
        private Random random = new Random();

        public List<Direction> GetAllDirections() {
            var directions = Enum.GetValues(typeof (Direction))
                .Cast<Direction>()
                .ToList();
            return directions;
        }

        public List<Direction> GetStraightDirections() {
            return new List<Direction> {
                                           Direction.N,
                                           Direction.E,
                                           Direction.S,
                                           Direction.W
                                       };
        }

        public List<Direction> GetDiagonalDirections() {
            return new List<Direction> {
                                           Direction.NE,
                                           Direction.SE,
                                           Direction.SW,
                                           Direction.NW
                                       };
        }

        public Direction GetOppositeDirection(Direction direction) {
            return (Direction) (((int) direction + 4)%8);
        }

        public List<Direction> GetOppositePair(Direction direction) {
            return new List<Direction> {
                                           direction,
                                           GetOppositeDirection(direction)
                                       };
        }

        public List<Direction> TurnListTo(Direction mainDirection, List<Direction> dirs) {
            var direction = dirs.Intersect(GetStraightDirections()).FirstOrDefault();
            if(direction.IsNull()) return dirs;

            var directions = new List<Direction>();
            foreach (var dir in dirs) {
                var direction1 = ((int) dir) + ((int) mainDirection);
                var dir1 = direction1%8;
                directions.Add((Direction) dir1);
            }

            return directions;
        }

        public Direction RandomizeStraightDirection() {
            return GetStraightDirections()[random.Next(0, 4)];
        }

         public Direction RandomizeDiagonalDirection() {
            return GetDiagonalDirections()[random.Next(0, 4)];
        }

        public Direction RandomizeDirection() {
            var directions = new List<Direction>();
            directions.AddRange(GetStraightDirections());
            directions.AddRange(GetDiagonalDirections());
            return directions[random.Next(0, 8)];
        }
    }
}