using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Core.BaseTypes;
using Core.Extensions;

namespace Jackal {
    public partial class Form1 : Form {
        private readonly int size;
        private readonly Field field;

        private readonly ClassicRule classicRule;
        private Pirate pirate;

        public Form1() {
            InitializeComponent();

            classicRule = new ClassicRule();
            field = new Field(classicRule);
            size = classicRule.Size;

            const int dimension = 70;
            SetupField(dimension);
            CreateVisual(field);

            RedrawCells(field.ChangedCells());
            NextPlayer();
        }

        private void NextPlayer() {
            field.GetNextPlayer();
            pirate = field.CurrentPlayer.CurrentTeam.Pirates.Current;

            var control = (Label)gameField.GetControlFromPosition(pirate.Position.Column, pirate.Position.Row);
            control.Font = new Font(control.Font.FontFamily, control.Font.Size, FontStyle.Bold);
        }

        private void SetupField(int dimension) {
            gameField.Size = new Size(dimension*size, dimension*size);
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

                label1.Text = string.Format("col={0}  row={1} {2}", targetCell.Position.Column, targetCell.Position.Row, add);

                var pirates = field.GetPirates(targetCell);
                if (pirates.Any())
                {
                    label2.Text = string.Format("Pirates {0} {1}", pirates.Count, pirates[0].TeamType);
                }
                else {
                    label2.Text = "No Pirates";
                }

                return;
            }

            
            if (pirate.IsNotNull()) {
                var changedCells = field.MovePirateTo(pirate, targetCell);

                if (changedCells.NotEmpty()) {
                    RedrawCells(changedCells);
                }
                else {
                    field.SelectPirate(targetCell);
                }

                if (field.CurrentPlayer.CurrentTeam.NoMoreActivePirates()) {
                    NextPlayer();
                }
            }

            pirate = field.SelectPirate(targetCell);
            HighlightPirate((Label)sender, pirate);
        }

        private void HighlightPirate(Label sender, Pirate pirate1) {
            if (pirate1.IsNotNull()) {
                sender.Font = new Font(sender.Font.FontFamily, 6, FontStyle.Bold);
            }
            else {
                sender.Font = new Font(sender.Font.FontFamily, 6, FontStyle.Regular);

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
                    control.Font = new Font(control.Font.FontFamily, 6, FontStyle.Regular);
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