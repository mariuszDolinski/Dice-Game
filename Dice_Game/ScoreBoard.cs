namespace Dice_Game
{
    internal class ScoreBoard
    {
        public Label[,] Board { get; set; }

        public static int BoardWidth = 5; //number of columns
        public static int BoardHeight = 19;//number of rows
        public ScoreBoard()//initialize Labels
        {
            Board = new Label[BoardWidth, BoardHeight];
            for (int i = 0; i < BoardWidth; i++)
            {

                for (int j = 0; j < BoardHeight; j++)
                {
                    Board[i, j] = new Label();
                    Board[i, j].BorderStyle = BorderStyle.None;
                    initColors(i, j);
                    Board[i, j].Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);
                    if (i == 0)
                    {
                        Board[i, j].Location = new Point((int)Math.Round(Scales.Scale*(3 + i * 135)), (int)Math.Round(Scales.Scale * (3 + j * 20)));
                        Board[i, j].Size = 
                            new Size((int)Math.Round(Scales.Scale * 124), (int)Math.Round(Scales.Scale * 19));
                        Board[i, j].TextAlign = ContentAlignment.MiddleLeft;
                    }
                    else
                    {
                        Board[i, j].Location = new Point((int)Math.Round(Scales.Scale*(92 + i * 36)), (int)Math.Round(Scales.Scale *(3 + j * 20)));
                        Board[i, j].Size
                            = new Size((int)Math.Round(Scales.Scale * 35), (int)Math.Round(Scales.Scale * 19));
                        Board[i, j].TextAlign = ContentAlignment.MiddleCenter;
                    }
                }
            }
            initTextLabels();
        }

        private void initTextLabels()
        {
            Board[0, 1].Text = "Jedynki";
            Board[0, 2].Text = "Dwójki";
            Board[0, 3].Text = "Trójki";
            Board[0, 4].Text = "Czwórki";
            Board[0, 5].Text = "Piątki";
            Board[0, 6].Text = "Szóstki";
            Board[0, 7].Text = "Suma";
            Board[0, 8].Text = "Bonus";
            Board[0, 9].Text = "Dwie pary";
            Board[0, 10].Text = "3 takie same";
            Board[0, 11].Text = "4 takie same";
            Board[0, 12].Text = "Strit";
            Board[0, 13].Text = "Full";
            Board[0, 14].Text = "5 takich samych";
            Board[0, 15].Text = "Szansa";
            Board[0, 16].Text = "Suma";
            Board[0, 17].Text = "Bonus";
            Board[0, 18].Text = "Wynik";
            Board[1, 0].Text = "I";
            Board[2, 0].Text = "II";
            Board[3, 0].Text = "III";
            Board[4, 0].Text = "IV";
        }

        private void initColors(int row, int col)
        {
            switch (col)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 9:
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                    Board[row, col].BackColor = Color.Azure;
                    break;
                case 0:
                case 7:
                case 8:
                case 16:
                case 17:
                    Board[row, col].BackColor = Color.LightSteelBlue;
                    break;
                case 18:
                    Board[row, col].BackColor = Color.Gray;
                    break;
                default:
                    break;
            }
        }
    }
}
