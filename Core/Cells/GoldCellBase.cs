using Core.BaseTypes;
using Core.Enums;

namespace Core.Cells {
    public abstract class GoldCellBase : Cell {
        protected GoldCellBase(int coins, int col, int row) : base(col, row) {
            GoldCoins = coins;
        }

        protected override bool PirateComes(Pirate pirate) {
            KillFoesFor(pirate);
            return true;
        }
    }

    public class GoldCellOne : GoldCellBase {
        public GoldCellOne(int col, int row) : base(1, col, row) {
            CellType = CellType.Gold1;
        }
    }

    public class GoldCellTwo : GoldCellBase {
        public GoldCellTwo(int col, int row) : base(2, col, row) {
            CellType = CellType.Gold2;
        }
    }

    public class GoldCellThree : GoldCellBase {
        public GoldCellThree(int col, int row) : base(3, col, row) {
            CellType = CellType.Gold3;
        }
    }

    public class GoldCellFour : GoldCellBase {
        public GoldCellFour(int col, int row) : base(4, col, row) {
            CellType = CellType.Gold4;
        }
    }

    public class GoldCellFive : GoldCellBase {
        public GoldCellFive(int col, int row) : base(5, col, row) {
            CellType = CellType.Gold5;
        }
    }
}