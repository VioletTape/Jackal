using System.Linq;
using Core.BaseTypes;
using Core.Cells.CellTypes;
using Core.Enums;

namespace Core.Cells {
    public class TrapCell : Cell {
        public DeathType DeathType { get; private set; }

        public TrapCell(int col, int row) : base(col, row) {
            CellType = CellType.Trap;
        }

        protected override bool PirateComes(Pirate pirate) {
            if(ContainsPirateFor(pirate.TeamType) || ContainsPirateFor(pirate.Aliance)) {
                Pirates.ToList().ForEach(p => p.Free());
                pirate.Free();
                return true;
            }

            pirate.Trap();
            KillFoesFor(pirate);


            return true;
        }

        public override bool PirateWent(Pirate pirate) {
            return pirate.State != PlayerState.Trapped;
        }
    }
}