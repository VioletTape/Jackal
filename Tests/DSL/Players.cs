using System.Linq;
using Core.BaseTypes;
using Core.Enums;
using Tests.RulesForTesting;

namespace Tests.DSL {
    public static class Black {
        private static Team team1;
        public static Ship Ship { get; private set; }


        static Black() {
            Reset();
        }

        public static Pirate Pirate {
            get { return team1.Pirates.First(); }
        }

        public static Pirate Pirate2 {
            get { return team1.Pirates.GetNext(); }
        }

        public static void Reset() {
            team1 = new Team(TeamType.Black, new TestEmptyRules(4));
            Ship = team1.Ship;
        }
    }

    public static class Red {
        private static Team team1;
        public static Ship Ship { get; private set; }


        static Red() {
            Reset();
        }

        public static Pirate Pirate {
            get { return team1.Pirates.First(); }
        }

        public static void Reset() {
            team1 = new Team(TeamType.Red, new TestEmptyRules(4));
            Ship = team1.Ship;
        }
    }
}