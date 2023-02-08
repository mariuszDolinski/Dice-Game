namespace Dice_Game
{
    public partial class BestScoresWindow : Form
    {
        public BestScoresWindow()
        {
            InitializeComponent();
            init();

            cellWidth[0] = this.Width/10 - 18; 
            cellWidth[1] = 9 * this.Width/20 - 2; 
            cellWidth[2] = 3 * this.Width/20 - 2; 
            cellWidth[3] = 3 * this.Width/10 - 8;
            bestScoresTable = new Label[tableWidth, tableHeight];
            int k = 2; //second vertical border is 
            for (int i = 0; i < tableWidth; i++)
            {
                for (int j = 0; j < tableHeight; j++)
                {
                    if (j == 1) k = 3;
                    bestScoresTable[i, j] = new Label();
                    bestScoresTable[i, j].Size = new Size(cellWidth[i], cellHeight);
                    bestScoresTable[i, j].Location = 
                        new Point(currentCellPositionX(i) + 2 + 2*i, j * (cellHeight + 1) + k);
                    bestScoresTable[i, j].BackColor = Color.White;
                    if (j == 0)
                        bestScoresTable[i, j].BackColor = Color.Gray;
                    else
                        bestScoresTable[i, j].BackColor = Color.Azure;
                    if(j == 0 || i == 2)
                    {
                        bestScoresTable[i, j].Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);
                        bestScoresTable[i, j].TextAlign = ContentAlignment.MiddleCenter;
                    }       
                    else
                    {
                        bestScoresTable[i, j].Font = new Font(FontFamily.GenericSansSerif, 10);
                        bestScoresTable[i, j].TextAlign = ContentAlignment.MiddleLeft;
                    }
                        
                    
                    bestScoresPanel.Controls.Add(bestScoresTable[i, j]);
                }
                k = 2;
            }
            tableHeaders();
           
        }


        private Panel bestScoresPanel = new Panel();
        private Label[,] bestScoresTable;
        private const int tableWidth = 4;
        private const int tableHeight = 11;
        int cellHeight = 19;
        int[] cellWidth = new int[tableWidth];

        private void init()
        {
            this.Height = 267;
            this.Width = 500;
            this.MaximumSize = new Size(this.Width, this.Height);
            this.MinimumSize = new Size(this.Width, this.Height);
            this.Text = "Najlepsze wyniki";

            bestScoresPanel.Location = new Point(2, 2);
            bestScoresPanel.Size = new Size(this.Width - 20, this.Height - 43);
            bestScoresPanel.BackColor = Color.Black;
            this.Controls.Add(bestScoresPanel);
        }

        //initialize table content
        private void tableHeaders()
        {
            bestScoresTable[0, 0].Text = "Lp.";
            bestScoresTable[1, 0].Text = "Gracz";
            bestScoresTable[2, 0].Text = "Wynik";
            bestScoresTable[3, 0].Text = "Data";
            for(int i = 1; i< tableHeight; i++) 
            {
                bestScoresTable[0, i].Text = i.ToString()+".";
            }
        }

        //calculating x position of current cell in table
        private int currentCellPositionX(int i)
        {
            int result = 0;
            for(int k = 0; k < i; k++)
            {
                result += cellWidth[k];
            }
            return result;
        }

        //insert to table values from best scores list
        public void DisplayBestResults(List<Player> list)
        {
            for(int i =0; i< list.Count; i++)
            {
                bestScoresTable[1, i + 1].Text = list.ElementAt(i).Name;
                bestScoresTable[2, i + 1].Text = list.ElementAt(i).Score.ToString();
                bestScoresTable[3, i + 1].Text = list.ElementAt(i).Date.ToString("dd.MM.yyyy  HH:mm");
            }
        }
    }
}
