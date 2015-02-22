using System.Collections.Generic;
using System.Linq;
using Core.BaseTypes;
using Core.Enums;

namespace Core.Cells {
    public class ArrowFourWayStraightCell : Cell {
        public ArrowFourWayStraightCell(int col, int row) : base(col, row) {
            CellType = CellType.ArrowFourWayS;
            Terminal = false;
        }

        public override List<Direction> ExcludedDirections() {
            var directionHelper = new DirectionHelper();
            return directionHelper.GetAllDirections()
                .Except(directionHelper.GetStraightDirections())
                .ToList();
        }
    }
}