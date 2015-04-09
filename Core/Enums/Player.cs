using System.Collections.Generic;
using Core.BaseTypes;

namespace Core.Enums {
    public class Player {
        private readonly Team team;
        private readonly List<Team> playerTypes = new List<Team>();

        public Player(TeamType type, IRule rule) {
            team = new Team(type, rule);
        }

        public void AddPlayerType(TeamType type, IRule rule) {
            playerTypes.Add(new Team(type, rule));
        }
    }
}