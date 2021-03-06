﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Core.Enums;
using Core.Extensions;
using Core.Infrastructure;

namespace Core.BaseTypes {
    public class Field {
        internal readonly List<List<Cell>> field;
        internal readonly List<Cell> playableArea = new List<Cell>();
        internal readonly int size;
        internal readonly Random random;

        internal CurcuitList<Player> players;
        public List<Ship> Ships { get; internal set; }

        public Player CurrentPlayer {
            get { return players.Current; }
        }

        public Player GetNextPlayer() {
            players.GetNext().StartTurn();
            return CurrentPlayer;
        }

        public Field(IRule rule) {
            field = new List<List<Cell>>();
            random = new Random();

            size = rule.Size;

            Position.MaxRow = size;
            Position.MaxColumn = size;

            InitEmptyField();

            GenerateSea();
            GenerateGrass();
            GeneratePlayers(rule);

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

            LinkAllCellsToField();
        }

        // for testing purposes
        internal Field(IRule rule, int justForTesting) {
            field = new List<List<Cell>>();
            random = new Random();

            size = rule.Size;

            Position.MaxRow = size;
            Position.MaxColumn = size;

            InitEmptyField();

            GenerateSea();

            LinkAllCellsToField();
        }

        internal void GeneratePlayers(IRule rule) {
            var p = new List<Player>(rule.NumberOfPlayers);
            Ships = new List<Ship>();

            if (rule.NumberOfPlayers == 2) {
                var player = new Player(0, (TeamType) 2, rule);
                Ships.Add(player.CurrentTeam.Ship);
                Ships.Add(player.GetNextTeam().Ship);
                p.Add(player);


                player = new Player((TeamType) 1, (TeamType) 3, rule);
                Ships.Add(player.CurrentTeam.Ship);
                Ships.Add(player.GetNextTeam().Ship);
                p.Add(player);
            }
            else {
                for (var i = 0; i < rule.NumberOfPlayers; i++) {
                    var player = new Player((TeamType) i, rule);
                    Ships.Add(player.CurrentTeam.Ship);
                    p.Add(player);
                }
            }


            players = new CurcuitList<Player>(p);
        }

        internal void InitEmptyField() {
            for (var column = 0; column < size; column++) {
                field.Add(new List<Cell>());
            }
        }

        internal void GenerateSea() {
            for (var i = 0; i < size; i++) {
                for (var j = 0; j < size; j++) {
                    field[i].Add(CellFactory.Create(CellType.Water, i, j));
                }
            }
        }

        internal void GenerateGrass() {
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

        internal void GenerateGold(List<int> golds) {
            if (golds.Count != 5) {
                return;
            }

            Generate(CellType.Gold1, golds[0]);
            Generate(CellType.Gold2, golds[1]);
            Generate(CellType.Gold3, golds[2]);
            Generate(CellType.Gold4, golds[3]);
            Generate(CellType.Gold5, golds[4]);
        }

        internal void LinkAllCellsToField() {
            for (var i = 0; i < size; i++) {
                for (var j = 0; j < size; j++) {
                    field[i][j].Field = this;
                }
            }
        }

        internal Cell GetPlayableCell() {
            var index = random.Next(0, playableArea.Count);

            var cell = playableArea[index];
            playableArea.Remove(cell);
            return cell;
        }

        [DebuggerStepThrough]
        public Cell Cells(int col, int row) {
            return field[col][row];
        }

        [DebuggerStepThrough]
        public Cell Cells(Position position) {
            return Cells(position.Column, position.Row);
        }

        public void Draw(Cell item) {
            field[item.Position.Column][item.Position.Row] = item;
            item.Field = this;
        }


        public List<Position> ChangedCells() {
           var positions = Ships.SelectMany(s => s.Pirates)
                .SelectMany(p => p.Path)
                .Distinct();
             
            return positions.ToList();
        }


        public Pirate SelectPirate(Cell cell) {
            var pirate = cell.GetPirates()
                             .FirstOrDefault(p => !p.IsTurnEnded);
            return pirate;
        }

        public List<Pirate> GetPirates(Cell cell) {
            return cell.Pirates.ToList();
        }

        public List<Position> MovePirateTo(Pirate pirate, Cell targetCell) {
            var changedPositions = new List<Position>();

            if (!CanMove(pirate, targetCell)) {
                return changedPositions;
            }

            Move(pirate, targetCell);

            if (Cells(pirate.Position).Terminal) {
                pirate.EndTurn();
            }

            return pirate.Path.ToList();
        }

        internal bool CanMove(Pirate pirate, Cell targetCell) {
            var currentCell = Cells(pirate.Position);

            var generalPossibleMoves = currentCell.GeneralPossibleMoves().Contains(targetCell);

            var pirateCanCome = targetCell.PirateCanComeFrom(currentCell);
            return pirateCanCome && generalPossibleMoves;
        }

        internal void Move(Pirate pirate, Cell targetCell) {
            var currentCell = Cells(pirate.Position);

            currentCell.PirateWentBase(pirate);
            targetCell.PirateComing(pirate);
        }
    }
}