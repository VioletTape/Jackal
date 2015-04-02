using System.Collections.Generic;
using Core.Cells;
using Core.Enums;

namespace Core.BaseTypes {
    public class Ship : IHavePosition {
        public Player Player { get; private set; }

        public Position Position {
            get { return Cell.Position; }
        }

        public List<Pirate> Pirates;

        public int Gold { get; private set; }

        public Cell Cell { get; set; }

        public Ship(Player player, WaterCell cell) {
            Gold = 0;
            Player = player;
            Cell = cell;
            Pirates = new List<Pirate> {
                                           new Pirate(this),
                                           new Pirate(this),
                                           new Pirate(this),
                                       };

            cell.ShipComes(this);
        }

        public void AddGold() {
            Gold = Gold + 1;
        }

        public void MovedTo(Cell cell) {
            if(cell.CellType != CellType.Water)
                return;

            if(Pirates.Count >= 1)
                Cell = cell;
        }

        public bool IsMotherShip(Pirate pirate) {
            return true;
        }

        public bool Equals(Ship other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Player, Player);
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Ship)) return false;
            return Equals((Ship) obj);
        }

        public override int GetHashCode() {
            return Player.GetHashCode();
        }
    }
}