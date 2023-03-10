namespace Dice_Game
{
    public partial class Main : Form
    {
        private Game game;
        public Main()
        {
            InitializeComponent();

            game = new Game(this, 1.5F);
            game.MouseEventsInitalize();
            MaximumSize = new Size(this.Width, this.Height);
            MinimumSize = new Size(this.Width, this.Height);
        }

        private void dpi150menuClick(object sender, EventArgs e)
        {
            dpiStripMenuItem100.Checked = false;
            dpiStripMenuItem150.Checked = true;
            game.RenderComponents(this, 1.5F);
            Refresh();
        }

        private void dpiStripMenuItem100_Click(object sender, EventArgs e)
        {
            dpiStripMenuItem100.Checked = true;
            dpiStripMenuItem150.Checked = false;
            game.RenderComponents(this, 1.0F);
            Refresh();
        }
    }
}