using System;
using System.Collections.Generic;
using System.Linq;
using Core.BaseTypes;
using Core.Cells.CellTypes;
using Core.Enums;

namespace Core.Cells {
    public class WaterCell : Cell {
        public WaterType WaterType { get; private set; }

        public WaterCell(int col, int row) : base(col, row) {
            CellType = CellType.Water;
            RandomizeWaterType();
            Discoverd = true;
        }

        public WaterCell(Position position) : this(position.Column, position.Row) {}

        private void RandomizeWaterType() {
            WaterType = (WaterType) new Random().Next(0, 4);
        }

        protected override bool PirateComes(Pirate pirate) {
            if (IsShipHere()) {
                pirate.ApplyCommand(
                    GetShip().IsMotherShip(pirate)
                        ? Pirate.Actions.Ship
                        : Pirate.Actions.Kill
                    );
            }
            else {
                pirate.ApplyCommand(Pirate.Actions.Swim);
                pirate.LostGold();
                KillFoesFor(pirate);
            }

            return true;
        }

        public override bool PirateCanComeFrom(Cell fromCell) {
            switch (fromCell.CellType) {
                case CellType.Water:
                    //                    var waterCell = ((WaterCell) fromCell);
                    //                    return waterCell.Ship.IsNull();
                    return true;
                case CellType.Cannon:
                case CellType.Ice:
                case CellType.Airplane:
                case CellType.ArrowOneWayS:
                    return true;
                default:
                    return false;
            }
        }

        //        public void ShipComes(Ship ship) {
        //            Ship = ship;
        //            Ship.Cell = this;
        //        }
        //
        //        public bool ShipLeaves() {
        //            Ship = null;
        //            return true;
        //        }

        public override List<Direction> ExcludedDirections() {
            // todo
            //            if (Ship.IsNotNull()) {
            //                return new List<Direction> {
            //                                               Direction.SW,
            //                                               Direction.SE,
            //                                               Direction.NE,
            //                                               Direction.NW,
            //                                               Direction.None
            //                                           };
            //            }

            return new List<Direction> {
                                           Direction.None
                                       };
        }

        private bool IsShipHere() {
            return Field.Ships.Any(s => s.Cell.Equals(this));
        }

        private Ship GetShip() {
            return Field.Ships.Single(s => s.Cell.Equals(this));
        }
    }
}