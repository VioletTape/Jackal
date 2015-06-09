using System.Linq;
using Core.BaseTypes;
using Core.Enums;

namespace Core.Cells {
    public class FortressCell : Cell {
        public FortressCell(int col, int row) : base(col, row) {
            CellType = CellType.Fortress;
        }

        internal override bool PirateCanComeFrom(Cell fromCell) {
            if(Pirates.Count == 0) return true;

            return fromCell.Pirates.All(p => p.IsInAllianceWith(Pirates[0]));
        }

        protected override bool PirateComes(Pirate pirate) {
            return true;
        }
    }
}