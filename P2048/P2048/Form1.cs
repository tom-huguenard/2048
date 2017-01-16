using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace P2048
{
    public partial class Form1 : Form
    {
        private GridData _gridData; 
        public Form1()
        {
            InitializeComponent();
        }
        private void LoadGrid()
        {
            _gridData = new GridData();
            PaintValues();
        }
        private void PaintValues()
        {
            for (var i = 0; i < 4; i++)
                for (var j = 0; j < 4; j++)
                    SetGridValue(j, i, _gridData.ValueForRowAndColumn(i, j));
        }
        private void SetGridValue(int col, int row, int value)
        {
            var lbl = (Label)TheGrid.GetControlFromPosition(col, row);
            lbl.Text = value == 0 ? "" : value.ToString();
            lbl.ForeColor = GetColorForValue(value);
        }

        private Color GetColorForValue(int value)
        {
            var d = new Dictionary<int, Color>
            {
                [0] = Color.Coral,
                [1] = Color.Aqua,
                [2] = Color.Red,
                [4] = Color.ForestGreen,
                [8] = Color.Cyan,
                [16] = Color.DarkSalmon,
                [32] = Color.DeepSkyBlue,
                [64] = Color.HotPink,
                [128] = Color.LightBlue,
                [256] = Color.MediumSlateBlue,
                [512] = Color.Beige,
                [1024] = Color.Olive,
                [2048] = Color.Teal
            };
            return d[value];
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateControls();
            LoadGrid();
        }

        private void CreateControls()
        {
            for (var i = 0; i < 4; i++)
                for (var j = 0; j < 4; j++)
                    TheGrid.Controls.Add(new Label
                    {
                        Text = "",
                        TextAlign = ContentAlignment.MiddleCenter,
                        Font = new Font(FontFamily.GenericSansSerif, 16, FontStyle.Bold)

                    }, j, i);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                    _gridData.MoveRowDataForDirection("d");
                    break;
                case Keys.Up:
                    _gridData.MoveRowDataForDirection("u");
                    break;
                case Keys.Right:
                    _gridData.MoveRowDataForDirection("r");
                    break;
                case Keys.Left:
                    _gridData.MoveRowDataForDirection("l");
                    break;
            }
            _gridData.AddNewValue();
            PaintValues();
        }

        private void lnkExit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Close();
        }

        private void lnkNewGame_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadGrid();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Console.Write(0);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Down:
                    _gridData.MoveRowDataForDirection("u");
                    break;
                case Keys.Up:
                    _gridData.MoveRowDataForDirection("d");
                    break;
                case Keys.Right:
                    _gridData.MoveRowDataForDirection("l");
                    break;
                case Keys.Left:
                    _gridData.MoveRowDataForDirection("r");
                    break;
            }
            _gridData.AddNewValue();
            PaintValues();
            return true;
        }
    }
}
