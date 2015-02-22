using Core.BaseTypes;
using Core.Cells.CellTypes;
using Core.Enums;

namespace Core.Cells {
    public class DeathCell : Cell {
        public DeathType DeathType { get; private set; }

        public DeathCell(int col, int row) : base(col, row) {
            CellType = CellType.Death;
            RandomizeDeathType();
        }

        protected override bool PirateComes(Pirate pirate) {
            pirate.Kill();
            return false;
        }

        private void RandomizeDeathType() {
            DeathType = DeathType.Hannibal;
        }
    }
}