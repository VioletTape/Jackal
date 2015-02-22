using Core.Enums;

namespace Core.Cells {
    public class JungleCell : MultiStepCell {
        public JungleCell(int col, int row) : base(2, col, row) {
            CellType = CellType.Jungle;
        }
    }
}