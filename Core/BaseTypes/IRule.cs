using System.Collections.Generic;

namespace Core.BaseTypes {
    public interface IRule {

        int NumberOfPlayers { get; }
        int Size { get; }
        int Amazon { get; }
        int Death { get; }
        int Airplane { get; }
        int Jungle { get; }
        int Sands { get; }
        int Swamp { get; }
        int Rocks { get; }
        int Cannon { get; }
        List<int> Golds { get; }
        int Ice { get; }
        int Fortress { get; }
        int Baloon { get; }
        int Trap { get; }

        int ArrowOneWayD { get; }
        int ArrowOneWayS { get; }
        int ArrowTwoWayD { get; }
        int ArrowTwoWayS { get; }
        int ArrowThreeWay { get; }
        int ArrowFourWayD { get; }
        int ArrowFourWayS { get; }
    }
}