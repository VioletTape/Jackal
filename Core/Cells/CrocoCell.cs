using Core.BaseTypes;
using Core.Enums;

namespace Core.Cells {
    public class CrocoCell : Cell {
        public CrocoCell(int col, int row) : base(col, row) {
            CellType = CellType.Croco;
            Terminal = false;
        }

        protected override bool PirateComes(Pirate pirate) {
            var lastPosition = pirate.Path[pirate.Path.Count - 2];

            Field.MovedPirateTo(pirate, Field.Cells(lastPosition));

            return false;
        }
    }
}