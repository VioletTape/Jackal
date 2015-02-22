using System;
using Core.BaseTypes;
using Core.Cells.CellTypes;
using Core.Enums;

namespace Core.Cells {
    public class CannonCell : Cell {
        private CannonDirection cannonDirection;
        private readonly Random random;

        public CannonCell(int col, int row) : base(col, row) {
            CellType = CellType.Cannon;
            Terminal = false;
            random = new Random();
            RandomizeCannonType();
        }

        private void RandomizeCannonType() {
            cannonDirection = (CannonDirection) random.Next(0, 4);
        }

        protected override bool PirateComes(Pirate pirate) {
            PirateWent(pirate);
            switch (cannonDirection) {
                case CannonDirection.East:
                    ReachEastBorder(pirate);
                    break;
                case CannonDirection.West:
                    ReachWestBorder(pirate);
                    break;
                case CannonDirection.North:
                    ReachNorthBorder(pirate);
                    break;
                case CannonDirection.South:
                    ReachSouthBorder(pirate);
                    break;
            }
            pirate.Swim();
            var cells = Field.Cells(pirate.Position);
            Field.MovedTo(cells);
            return false;
        }

        private static void ReachEastBorder(Pirate pirate) {
            try {
                while (true) {
                    pirate.Position.MoveE();
                }
            }
            catch (MovementException) {}
        }

        private static void ReachWestBorder(Pirate pirate) {
            try {
                while (true) {
                    pirate.Position.MoveW();
                }
            }
            catch (MovementException) {}
        }

        private static void ReachNorthBorder(Pirate pirate) {
            try {
                while (true) {
                    pirate.Position.MoveN();
                }
            }
            catch (MovementException) {}
        }

        private static void ReachSouthBorder(Pirate pirate) {
            try {
                while (true) {
                    pirate.Position.MoveS();
                }
            }
            catch (MovementException) {}
        }
    }
}