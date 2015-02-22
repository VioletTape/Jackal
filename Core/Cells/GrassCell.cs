using System;
using Core.BaseTypes;
using Core.Cells.CellTypes;
using Core.Enums;

namespace Core.Cells {
    public class GrassCell : Cell {
        public GreenType GreenType { get; private set; }

        public GrassCell(int col, int row) : base(col, row) {
            CellType = CellType.Grass;
            RandomizeGreenType();
        }

        private void RandomizeGreenType() {
            GreenType = (GreenType) new Random().Next(0, 6);
        }

         protected override bool PirateComes(Pirate pirate) {
            pirate.Free();
            KillFoesFor(pirate);
            return true;

        }

    }
}