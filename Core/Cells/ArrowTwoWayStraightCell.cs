using System.Collections.Generic;
using System.Linq;
using Core.BaseTypes;
using Core.Enums;

namespace Core.Cells {
    public class ArrowTwoWayStraightCell : Cell {
        private readonly Direction direction;
        private readonly DirectionHelper directionHelper;

        public ArrowTwoWayStraightCell(int col, int row) : base(col, row) {
            CellType = CellType.ArrowTwoWayS;
            Terminal = false;

            directionHelper = new DirectionHelper();
            direction = directionHelper.RandomizeStraightDirection();
        }

        public override List<Direction> ExcludedDirections() {
            return directionHelper.GetAllDirections()
                .Except(directionHelper.GetOppositePair(direction))
                .ToList();
        }
    }
}