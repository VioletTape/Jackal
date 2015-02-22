using Core.BaseTypes;

namespace Tests.Cells {
    internal class StubCell : Cell {
        public StubCell(int col, int row) : base(col, row) {}
        public StubCell() : base(1, 1) {}

        protected override bool PirateComes(Pirate pirate) {
            base.PirateComes(pirate);

            KillFoesFor(pirate);

            return true;
        }

        public void SetGold(int gold) {
            base.GoldCoins = gold;
        }
    }
}