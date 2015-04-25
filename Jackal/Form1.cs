using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Core.BaseTypes;
using Core.Extensions;

namespace Jackal {
    public partial class Form1 : Form {
        private readonly int size;
        private readonly Field field;

        private readonly ClassicRule classicRule;

        public Form1() {
            InitializeComponent();

            classicRule = new ClassicRule();
            field = new Field(classicRule);
            size = classicRule.Size;

            var dimension = 70;
            SetupField(dimension);
            CreateVisual(field);

            RedrawCells(field.ChangedCells());
            NextPlayer();
        }

        private void NextPlayer() {
            field.GetNextPlayer();
            // todo: highlight player
            //            var control = (Label) gameField.GetControlFromPosition(field.CurrentShip.Position.Column, field.CurrentShip.Position.Row);
            //            control.Font = new Font(control.Font.FontFamily, control.Font.Size, FontStyle.Bold);
        }

        private void SetupField(int dimension) {
            gameField.Size = new Size(dimension * size, dimension * size);
            gameField.ColumnCount = size;
            gameField.RowCount = size;

            for (var i = 0; i < size; i++) {
                gameField.RowStyles[i].Height = dimension;
                gameField.ColumnStyles[i].Width = dimension;
            }

            gameField.MouseClick += GameMove;
        }

        private void GameMove(object sender, MouseEventArgs e) {
            if (sender as Label == null) {
                return;
            }

            var position = gameField.GetPositionFromControl((Label) sender);
            var targetCell = field.Cells(position.Column, position.Row);

            if (e.Button == MouseButtons.Right) {
                var add = "";
                //                if(targetCell is Arrow1Cell) {
                //                    add = ((Arrow1Cell) targetCell).direction.ToString();
                //                }
                label1.Text = string.Format("col={0}  row={1} {2}", targetCell.Position.Column, targetCell.Position.Row, add);
                if (targetCell.Pirates.Count > 0) {
                    label2.Text = string.Format("Pirates {0} {1}", targetCell.Pirates.Count, targetCell.Pirates[0].TeamType);
                }
                else {
                    label2.Text = "No Pirates";
                }

                field.ReleasePirate();
                return;
            }
            var selectPirate = field.SelectPirate(targetCell);
            if (selectPirate.IsNotNull()) {
                var changedCells = field.MovedPirateTo(selectPirate, targetCell);

                if (changedCells.NotEmpty()) {
                    RedrawCells(changedCells);
                    NextPlayer();
                }
                else {
                    field.SelectPirate(targetCell);
                }
            }
        }

        private void RedrawCells(List<Position> positions) {
            foreach (var position in positions) {
                var control = (Label) gameField.GetControlFromPosition(position.Column, position.Row);
                var cell = field.Cells(position.Column, position.Row);

                control.Text = cell.ToString();
                control.Font = new Font(control.Font.FontFamily, control.Font.Size, FontStyle.Regular);
            }
        }

        private void CreateVisual(Field field) {
            for (var column = 0; column < size; column++) {
                for (var row = 0; row < size; row++) {
                    var control = new Label {
                                                Text = field.Cells(column, row).ToString()
                                            };
                    control.MouseClick += GameMove;

                    gameField.Controls.Add(control, column, row);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            NextPlayer();
        }
    }
}