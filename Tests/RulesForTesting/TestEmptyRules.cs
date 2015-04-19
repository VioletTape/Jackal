using System.Collections.Generic;
using Core.BaseTypes;

namespace Tests.RulesForTesting {
    internal class TestEmptyRules : IRule {
	    public int NumberOfPlayers { get; set; }


        public int Size { get; set; }

        public int Amazon { get; set; }
        public int Death { get; set; }
        public int Trap { get; set; }
        public int Airplane { get; set; }
        public int Baloon { get; set; }
        public int Jungle { get; set; }
        public int Sands { get; set; }
        public int Swamp { get; set; }
        public int Rocks { get; set; }
        public int Cannon { get; set; }

        public List<int> Golds { get; set; }

        public int Ice { get; set; }
        public int Fortress { get; set; }

        public int ArrowOneWayD { get; set; }
        public int ArrowOneWayS { get; set; }
        public int ArrowTwoWayD { get; set; }
        public int ArrowTwoWayS { get; set; }
        public int ArrowThreeWay { get; set; }
        public int ArrowFourWayD { get; set; }
        public int ArrowFourWayS { get; set; }

        public TestEmptyRules(int numberOfPlayers = 4) {
            Size = 13;

	        NumberOfPlayers = numberOfPlayers;

            // по кол-ву монет        1  2  3  4  5 
            Golds = new List<int>();
        }
    }
}