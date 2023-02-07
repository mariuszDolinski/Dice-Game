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
        }


    }
}