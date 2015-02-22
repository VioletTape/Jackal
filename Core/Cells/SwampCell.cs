using Core.Enums;

namespace Core.Cells {
    public class SwampCell : MultiStepCell {
        public SwampCell(int col, int row) : base(4, col, row) {
            CellType = CellType.Swamp;
        }
    }
}