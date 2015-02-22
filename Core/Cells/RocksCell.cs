using Core.Enums;

namespace Core.Cells {
    public class RocksCell : MultiStepCell {
        public RocksCell(int col, int row) : base(5, col, row) {
            CellType = CellType.Rocks;
        }
    }
}