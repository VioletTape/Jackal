using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
            get {
                var list = new List<Pirate>();
                list.AddRange(pirates);
                list.AddRange(GetPirates());
                return list.AsReadOnly();
            }
        }

        internal virtual List<Pirate> GetPirates() {
            return new List<Pirate>();
        } 


        protected Cell(int col, int row) {
            Orientation = CellOrientation.North;
            pirates = new List<Pirate>();
            Discoverd = false;
            Terminal = true;
            MultiStep = false;

            position = new Position(col, row);
            random = new Random();
        }

        internal void RandomizeOrientation() {
            Orientation = (CellOrientation) random.Next(0, 4);
        }

        

        public bool ContainsBuddyFor(Pirate pirate) {
            return pirates.Any(pirate.IsInAllianceWith);
        }

        public Pirate GetPirateForPlayer(TeamType teamType) {
            if (Pirates.Any(p => p.TeamType == teamType))
                return pirates.First(p => p.State != PlayerState.Dead);

            return null;
        }

        internal void AddPirate(Pirate pirate) {
            pirate.Position = Position;
            pirates.Add(pirate);
        }

        // === general action flow =====

        internal virtual bool PirateCanComeFrom(Cell fromCell) {
            
            return true;
        }

        public virtual bool PirateWentBase(Pirate pirate) {
            pirate.AddPathPoint(Position);
            pirates.Remove(pirate);

            return PirateWent(pirate);
        }

        public virtual bool PirateWent(Pirate pirate){
           return true;
        }


        public void PirateComing(Pirate pirate) {
            Discoverd = true;

            pirate.Position = Position;
            pirate.AddPathPoint(Position);

            if (PirateComes(pirate))
                AddPirate(pirate);
        }



        protected virtual bool PirateComes(Pirate pirate) {
            return true;
        }


        // ===== general action flow ends =======

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
            if (pirates.All(pirate.IsInAllianceWith)) return;

            pirates.ForEach(p => p.ApplyCommand(Pirate.Actions.Surrender));
            pirates.Clear();
        }


        public override string ToString() {
           var format = string.Format("{0} p{1} c({2},{3})", CellType.ToString().Substring(0, 3), Field.GetPirates(this).Count, position.Column, position.Row);
            
           return Discoverd
                       ? format
                       : "?";
        }


        internal void GiveGoldToPirate(Pirate pirate) {
            if (pirate.AccureGold() && GoldCoinsExists)
                GoldCoins--;
        }

        // ========= equality ===============================

        [DebuggerStepThrough]
        protected bool Equals(Cell other) {
            return Equals(position, other.position) && CellType == other.CellType;
        }

        [DebuggerStepThrough]
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

        [DebuggerStepThrough]
         public static bool operator ==(Cell left, Cell right) {
            return Equals(left, right);
        }

        [DebuggerStepThrough]
        public static bool operator !=(Cell left, Cell right) {
            return !Equals(left, right);
        }

        [DebuggerStepThrough]
        public override int GetHashCode() {
            unchecked {
                return ((position != null ? position.GetHashCode() : 0) * 397) ^ (int) CellType;
            }
        }
    }
}