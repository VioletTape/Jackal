using System.Linq;
using Core.BaseTypes;
using Core.Cells;
using Core.Enums;

namespace Tests.DSL {
    public class Players {
//        public static 
    }


    public static class Black {
        public static Ship Ship { get; private set; }


        static Black() {
            Ship = new Ship(Player.Black, new WaterCell(1, 1));
        }

        public static Pirate Pirate {
            get { return Ship.Pirates.First(); }
        }

        public static Pirate Pirate2 {
            get { return Ship.Pirates[1]; }
        }

        public static void Reset() {
            Ship = new Ship(Player.Black, new WaterCell(1, 1));
        }
    }

    public static class Red {
        public static Ship Ship { get; private set; }


        static Red() {
            Ship = new Ship(Player.Red, new WaterCell(1, 1));
        }

        public static Pirate Pirate {
            get { return Ship.Pirates.First(); }
        }

        public static void Reset() {
            Ship = new Ship(Player.Red, new WaterCell(1, 1));
        }
    }
}