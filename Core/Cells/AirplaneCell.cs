using Core.BaseTypes;
using Core.Enums;

namespace Core.Cells {
    public class AirplaneCell : Cell {
        private Pirate pirate;
        public bool Active { get; private set; }

        public AirplaneCell(int col, int row) : base(col, row) {
            CellType = CellType.Airplane;
            Active = true;
            Terminal = false;
        }

        protected override bool PirateComes(Pirate pirate) {
            this.pirate = pirate;
            pirate.Free();
            KillFoesFor(pirate);

            return true;
        }

        public void Transfer() {
            if (Active) {
                Terminal = true;
                Active = false;

//                pirate.Ship();
//                PirateWent(pirate);
            }
        }
    }
}