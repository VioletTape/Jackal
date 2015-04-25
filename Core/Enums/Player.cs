using System.Collections.Generic;
using Core.BaseTypes;

namespace Core.Enums {
    public class Player {
        private int index = 0;
        private readonly List<Team> teams = new List<Team>(2);

        public Player(TeamType type, IRule rule) {
            var team = new Team(type, rule);
            teams.Add(team);

            team.Player = this;
        }

        public Player(TeamType type1, TeamType type2, IRule rule) : this(type1, rule) {
            var team = new Team(type2, rule);
            teams.Add(team);

            team.Player = this;
        }

        public Team CurrentTeam {
            get { return teams[index]; }
        }

        public void StartTurn() {
            GetNextTeam();
            CurrentTeam.StartTurn();
        }

        public Team GetNextTeam() {
             index++;
            index = index % teams.Count;
            var team = teams[index];
           
            return team;
        }


    }
}