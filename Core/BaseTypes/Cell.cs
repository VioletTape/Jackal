using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Core.Cells;
using Core.Enums;
using Core.Extensions;

namespace Core.BaseTypes {
    public abstract class Cell : IHavePosition {
        private readonly List<Pirate> pirates;
        protected readonly Position position;
        internal int GoldCoins;
        private readonly Random random;

        protected bool GoldCoinsExists {
            get { return GoldCoins > 0; }
        }

        public Field Field { get; set; }
        public CellType CellType { get; protected set; }
        public CellOrientation Orientation { get; protected set; }

        public Position Position {
            get { return position; }
        }

        public bool Discoverd { get; protected set; }
        public bool Terminal { get; protected set; }
        public bool MultiStep { get; protected set; }

        public ReadOnlyCollection<Pirate> Pirates {
            get { return pirates.AsReadOnly(); }
        }

        protected Cell(int col, int row) {
            Orientation = CellOrientation.North;
            pirates = new List<Pirate>();
            Discoverd = false;
            Terminal = true;
            MultiStep = false;

            position = new Position(row, col);
            random = new Random();
        }

        internal void RandomizeOrientation() {
            Orientation = (CellOrientation) random.Next(0, 4);
        }

        

        public bool ContainsPirateFor(Player player) {
            return pirates.Any(p => p.Player == player);
        }

        public Pirate GetPirateForPlayer(Player player) {
            if (ContainsPirateFor(player))
                return pirates.Where(p => p.State != PlayerState.Dead).First();

            return null;
        }

        public void AddPirate(Pirate pirate) {
            if (CellType == CellType.Water) {
                if (((WaterCell) this).Ship.IsNotNull())
                    if (!((WaterCell) this).Ship.IsMotherShip(pirate)) {
                        pirate.Kill();
                        return;
                    }
                    else {
                        pirate.Ship();
                    }
            }
            pirates.Add(pirate);
        }


        public virtual bool PirateCanComeFrom(Cell fromCell) {
            return true;
        }


        public void PirateComing(Pirate pirate) {
            Discoverd = true;
            if (pirate.Position.IsNotNull())
                pirate.AddPathPoint(pirate.Position);

            pirate.Position = Position;
            pirate.AddPathPoint(Position);

            if (PirateComes(pirate))
                AddPirate(pirate);
        }

        protected virtual bool PirateComes(Pirate pirate) {
            return true;
        }

        public virtual bool PirateWent(Pirate pirate) {
            pirates.Remove(pirate);

            return true;
        }

        internal virtual List<Cell> PirateCanMoveTo() {
            return GeneralPossibleMoves();
        }

        internal List<Cell> GeneralPossibleMoves() {
            var directions = Enum.GetValues(typeof (Direction))
                .Cast<Direction>()
                .Except(ExcludedDirections())
                .Select(dir => {
                            var init = new Position(Position);
                            var moved = new Position(Position);
                            try {
                                moved.Move(dir);
                            }
                            catch (MovementException) {
                                return Field.Cells(init);
                            }
                            var cell = Field.Cells(moved);
                            return cell.PirateCanComeFrom(this) 
                                ? cell 
                                : Field.Cells(init);
                        })
                .Union(new[] {Field.Cells(Position)})
                .Distinct()
                .ToList();

            return directions;
        }

        public virtual List<Direction> ExcludedDirections() {
            return new List<Direction> {
                                           Direction.None
                                       };
        }

        protected void KillFoesFor(Pirate pirate) {
            KillFoesFor(pirates, pirate);
        }

        internal void KillFoesFor(List<Pirate> pirates, Pirate pirate) {
            if (pirates.All(pirate.IsFriend)) return;

            pirates.ForEach(p => p.Surrender());
            pirates.Clear();
        }

        public override string ToString() {
            var pirates = "";
            if (this.pirates.Count > 0)
                pirates = ":" + this.pirates.Count;
            return Discoverd
                       ? string.Format("{0}{1}", CellType.ToString().Substring(0, 3), pirates)
                       : "?";
        }

        internal void GiveGoldToPirate(Pirate pirate) {
            if (pirate.AccrueGold() && GoldCoinsExists)
                GoldCoins--;
        }

        protected bool Equals(Cell other) {
            return Equals(position, other.position) && CellType == other.CellType;
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) {
                return false;
            }
            if (ReferenceEquals(this, obj)) {
                return true;
            }
            if (obj.GetType() != this.GetType()) {
                return false;
            }
            return Equals((Cell) obj);
        }

         public static bool operator ==(Cell left, Cell right) {
            return Equals(left, right);
        }

        public static bool operator !=(Cell left, Cell right) {
            return !Equals(left, right);
        }

        public override int GetHashCode() {
            unchecked {
                return ((position != null ? position.GetHashCode() : 0) * 397) ^ (int) CellType;
            }
        }
    }
}