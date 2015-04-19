using System.Linq;
using Core.BaseTypes;
using Core.Cells;
using Core.Enums;
using Tests.RulesForTesting;

namespace Tests.DSL {
    public static class Black {
        private static Team team1;
        public static Ship Ship { get; private set; }


        static Black() {
            team1 = new Team(TeamType.Black, new TestEmptyRules(4));
            Ship = new Ship(team1, new WaterCell(1, 1));
        }

        public static Pirate Pirate {
            get { return Ship.Pirates.First(); }
        }

        public static Pirate Pirate2 {
            get { return Ship.Pirates[1]; }
        }

        public static void Reset() {
            Ship = new Ship(team1, new WaterCell(1, 1));
        }
    }

    public static class Red {
        private static Team team1;
        public static Ship Ship { get; private set; }


        static Red() {
            team1 = new Team(TeamType.Red, new TestEmptyRules(4));

            Ship = new Ship(team1, new WaterCell(1, 1));
        }

        public static Pirate Pirate {
            get { return Ship.Pirates.First(); }
        }

        public static void Reset() {
            Ship = new Ship(team1, new WaterCell(1, 1));
        }
    }
}