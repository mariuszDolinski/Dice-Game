namespace Dice_Game
{
    public partial class Main : Form
    {
        private Game _game;
        private MenuUtils _menuUtils;

        public Main()
        {
            InitializeComponent();

            _game = new Game(this, 1.5F);
            _game.MouseEventsInitalize();
            _menuUtils = new MenuUtils(this, _game);
            MaximumSize = new Size(this.Width, this.Height);
            MinimumSize = new Size(this.Width, this.Height);
        }

        private void dpi150menuClick(object sender, EventArgs e)
        {
            dpiStripMenuItem100.Checked = false;
            dpiStripMenuItem150.Checked = true;
            _game.RenderComponents(this, 1.5F);
            Refresh();
        }

        private void dpiStripMenuItem100_Click(object sender, EventArgs e)
        {
            dpiStripMenuItem100.Checked = true;
            dpiStripMenuItem150.Checked = false;
            _game.RenderComponents(this, 1.0F);
            Refresh();
        }
    }
}