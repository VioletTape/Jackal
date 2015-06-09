using System.Linq;
using Core.BaseTypes;
using Core.Enums;

namespace Core.Cells {
    public class IceCell : Cell {
        public IceCell(int col, int row) : base(col, row) {
            CellType = CellType.Ice;
            Terminal = false;
        }

        protected override bool PirateComes(Pirate pirate) {
            var directionFrom = Position.GetDirectionFrom(pirate.Path.First());
            if(directionFrom == Direction.None) return false;

            pirate.Position.Move(directionFrom);

            var cells = Field.Cells(pirate.Position);
            pirate.Position = Position;
            Field.MovePirateTo(pirate, cells);

            return false;
        }
    }
}