namespace Dice_Game
{
    public partial class Main : Form
    {
        private Game game;
        public Main()
        {
            InitializeComponent();

            game = new Game(this);
            game.MouseEventsInitalize();
            this.MaximumSize = new Size(this.Width, this.Height);
            this.MinimumSize = new Size(this.Width, this.Height);
        }


    }
}