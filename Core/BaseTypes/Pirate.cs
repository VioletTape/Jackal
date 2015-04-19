using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Core.Enums;
using Core.Extensions;

namespace Core.BaseTypes {
    public class Pirate : IHavePosition {

        public enum Actions {
            Free,
            Kill,
            Trap,
            Swim,
            Surrender,
            Ship,
            Drink
        }

        private readonly Ship ship;
        private readonly Team team;
        
        private bool isWithGold;
        private Position position;


        private readonly List<Position> path = new List<Position>();

        public ReadOnlyCollection<Position> Path {
            get { return path.AsReadOnly(); }
        }

        public Position Position {
            get { return position; }
            set {
                if (value.IsNotNull())
                    position = new Position(value);
            }
        }

        public TeamType TeamType
        {
            get { return team.Type; }
        }

        public PlayerState State { get; private set; }
        public TeamType Aliance;

        public bool IsTurnEnded { get; private set; }

        public Pirate(Team team) {
            this.team = team;
            ship = team.Ship;
        }

        // Actions

        public void EndTurn() {
            IsTurnEnded = true;
        }

        public void Free() {
            State = PlayerState.Free;
        }

        public void Kill() {
            LostGold();
            Ship();
            State = PlayerState.Dead;
        }

        public void Trap() {
            State = PlayerState.Trapped;
        }

        public void Swim() {
            LostGold();

            State = PlayerState.Swimming;
        }

        public void Surrender() {
            if (Position == ship.Position) return;

            LostGold();

            State = PlayerState.OnShip;
            Position = ship.Position;

            if (ship.IsNull() || ship.Cell.IsNull()) return;

            ship.Cell.AddPirate(this);
            path.Add(Position);
        }

        public void Ship() {
            DepositGold();

            Surrender();
        }

        public void Drink() {
            State = PlayerState.Drunked;
        }

        // methods

        public bool IsFriend(Pirate pirate) {
            return Aliance == pirate.TeamType
                   || pirate.TeamType == TeamType;
        }

        public void AddPathPoint(Position position) {
            path.Add(new Position(position));

            if (path.Count > 20)
                Kill();
        }

        public void ClearPath() {
            path.Clear();
        }

        public void DepositGold() {
            if (!isWithGold) return;
            
            ship.AddGold();
            LostGold();
        }

        public bool AccureGold() {
            if (isWithGold) return false;

            isWithGold = true;
            return true;
        }

        public void LostGold() {
            isWithGold = false;
        }
    }
}