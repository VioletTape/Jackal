using Core.BaseTypes;
using Core.Enums;

namespace Core.Cells {
    public class BaloonCell : Cell {
        public BaloonCell(int col, int row) : base(col, row) {
            CellType = CellType.Baloon;
            Terminal = false;
        }

         protected override bool PirateComes(Pirate pirate) {
            pirate.ApplyCommand(Pirate.Actions.Ship);

            return false;
        }
    }
}