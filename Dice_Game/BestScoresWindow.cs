namespace Dice_Game
{
    public partial class BestScoresWindow : Form
    {
        public BestScoresWindow()
        {
            InitializeComponent();
            init();

            cellWidth[0] = Scales.FirstColBS;
            cellWidth[1] = Scales.SecondColBS;
            cellWidth[2] = Scales.ThirdColBS;
            cellWidth[3] = Scales.FourthColBS;
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
                        new Point(currentCellPositionX(i) + (int)Math.Round(Scales.Scale * (4 + 2*i)), j * (cellHeight + 1) + k);
                    bestScoresTable[i, j].BackColor = Color.White;
                    if (j == 0)
                        bestScoresTable[i, j].BackColor = Color.Gray;
                    else
                        bestScoresTable[i, j].BackColor = Color.LightSteelBlue;
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
        int cellHeight = Scales.CellHeightBS;
        int[] cellWidth = new int[tableWidth];

        private void init()
        {
            Height = Scales.WindowHeightBS;
            Width = Scales.WindowWidthBS;
            MaximumSize = new Size(Width, Height);
            MinimumSize = new Size(Width, Height);
            Text = "Najlepsze wyniki";

            bestScoresPanel.Location = new Point(2, 2);
            bestScoresPanel.Size = new Size(Scales.PanelWidthBS, Scales.PanelHeightBS);
            bestScoresPanel.BackColor = SystemColors.Window;
            Controls.Add(bestScoresPanel);
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
