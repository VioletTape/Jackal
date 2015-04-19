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
            // todo: validate condition
//            if(ContainsPirateFor(pirate.TeamType) || ContainsPirateFor(pirate.Aliance)) {
            if(ContainsPirateFor(pirate.TeamType)) {
                Pirates.ToList().ForEach(p => p.ApplyCommand(Pirate.Actions.Free));
                pirate.ApplyCommand(Pirate.Actions.Free);
                return true;
            }

            pirate.ApplyCommand(Pirate.Actions.Trap);
            KillFoesFor(pirate);

            return true;
        }

        public override bool PirateWent(Pirate pirate) {
            return pirate.State != PlayerState.Trapped;
        }
    }
}