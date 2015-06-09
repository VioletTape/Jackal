using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Core.Enums;
using Core.Extensions;

namespace Core.BaseTypes {
    public class Pirate : IHavePosition {
        private Dictionary<Actions, Action> pirateActions;
        private readonly Ship ship;
        private readonly Team team;

        private bool isWithGold;
        private Position position;

        private readonly List<Position> path = new List<Position>();

        private readonly Guid id = Guid.NewGuid();

        public enum Actions {
            Free,
            Kill,
            Trap,
            Swim,
            Surrender,
            Ship,
            Drink
        }


        public ReadOnlyCollection<Position> Path {
            get { return path.AsReadOnly(); }
        }

        public Position Position {
            get { return position; }
            set {
                if (value.IsNotNull()) {
                    position = new Position(value);
                }
            }
        }

        public TeamType TeamType {
            get { return team.Type; }
        }

        public PlayerState State { get; private set; }


        public bool IsTurnEnded { get; private set; }

        public Pirate(Team team) {
            InitActionList();

            this.team = team;
            ship = team.Ship;
            path.Add(position);
        }

        // Actions

        private void InitActionList() {
            pirateActions = new Dictionary<Actions, Action> {
                {Actions.Drink, Drink},
                {Actions.Free, Free},
                {Actions.Kill, Kill},
                {Actions.Trap, Trap},
                {Actions.Swim, Swim},
                {Actions.Surrender, Surrender},
                {Actions.Ship, Ship}
            };
        }

        public void ApplyCommand(Actions action) {
            pirateActions[action].Invoke();
            EndTurn();
        }

        private void Free() {
            State = PlayerState.Free;
        }

        private void Kill() {
            LostGold();
            State = PlayerState.Dead;
        }

        private void Trap() {
            State = PlayerState.Trapped;
        }

        private void Swim() {
            LostGold();

            State = PlayerState.Swimming;
        }

        private void Surrender() {
            if (Position == ship.Position) {
                return;
            }

            LostGold();

            State = PlayerState.OnShip;
            Position = ship.Position;

//            ship.Cell.AddPirate(this);
            path.Add(Position);
        }

        private void Ship() {
            DepositGold();
            // todo : check conditions
            ship.Pirates.Add(this);

            State = PlayerState.OnShip;
            Position = ship.Position;
        }

        private void Drink() {
            State = PlayerState.Drunked;
        }

        // methods

        public void StartTurn() {
            IsTurnEnded = false;
            path.Clear();
            path.Add(position);
        }

        public void EndTurn() {
            IsTurnEnded = true;
        }


        public void AddPathPoint(Position position) {
            path.Add(new Position(position));

            if (path.Count > 20) {
                Kill();
            }
        }

        public void ClearPath() {
            path.Clear();
        }


        public void DepositGold() {
            if (!isWithGold) {
                return;
            }

            ship.AddGold();
            LostGold();
        }

        public bool AccureGold() {
            if (isWithGold) {
                return false;
            }

            isWithGold = true;
            return true;
        }

        public void LostGold() {
            isWithGold = false;
        }


        public bool IsInAllianceWith(Pirate pirate) {
            return team.IsInAlianceWith(pirate.team);
        }

        // ====== equality ==================================

        protected bool Equals(Pirate other) {
            return id.Equals(other.id);
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) {
                return false;
            }
            if (ReferenceEquals(this, obj)) {
                return true;
            }
            if (obj.GetType() != GetType()) {
                return false;
            }
            return Equals((Pirate) obj);
        }

        public override int GetHashCode() {
            return id.GetHashCode();
        }
    }
}