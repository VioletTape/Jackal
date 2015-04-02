using Core.BaseTypes;
using Core.Enums;

namespace Core.Cells {
    public class HorsesCell : Cell {
        public HorsesCell(int col, int row) : base(col, row) {
            CellType = CellType.Horses;
        }
    }
}