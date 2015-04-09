using System;
using System.Collections.Generic;
using System.Linq;
using Core.Cells;
using Core.Enums;
using Core.Extensions;

namespace Core.BaseTypes {
    public class Field {
        private List<List<Cell>> field;
        private readonly List<Cell> playableArea = new List<Cell>();
        private readonly int size;
        private readonly Random random;

        private Cell CurrentCell {
            get { return Cells(Pirate.Position); }
        }

        private List<Player> players = new List<Player>(4); 
        public Player CurrentPlayer { get; private set; }

        public List<Ship> Ships { get; private set; }

        public Ship CurrentShip { get; private set; }
        public Pirate Pirate { get; private set; }


        internal Field(IRule rule) {
            random = new Random();

            size = rule.Size;

            Position.MaxRow = size;
            Position.MaxColumn = size;

            InitEmptyField();

            GenerateSea();
            GenerateGrass();
//            GenerateShips(); todo: удалить и тесты проверить

            Generate(CellType.Amazon, rule.Amazon);
            Generate(CellType.Death, rule.Death);
            Generate(CellType.Trap, rule.Trap);
            Generate(CellType.Airplane, rule.Airplane);

            Generate(CellType.Jungle, rule.Jungle);
            Generate(CellType.Sands, rule.Sands);
            Generate(CellType.Swamp, rule.Swamp);
            Generate(CellType.Rocks, rule.Rocks);

            Generate(CellType.Cannon, rule.Cannon);
            Generate(CellType.Ice, rule.Ice);
            Generate(CellType.Fortress, rule.Fortress);
            Generate(CellType.Baloon, rule.Baloon);

            Generate(CellType.ArrowOneWayS, rule.ArrowOneWayS);
            Generate(CellType.ArrowOneWayD, rule.ArrowOneWayD);
            Generate(CellType.ArrowTwoWayD, rule.ArrowTwoWayD);
            Generate(CellType.ArrowTwoWayS, rule.ArrowTwoWayS);
            Generate(CellType.ArrowThreeWay, rule.ArrowThreeWay);
            Generate(CellType.ArrowFourWayD, rule.ArrowFourWayD);
            Generate(CellType.ArrowFourWayS, rule.ArrowFourWayS);

            GenerateGold(rule.Golds);

            LinkAllCells();

            CurrentShip = Ships[0];
        }

        private void InitEmptyField() {
            field = new List<List<Cell>>();
            for (var column = 0; column < size; column++) {
                field.Add(new List<Cell>());
            }
        }

        private void GenerateSea() {
            for (var i = 0; i < size; i++) {
                for (var j = 0; j < size; j++) {
                    field[i].Add(CellFactory.Create(CellType.Water, i, j));
                }
            }
        }

      private void GenerateGrass() {
            for (var i = 1; i < size - 1; i++) {
                for (var j = 1; j < size - 1; j++) {
                    var cell = CellFactory.Create(CellType.Grass, i, j);
                    field[i][j] = cell;
                    playableArea.Add(cell);
                }
            }

            playableArea.Remove(field[1][1]);
            playableArea.Remove(field[1][size - 2]);
            playableArea.Remove(field[size - 2][size - 2]);
            playableArea.Remove(field[size - 2][1]);

            field[1][1] = CellFactory.Create(CellType.Water, 1, 1);
            field[1][size - 2] = CellFactory.Create(CellType.Water, 1, size - 2);
            field[size - 2][size - 2] = CellFactory.Create(CellType.Water, size - 2, size - 2);
            field[size - 2][1] = CellFactory.Create(CellType.Water, size - 2, 1);
        }


        public void Generate(CellType cellType, int times) {
            times = times > playableArea.Count
                ? playableArea.Count
                : times;
            for (var i = 0; i < times; i++) {
                var cell = GetPlayableCell();
                var newType = CellFactory.Create(cellType, cell.Position.Column, cell.Position.Row);
                newType.Field = this;
                Draw(newType);
            }
        }

        private void GenerateGold(List<int> golds) {
            if (golds.Count != 5) return;

            Generate(CellType.Gold1, golds[0]);
            Generate(CellType.Gold2, golds[1]);
            Generate(CellType.Gold3, golds[2]);
            Generate(CellType.Gold4, golds[3]);
            Generate(CellType.Gold5, golds[4]);
        }

        private void LinkAllCells() {
            for (var i = 0; i < size; i++) {
                for (var j = 0; j < size; j++) {
                    field[i][j].Field = this;
                }
            }
        }


        private Cell GetPlayableCell() {
            var index = random.Next(0, playableArea.Count);

            var cell = playableArea[index];
            playableArea.Remove(cell);
            return cell;
        }


        public Cell Cells(int col, int row) {
            return field[col][row];
        }

        public Cell Cells(Position position) {
            return Cells(position.Column, position.Row);
        }

        public void Draw(Cell item) {
            field[item.Position.Column][item.Position.Row] = item;
            item.Field = this;
        }

        public List<Position> ChangedCells() {
            var positions = Ships
                .SelectMany(s => s.Pirates)
                .SelectMany(p => p.Path)
                .Distinct().ToList();

            return positions;
        }


        public bool SelectPirate(Cell cell) {
            if (Pirate.IsNotNull()) return false;

            Pirate = cell.GetPirateForPlayer(CurrentShip.TeamType);

            var pirateExists = Pirate.IsNotNull();
            if (pirateExists) {
                Pirate.ClearPath();
            }
            return pirateExists;
        }

        public void ReleasePirate() {
            if (Pirate.IsNull()) return;

            if (!Cells(Pirate.Position).Terminal)
                return;

            Pirate = null;
        }


        public void NextPlayer() {
            if (Pirate.IsNotNull()) return;

            var indexOf = Ships.IndexOf(CurrentShip);
            CurrentShip = Ships.Count == indexOf + 1
                ? Ships.First()
                : Ships[++indexOf];
        }


        public List<Position> MovedTo(Cell targetCell) {
            var changedPositions = new List<Position>();

            if (Pirate.IsNull()) return changedPositions;

            if (CanMove(targetCell)) {
                Move(targetCell);

                if (Pirate.IsNotNull() && Cells(Pirate.Position).Terminal)
                    ReleasePirate();

                changedPositions = ChangedCells();
            }

            return changedPositions;
        }

        private bool CanMove(Cell targetCell) {
            if (Pirate.IsNull()) return false;

            return CurrentCell.PirateCanMoveTo().Contains(targetCell);
        }

        private void Move(Cell targetCell) {
            if (Pirate.IsNull()) return;

            if (Pirate.Path.Count > 0 && Cells(Pirate.Path.Last()).Terminal)
                Pirate.ClearPath();

            if (CurrentCell.PirateWent(Pirate)) {
                targetCell.PirateComing(Pirate);
            }
        }
    }
}