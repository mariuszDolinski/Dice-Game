namespace Dice_Game
{
    public partial class Main : Form
    {
        private readonly int width100dpi = 533;//798;//665-125 533-100
        private readonly int height100dpi = 446;//671;//558-125 446-100

        private Game _game;
        private MenuUtils _menuUtils;

        public Main()
        {
            InitializeComponent();

            int dpi = GetDpi();
            _game = new Game(this, 1.5F, dpi);
            _game.MouseEventsInitalize(this);
            _menuUtils = new MenuUtils(this, _game);
            SetSize(dpi);
            SetDpiMenuButtons();
        }

        private void SetSize(int dpi)
        {
            double currentWidth, currentHeight;
            switch (dpi) 
            {
                case 100:
                    currentWidth = (double)144 / 97;
                    currentHeight = (double)144 / 100;
                    MinimumSize = new Size((int)(currentWidth * width100dpi), (int)(currentHeight * height100dpi) + 2);
                    MaximumSize = new Size((int)(currentWidth * width100dpi), (int)(currentHeight * height100dpi) + 2);
                    break;
                case 125:
                    currentWidth = 1.49;// (double)144 / 120;
                    currentHeight = 1.47; // (double)144 / 123;
                    MinimumSize = new Size((int)(currentWidth * width100dpi), (int)(currentHeight * height100dpi) + 1);
                    MaximumSize = new Size((int)(currentWidth * width100dpi), (int)(currentHeight * height100dpi) + 1);
                    break;
                default://150
                    currentWidth = 1.5;// (double)144 / 120;
                    currentHeight = 1.5;// (double)144 / 123;
                    MinimumSize = new Size((int)(currentWidth * width100dpi) - 1, (int)(currentHeight * height100dpi) + 3);
                    MaximumSize = new Size((int)(currentWidth * width100dpi) - 1, (int)(currentHeight * height100dpi) + 3);
                    break;
            }
        }

        private int GetDpi()
        {
            if (DeviceDpi < 100) return 100;
            else if (DeviceDpi < 125) return 125;
            else return 150;
        }

        private void SetDpiMenuButtons()
        {
            int dpi = GetDpi();
            dpiStripMenuItem100.Checked = false;
            dpiStripMenuItem150.Checked = false;
            dpiStripMenuItem125.Checked = false;
            switch (dpi) 
            {
                case 100:
                    dpiStripMenuItem100.Checked = true; break;
                case 125:
                    dpiStripMenuItem125.Checked = true; break;
                default :
                    dpiStripMenuItem150.Checked = true; break;
            }
        }
        private void dpi150menuClick(object sender, EventArgs e)
        {
            dpiStripMenuItem100.Checked = false;
            dpiStripMenuItem150.Checked = true;
            dpiStripMenuItem125.Checked = false;
            SetSize(150);
            Refresh();
        }

        private void dpiStripMenuItem100_Click(object sender, EventArgs e)
        {
            dpiStripMenuItem100.Checked = true;
            dpiStripMenuItem150.Checked = false;
            dpiStripMenuItem125.Checked = false;
            SetSize(100);
            Refresh();
        }

        private void dpiStripMenuItem125_Click(object sender, EventArgs e)
        {
           SetSize(125);
            dpiStripMenuItem125.Checked = true;
            dpiStripMenuItem150.Checked = false;
            dpiStripMenuItem100.Checked = false;
            Refresh();
        }
    }
}