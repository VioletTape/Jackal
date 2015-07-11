using System.Linq;
using Core.BaseTypes;
using Core.Enums;

namespace Core.Cells {
    public class AirplaneCell : Cell {
        public bool Active { get; private set; }

        public AirplaneCell(int col, int row) : base(col, row) {
            CellType = CellType.Airplane;
            Active = true;
            Terminal = false;
        }

        protected override bool PirateComes(Pirate pirate) {
            KillFoesFor(pirate);
            pirate.ApplyCommand(Pirate.Actions.Free);

            return true;
        }

        public void Transfer() {
            if (Active) {
                Terminal = true;
                Active = false;
                var pirate = Pirates.First();
                PirateWentBase(pirate);
                pirate.ApplyCommand(Pirate.Actions.Ship);
            }
        }
    }
}