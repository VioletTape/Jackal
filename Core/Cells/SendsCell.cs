using Core.Enums;

namespace Core.Cells {
    public class SendsCell : MultiStepCell {
        public SendsCell(int col, int row) : base(3, col, row) {
            CellType = CellType.Sands;
        }
    }
}