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
                if (value.IsNotNull()) {
                    position = new Position(value);
                }
            }
        }

        public TeamType TeamType {
            get { return team.Type; }
        }

        public PlayerState State { get; private set; }

        private Dictionary<Actions, Action> pirateActions;

        public bool IsTurnEnded { get; private set; }

        public Pirate(Team team) {
            InitActionList();

            this.team = team;
            ship = team.Ship;
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

        public void EndTurn() {
            IsTurnEnded = true;
        }

        private void Free() {
            State = PlayerState.Free;
        }

        private void Kill() {
            LostGold();
            Ship();
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

            if (ship.IsNull() ||
                ship.Cell.IsNull()) {
                return;
            }

            ship.Cell.AddPirate(this);
            path.Add(Position);
        }

        private void Ship() {
            DepositGold();

            Surrender();
        }

        private void Drink() {
            State = PlayerState.Drunked;
        }

        // methods

        public void StartTurn() {
            IsTurnEnded = false;
        }

        public bool IsFriend(Pirate pirate) {
            return IsInAllianceWith(pirate);
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
    }
}