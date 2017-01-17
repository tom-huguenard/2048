using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace P2048
{

    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        public static extern bool LockWindowUpdate(IntPtr hWndLock);

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
            LockWindowUpdate(Handle);
            for (var i = 0; i < 4; i++)
                for (var j = 0; j < 4; j++)
                    SetGridValue(j, i, _gridData.ValueForRowAndColumn(i, j));
            LockWindowUpdate(IntPtr.Zero);
        }
        private void SetGridValue(int col, int row, int value)
        {
            var lbl = (Label)TheGrid.GetControlFromPosition(col, row);
            lbl.Text = value == 0 ? "" : value.ToString();
            lbl.ForeColor = GetColorForValue(value);
            lbl.BackColor = GetBackgroundColorForValue(value);
            lbl.Font = new Font(lbl.Font.FontFamily, GetSizeForValue(value));
        }

        private static float GetSizeForValue(int value)
        {
            if (value < 10) return 26;
            if (value < 100) return 22;
            if (value < 1000) return 18;
            return 14;
        }

        private static Color GetColorForValue(int value)
        {
            var d = new Dictionary<int, Color>
            {
                [0] = Color.Coral,
                [1] = Color.Aqua,
                [2] = Color.DarkGray,
                [4] = Color.DarkGray,
                [8] = Color.White,
                [16] = Color.White,
                [32] = Color.White,
                [64] = Color.White,
                [128] = Color.White,
                [256] = Color.White,
                [512] = Color.White,
                [1024] = Color.White,
                [2048] = Color.White
            };
            return d[value];
        }
        private static Color GetBackgroundColorForValue(int value)
        {
            var d = new Dictionary<int, Color>
            {
                [0] = Color.LightGray,
                [1] = Color.Aqua,
                [2] = Color.SlateGray,
                [4] = Color.DimGray,
                [8] = Color.Orange,
                [16] = Color.IndianRed,
                [32] = Color.OrangeRed,
                [64] = Color.DarkRed,
                [128] = Color.Khaki,
                [256] = Color.DarkKhaki,
                [512] = Color.YellowGreen,
                [1024] = Color.Yellow,
                [2048] = Color.DarkGoldenrod
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
                        Font = new Font(FontFamily.GenericSansSerif, 16, FontStyle.Bold),
                        Dock = DockStyle.Fill
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
