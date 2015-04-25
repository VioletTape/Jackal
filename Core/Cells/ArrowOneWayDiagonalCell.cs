using Core.BaseTypes;
using Core.Enums;

namespace Core.Cells {
    public class ArrowOneWayDiagonalCell : Cell {
        private readonly Direction direction;

        public ArrowOneWayDiagonalCell(int col, int row) : base(col, row) {
            CellType = CellType.ArrowOneWayD;
            Terminal = false;

            direction = new DirectionHelper().RandomizeDiagonalDirection();
        }

        protected override bool PirateComes(Pirate pirate) {
            pirate.Position.Move(direction);

            var cells = Field.Cells(pirate.Position);
            Field.MovedPirateTo(pirate, cells);

            return false;
        }
    }
}