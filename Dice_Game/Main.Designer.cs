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
            menuStrip.Padding = new Padding(4, 1, 0, 1);
            menuStrip.Size = new Size(517, 24);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip1";
            // 
            // graToolStripMenuItem
            // 
            graToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { nowaGraToolStripMenuItem });
            graToolStripMenuItem.Name = "graToolStripMenuItem";
            graToolStripMenuItem.Size = new Size(37, 22);
            graToolStripMenuItem.Text = "Gra";
            // 
            // nowaGraToolStripMenuItem
            // 
            nowaGraToolStripMenuItem.Name = "nowaGraToolStripMenuItem";
            nowaGraToolStripMenuItem.ShortcutKeys = Keys.F2;
            nowaGraToolStripMenuItem.Size = new Size(144, 22);
            nowaGraToolStripMenuItem.Text = "Nowa gra";
            // 
            // opcjeToolStripMenuItem
            // 
            opcjeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { skalaDpiToolStripMenuItem });
            opcjeToolStripMenuItem.Name = "opcjeToolStripMenuItem";
            opcjeToolStripMenuItem.Size = new Size(50, 22);
            opcjeToolStripMenuItem.Text = "Opcje";
            // 
            // skalaDpiToolStripMenuItem
            // 
            skalaDpiToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { dpiStripMenuItem100, dpiStripMenuItem150 });
            skalaDpiToolStripMenuItem.Name = "skalaDpiToolStripMenuItem";
            skalaDpiToolStripMenuItem.Size = new Size(122, 22);
            skalaDpiToolStripMenuItem.Text = "Skala Dpi";
            // 
            // dpiStripMenuItem100
            // 
            dpiStripMenuItem100.Name = "dpiStripMenuItem100";
            dpiStripMenuItem100.Size = new Size(102, 22);
            dpiStripMenuItem100.Text = "100%";
            dpiStripMenuItem100.Click += dpiStripMenuItem100_Click;
            // 
            // dpiStripMenuItem150
            // 
            dpiStripMenuItem150.Checked = true;
            dpiStripMenuItem150.CheckState = CheckState.Checked;
            dpiStripMenuItem150.Name = "dpiStripMenuItem150";
            dpiStripMenuItem150.Size = new Size(102, 22);
            dpiStripMenuItem150.Text = "150%";
            dpiStripMenuItem150.Click += dpi150menuClick;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(517, 413);
            Controls.Add(menuStrip);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip;
            Name = "Main";
            Text = "Gra w Kości";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ToolStripMenuItem graToolStripMenuItem;
        public MenuStrip menuStrip;
        private ToolStripMenuItem nowaGraToolStripMenuItem;
        private ToolStripMenuItem opcjeToolStripMenuItem;
        private ToolStripMenuItem skalaDpiToolStripMenuItem;
        private ToolStripMenuItem dpiStripMenuItem100;
        private ToolStripMenuItem dpiStripMenuItem150;
    }
}