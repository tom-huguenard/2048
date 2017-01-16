namespace P2048
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TheGrid = new System.Windows.Forms.TableLayoutPanel();
            this.lnkNewGame = new System.Windows.Forms.LinkLabel();
            this.lnkExit = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // TheGrid
            // 
            this.TheGrid.BackColor = System.Drawing.Color.PeachPuff;
            this.TheGrid.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.TheGrid.ColumnCount = 4;
            this.TheGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TheGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TheGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TheGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TheGrid.Location = new System.Drawing.Point(12, 12);
            this.TheGrid.Name = "TheGrid";
            this.TheGrid.RowCount = 4;
            this.TheGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TheGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TheGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TheGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TheGrid.Size = new System.Drawing.Size(341, 253);
            this.TheGrid.TabIndex = 2;
            // 
            // lnkNewGame
            // 
            this.lnkNewGame.AutoSize = true;
            this.lnkNewGame.Location = new System.Drawing.Point(89, 277);
            this.lnkNewGame.Name = "lnkNewGame";
            this.lnkNewGame.Size = new System.Drawing.Size(60, 13);
            this.lnkNewGame.TabIndex = 5;
            this.lnkNewGame.TabStop = true;
            this.lnkNewGame.Text = "New Game";
            this.lnkNewGame.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkNewGame_LinkClicked);
            // 
            // lnkExit
            // 
            this.lnkExit.AutoSize = true;
            this.lnkExit.Location = new System.Drawing.Point(192, 277);
            this.lnkExit.Name = "lnkExit";
            this.lnkExit.Size = new System.Drawing.Size(24, 13);
            this.lnkExit.TabIndex = 6;
            this.lnkExit.TabStop = true;
            this.lnkExit.Text = "Exit";
            this.lnkExit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkExit_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.ClientSize = new System.Drawing.Size(365, 303);
            this.ControlBox = false;
            this.Controls.Add(this.lnkExit);
            this.Controls.Add(this.lnkNewGame);
            this.Controls.Add(this.TheGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "2048";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TheGrid;
        private System.Windows.Forms.LinkLabel lnkNewGame;
        private System.Windows.Forms.LinkLabel lnkExit;
    }
}

