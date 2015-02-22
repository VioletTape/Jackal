using System.Collections.Generic;
using System.Linq;
using Core.BaseTypes;
using Core.Enums;

namespace Core.Cells {
    public class ArrowFourWayDiagonalCell : Cell {
        public ArrowFourWayDiagonalCell(int col, int row) : base(col, row) {
            CellType = CellType.ArrowFourWayD;
            Terminal = false;
        }

        public override List<Direction> ExcludedDirections() {
            var directionHelper = new DirectionHelper();
            return directionHelper.GetAllDirections()
                .Except(directionHelper.GetDiagonalDirections())
                .ToList();
        }
    }
}