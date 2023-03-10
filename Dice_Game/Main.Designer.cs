namespace Dice_Game
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            menuStrip = new MenuStrip();
            graToolStripMenuItem = new ToolStripMenuItem();
            nowaGraToolStripMenuItem = new ToolStripMenuItem();
            dodajGraczaToolStripMenuItem = new ToolStripMenuItem();
            ToolStripMenuItemAddPlayer1 = new ToolStripMenuItem();
            ToolStripMenuItemAddPlayer2 = new ToolStripMenuItem();
            ToolStripMenuItemAddPlayer3 = new ToolStripMenuItem();
            ToolStripMenuItemAddPlayer4 = new ToolStripMenuItem();
            opcjeToolStripMenuItem = new ToolStripMenuItem();
            skalaDpiToolStripMenuItem = new ToolStripMenuItem();
            dpiStripMenuItem100 = new ToolStripMenuItem();
            dpiStripMenuItem150 = new ToolStripMenuItem();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(24, 24);
            menuStrip.Items.AddRange(new ToolStripItem[] { graToolStripMenuItem, opcjeToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(776, 33);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip1";
            // 
            // graToolStripMenuItem
            // 
            graToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { nowaGraToolStripMenuItem, dodajGraczaToolStripMenuItem });
            graToolStripMenuItem.Name = "graToolStripMenuItem";
            graToolStripMenuItem.Size = new Size(55, 29);
            graToolStripMenuItem.Text = "Gra";
            // 
            // nowaGraToolStripMenuItem
            // 
            nowaGraToolStripMenuItem.Name = "nowaGraToolStripMenuItem";
            nowaGraToolStripMenuItem.ShortcutKeys = Keys.F2;
            nowaGraToolStripMenuItem.Size = new Size(301, 34);
            nowaGraToolStripMenuItem.Text = "Zacznij/Zakończ grę";
            // 
            // dodajGraczaToolStripMenuItem
            // 
            dodajGraczaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItemAddPlayer1, ToolStripMenuItemAddPlayer2, ToolStripMenuItemAddPlayer3, ToolStripMenuItemAddPlayer4 });
            dodajGraczaToolStripMenuItem.Name = "dodajGraczaToolStripMenuItem";
            dodajGraczaToolStripMenuItem.Size = new Size(301, 34);
            dodajGraczaToolStripMenuItem.Text = "Dodaj gracza...";
            // 
            // ToolStripMenuItemAddPlayer1
            // 
            ToolStripMenuItemAddPlayer1.Name = "ToolStripMenuItemAddPlayer1";
            ToolStripMenuItemAddPlayer1.ShortcutKeys = Keys.Control | Keys.D1;
            ToolStripMenuItemAddPlayer1.Size = new Size(270, 34);
            ToolStripMenuItemAddPlayer1.Text = "1.";
            // 
            // ToolStripMenuItemAddPlayer2
            // 
            ToolStripMenuItemAddPlayer2.Name = "ToolStripMenuItemAddPlayer2";
            ToolStripMenuItemAddPlayer2.ShortcutKeys = Keys.Control | Keys.D2;
            ToolStripMenuItemAddPlayer2.Size = new Size(270, 34);
            ToolStripMenuItemAddPlayer2.Text = "2.";
            // 
            // ToolStripMenuItemAddPlayer3
            // 
            ToolStripMenuItemAddPlayer3.Name = "ToolStripMenuItemAddPlayer3";
            ToolStripMenuItemAddPlayer3.ShortcutKeys = Keys.Control | Keys.D3;
            ToolStripMenuItemAddPlayer3.Size = new Size(270, 34);
            ToolStripMenuItemAddPlayer3.Text = "3.";
            // 
            // ToolStripMenuItemAddPlayer4
            // 
            ToolStripMenuItemAddPlayer4.Name = "ToolStripMenuItemAddPlayer4";
            ToolStripMenuItemAddPlayer4.ShortcutKeys = Keys.Control | Keys.D4;
            ToolStripMenuItemAddPlayer4.Size = new Size(270, 34);
            ToolStripMenuItemAddPlayer4.Text = "4.";
            // 
            // opcjeToolStripMenuItem
            // 
            opcjeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { skalaDpiToolStripMenuItem });
            opcjeToolStripMenuItem.Name = "opcjeToolStripMenuItem";
            opcjeToolStripMenuItem.Size = new Size(74, 29);
            opcjeToolStripMenuItem.Text = "Opcje";
            // 
            // skalaDpiToolStripMenuItem
            // 
            skalaDpiToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { dpiStripMenuItem100, dpiStripMenuItem150 });
            skalaDpiToolStripMenuItem.Name = "skalaDpiToolStripMenuItem";
            skalaDpiToolStripMenuItem.Size = new Size(188, 34);
            skalaDpiToolStripMenuItem.Text = "Skala Dpi";
            // 
            // dpiStripMenuItem100
            // 
            dpiStripMenuItem100.Name = "dpiStripMenuItem100";
            dpiStripMenuItem100.Size = new Size(159, 34);
            dpiStripMenuItem100.Text = "100%";
            dpiStripMenuItem100.Click += dpiStripMenuItem100_Click;
            // 
            // dpiStripMenuItem150
            // 
            dpiStripMenuItem150.Checked = true;
            dpiStripMenuItem150.CheckState = CheckState.Checked;
            dpiStripMenuItem150.Name = "dpiStripMenuItem150";
            dpiStripMenuItem150.Size = new Size(159, 34);
            dpiStripMenuItem150.Text = "150%";
            dpiStripMenuItem150.Click += dpi150menuClick;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(144F, 144F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(776, 620);
            Controls.Add(menuStrip);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip;
            Margin = new Padding(4);
            Name = "Main";
            Text = "Gra w Kości";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        public MenuStrip menuStrip;
        private ToolStripMenuItem opcjeToolStripMenuItem;
        private ToolStripMenuItem skalaDpiToolStripMenuItem;
        private ToolStripMenuItem dpiStripMenuItem100;
        private ToolStripMenuItem dpiStripMenuItem150;
        protected ToolStripMenuItem graToolStripMenuItem;
        protected ToolStripMenuItem dodajGraczaToolStripMenuItem;
        protected ToolStripMenuItem toolStripMenuItemAddPlayer1;
        public ToolStripMenuItem nowaGraToolStripMenuItem;
        public ToolStripMenuItem ToolStripMenuItemAddPlayer1;
        public ToolStripMenuItem ToolStripMenuItemAddPlayer2;
        public ToolStripMenuItem ToolStripMenuItemAddPlayer3;
        public ToolStripMenuItem ToolStripMenuItemAddPlayer4;
    }
}