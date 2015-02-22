using System;
using System.Collections.Generic;
using Core.BaseTypes;
using Core.Cells;
using Core.Enums;

namespace Core {
    /// <summary>
    /// 
    /// </summary>
    public static class CellFactory {
        private static readonly Dictionary<CellType, Type> Cells = new Dictionary<CellType, Type> {
                                                                                                      {CellType.Water, typeof (WaterCell)},
                                                                                                      {CellType.Grass, typeof (GrassCell)},
                                                                                                      {CellType.Amazon, typeof (AmazonCell)},
                                                                                                      {CellType.Airplane, typeof (AirplaneCell)},
                                                                                                      {CellType.Death, typeof (DeathCell)},
                                                                                                      {CellType.Jungle, typeof (JungleCell)},
                                                                                                      {CellType.Sands, typeof (SendsCell)},
                                                                                                      {CellType.Swamp, typeof (SwampCell)},
                                                                                                      {CellType.Rocks, typeof (RocksCell)},
                                                                                                      {CellType.Cannon, typeof (CannonCell)},
                                                                                                      {CellType.Gold1, typeof (GoldCellOne)},
                                                                                                      {CellType.Gold2, typeof (GoldCellTwo)},
                                                                                                      {CellType.Gold3, typeof (GoldCellThree)},
                                                                                                      {CellType.Gold4, typeof (GoldCellFour)},
                                                                                                      {CellType.Gold5, typeof (GoldCellFive)},
                                                                                                      {CellType.Ice, typeof (IceCell)},
                                                                                                      {CellType.Fortress, typeof (FortressCell)},
                                                                                                      {CellType.Baloon, typeof (BaloonCell)},
                                                                                                      {CellType.Trap, typeof (TrapCell)},
                                                                                                      {CellType.Croco, typeof (CrocoCell)},
                                                                                                      {CellType.ArrowOneWayS, typeof (ArrowOneWayStraightCell)},
                                                                                                      {CellType.ArrowOneWayD, typeof (ArrowOneWayDiagonalCell)},
                                                                                                      {CellType.ArrowTwoWayS, typeof (ArrowTwoWayStraightCell)},
                                                                                                      {CellType.ArrowTwoWayD, typeof (ArrowTwoWayDiagonalCell)},
                                                                                                      {CellType.ArrowThreeWay, typeof (ArrowThreeWayCell)},
                                                                                                      {CellType.ArrowFourWayS, typeof (ArrowFourWayStraightCell)},
                                                                                                      {CellType.ArrowFourWayD, typeof (ArrowFourWayDiagonalCell)},
                                                                                                  };


        public static Cell Create(CellType cellType, int col, int row) {
            var cell = (Cell) Cells[cellType].GetConstructor(new[] {typeof (Int32), typeof (Int32)}).Invoke(new object[] {col, row});

            return cell;
        }
    }
}