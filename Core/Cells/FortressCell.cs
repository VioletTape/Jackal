using System.Linq;
using Core.BaseTypes;
using Core.Enums;

namespace Core.Cells {
    public class FortressCell : Cell {
        public FortressCell(int col, int row) : base(col, row) {
            CellType = CellType.Fortress;
        }

        public override bool PirateCanComeFrom(Cell fromCell) {
            if(Pirates.Count == 0) return true;

            return fromCell.Pirates.All(p =>
                                       p.Aliance == Pirates[0].Player
                                       || p.Player == Pirates[0].Player);
        }

        protected override bool PirateComes(Pirate pirate) {
            pirate.Free();
            return true;
        }
    }
}