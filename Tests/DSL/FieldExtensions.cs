using System.Collections.Generic;
using Core.BaseTypes;
using Core.Enums;

namespace Tests.DSL {
    public static class FieldExtensions {
        public static Cell GetCellOfType(this Field field, CellType cellType) {
            return GetCells(field).Find(c => c.CellType == cellType);
        }


        public static List<Cell> GetCells(this Field field) {
            var cells = new List<Cell>();

            for (var i = 0; i < Position.MaxColumn; i++) {
                for (var j = 0; j < Position.MaxColumn; j++) {
                    cells.Add(field.Cells(i, j));
                }
            }

            return cells;
        }

        public static List<Cell> GetRow(this Field field, int rowNumber) {
            var cells = new List<Cell>();

            for (var j = 0; j < Position.MaxColumn; j++) {
                cells.Add(field.Cells(j, rowNumber));
            }

            return cells;
        }

        public static List<List<Cell>> GetRows(this Field field) {
            var cells = new List<List<Cell>>();

            for (var i = 0; i < Position.MaxColumn; i++) {
                var row = new List<Cell>();
                for (var j = 0; j < Position.MaxColumn; j++) {
                    row.Add(field.Cells(j, i));
                }
                cells.Add(row);
            }

            return cells;
        }

        public static List<Cell> GetColumn(this Field field, int colNumber) {
            var cells = new List<Cell>();

            for (var j = 0; j < Position.MaxColumn; j++) {
                cells.Add(field.Cells(j, colNumber));
            }

            return cells;
        }

        public static List<List<Cell>> GetColumns(this Field field) {
            var cells = new List<List<Cell>>();

            for (var i = 0; i < Position.MaxColumn; i++) {
                var column = new List<Cell>();
                for (var j = 0; j < Position.MaxColumn; j++) {
                    column.Add(field.Cells(i, j));
                }
                cells.Add(column);
            }

            return cells;
        }

        public static List<Cell> GetPlayableArea(this Field field) {
            var playableArea = new List<Cell>();
            for (var i = 1; i < Position.MaxColumn - 1; i++) {
                for (var j = 1; j < Position.MaxColumn - 1; j++) {
                    playableArea.Add(field.Cells(i, j));
                }
            }

            playableArea.Remove(field.Cells(1, 1));
            playableArea.Remove(field.Cells(1, Position.MaxColumn - 2));
            playableArea.Remove(field.Cells(Position.MaxColumn - 2, Position.MaxColumn - 2));
            playableArea.Remove(field.Cells(Position.MaxColumn - 2, 1));

            return playableArea;
        }

        public static void SetPirateOnCell(this Field field, Pirate pirate, Cell cell) {
            var cells = field.Cells(cell.Position);
            cells.PirateComing(pirate);
            pirate.ClearPath();
        }
    }
}