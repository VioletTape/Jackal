using Core.BaseTypes;
using Core.Enums;

namespace Core.Cells {
    public class ArrowOneWayStraightCell : Cell {
        private readonly Direction direction;

        public ArrowOneWayStraightCell(int col, int row) : base(col, row) {
            CellType = CellType.ArrowOneWayS;
            Terminal = false;

            direction = new DirectionHelper().RandomizeStraightDirection();
        }

         protected override bool PirateComes(Pirate pirate) {
             pirate.Position.Move(direction);

            var cells = Field.Cells(pirate.Position);
            Field.MovedTo(cells);

            return false;
        }
    }
}