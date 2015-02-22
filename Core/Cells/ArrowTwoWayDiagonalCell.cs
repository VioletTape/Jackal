using System.Collections.Generic;
using System.Linq;
using Core.BaseTypes;
using Core.Enums;

namespace Core.Cells {
    public class ArrowTwoWayDiagonalCell : Cell {
        private readonly Direction direction;
        private readonly DirectionHelper directionHelper;

        public ArrowTwoWayDiagonalCell(int col, int row) : base(col, row) {
            CellType = CellType.ArrowTwoWayD;
            Terminal = false;

            directionHelper = new DirectionHelper();
            direction = directionHelper.RandomizeDiagonalDirection();
        }

        public override List<Direction> ExcludedDirections() {
            return directionHelper.GetAllDirections()
                .Except(directionHelper.GetOppositePair(direction))
                .ToList();
        }
    }
}