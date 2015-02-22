using System.Collections.Generic;
using System.Linq;
using Core.BaseTypes;
using Core.Enums;

namespace Core.Cells {
    public class ArrowThreeWayCell : Cell {
        private readonly Direction direction;
        private readonly DirectionHelper directionHelper;
        private readonly List<Direction> turnListTo;

        public ArrowThreeWayCell(int col, int row) : base(col, row) {
            CellType = CellType.ArrowThreeWay;
            Terminal = false;

            directionHelper = new DirectionHelper();
            direction = directionHelper.RandomizeDirection();

            var dirs = new List<Direction> {
                                               Direction.N,
                                               Direction.E,
                                               Direction.SW
                                           };


            turnListTo = directionHelper.TurnListTo(direction, dirs);
        }

        public override List<Direction> ExcludedDirections() {
            return directionHelper.GetAllDirections()
                .Except(turnListTo)
                .ToList();
        }
    }
}