using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Core.BaseTypes {
    public class ClassicRule : IRule {

        public virtual int NumberOfPlayers {
            get { return 4; }
        }

        public int Size { get; private set; }

        public int Amazon { get; private set; }
        public int Death { get; private set; }
        public int Airplane { get; private set; }
        public int Jungle { get; private set; }
        public int Sands { get; private set; }
        public int Swamp { get; private set; }
        public int Rocks { get; private set; }
        public int Cannon { get; private set; }

        public int Ice { get; private set; }
        public int Croco { get; private set; }
        public int Fortress { get; private set; }

        public int Baloon { get; private set; }
        public int Trap { get; private set; }
        public int Rum { get; private set; }

        public int ArrowOneWayD { get; private set; }
        public int ArrowOneWayS { get; private set; }
        public int ArrowTwoWayD { get; private set; }
        public int ArrowTwoWayS { get; private set; }
        public int ArrowThreeWay { get; private set; }
        public int ArrowFourWayD { get; private set; }
        public int ArrowFourWayS { get; private set; }

        public List<int> Golds { get; private set; }

        public ClassicRule() {
            Size = 13;

            Amazon = 1;
            Fortress = 2;
            Death = 1;
            Trap = 3;

            Airplane = 1;
            Baloon = 2;

            Rocks = 1;
            Swamp = 2;
            Sands = 4;
            Jungle = 5;

            Cannon = 2;

            Ice = 6;
            Croco = 4;
            Rum = 4;

            ArrowOneWayD = 3;
            ArrowOneWayS = 3;
            ArrowTwoWayD = 3;
            ArrowTwoWayS = 3;
            ArrowThreeWay = 3;
            ArrowFourWayD = 3;
            ArrowFourWayS = 3;


            // по кол-ву монет        1  2  3  4  5 
            Golds = new List<int>(5) {5, 5, 3, 2, 1};
        }
    }
}