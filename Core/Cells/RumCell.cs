using Core.BaseTypes;
using Core.Enums;

namespace Core.Cells {
    public class RumCell : Cell {
        public RumCell(int col, int row) : base(col, row) {
            CellType = CellType.Rum;
        }
    }
}