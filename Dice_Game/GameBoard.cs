using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dice_Game
{
    internal class GameBoard
    {
        public GameBoard(Main main) 
        {
            initComponents(main);
        }

        //components
        protected ScoreBoard scoreBoard = new ScoreBoard();
        protected Panel scoresPanel= new Panel();//container for scoreBoard
        protected Panel diceRolled = new Panel();//container for rolling dice
        protected Panel diceChoosen = new Panel();//container for choosen dice
        protected Panel game = new Panel();//container for game info
        protected Panel[] playerPanel = new Panel[4];
        protected Label turnLabel = new Label();
        protected Label turnNumber = new Label();
        protected Label throwLabel = new Label();
        protected Label throwNumber = new Label();
        protected MyButton throwDiceButton = new MyButton();//button to throw dice
        protected MyButton newGameButton = new MyButton();//button to start/end game
        protected Label[] diceRolledLabel = new Label[5];
        protected Label[] diceChoosenLabel = new Label[5];
        protected Label[] playerNumber = new Label[4];
        protected TextBox[] playerTextBox = new TextBox[4];
        protected MyButton[] addPlayerButton = new MyButton[4];
        protected Label[] playerName = new Label[4];
        protected Label help = new Label(); //game instruction
        protected Label about = new Label();
        protected Button showRules = new Button();


        private void initComponents(Main main)
        {
            //set properties for main panels
            scoresPanel.Location = new Point(2, 2);
            scoresPanel.Size = new Size(274, 385);
            scoresPanel.BackColor = Color.Black;
            diceRolled.Location = new Point(281, 2);
            diceRolled.Size = new Size(239, 51);
            diceRolled.BackColor = Color.Black;
            game.Location = new Point(281, 56);
            game.Size = new Size(diceRolled.Width, 27);
            game.BackColor = Color.Black;
            diceChoosen.Location = new Point(281, game.Location.Y + game.Size.Height + 3);
            diceChoosen.Size = new Size(239, 51);
            diceChoosen.BackColor = Color.Black;

            turnLabel.Location = new Point(2, 2);
            turnLabel.Size = new Size(5 * diceRolled.Width / 20, 23);
            turnLabel.TextAlign = ContentAlignment.MiddleCenter;
            turnLabel.BackColor = Color.LemonChiffon;
            turnLabel.Text = "Tura";
            turnNumber.Location = new Point(turnLabel.Width + 3, 2);
            turnNumber.Size = new Size(diceRolled.Width / 10 + 3, 23);
            turnNumber.TextAlign = ContentAlignment.MiddleCenter;
            turnNumber.BackColor = Color.LemonChiffon;
            turnNumber.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);
            turnNumber.Text = "0";
            throwLabel.Location = new Point(turnLabel.Width + turnNumber.Width + 5, 2);
            throwLabel.Size = new Size(5 * diceRolled.Width / 20, 23);
            throwLabel.TextAlign = ContentAlignment.MiddleCenter;
            throwLabel.BackColor = Color.LemonChiffon;
            throwLabel.Text = "Rzuty";
            throwNumber.Location = new Point(turnLabel.Width + turnNumber.Width + throwLabel.Width + 6, 2);
            throwNumber.Size = new Size(diceRolled.Width / 10 + 3, 23);
            throwNumber.TextAlign = ContentAlignment.MiddleCenter;
            throwNumber.BackColor = Color.LemonChiffon;
            throwNumber.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);
            throwNumber.Text = "0";

            //default buttons parameters
            int throwButtonWidth = 5 * diceRolled.Width / 20 + 2;
            int throwButtonHeight = 25;
            int throwDiceButtonLocationX = turnLabel.Width + turnNumber.Width + throwLabel.Width + throwNumber.Width + 7;
            int newGameButtonX = 257 + (20 * diceChoosen.Size.Width / 100);
            int newGameButtonWidth = 80 * diceChoosen.Size.Width / 100;

            throwDiceButton.Location = new Point(throwDiceButtonLocationX, 1);
            throwDiceButton.Size = new Size(throwButtonWidth, throwButtonHeight);
            throwDiceButton.Text = "Rzuć";
            throwDiceButton.BackColor = SystemColors.Control;
            //adding turn panel and throw button to game panel
            game.Controls.Add(turnLabel);
            game.Controls.Add(turnNumber);
            game.Controls.Add(throwLabel);
            game.Controls.Add(throwNumber);
            game.Controls.Add(throwDiceButton);

            newGameButton.Location = new Point(newGameButtonX, diceChoosen.Location.Y + diceChoosen.Size.Height + 6);
            newGameButton.Size = new Size(newGameButtonWidth, throwButtonHeight);
            newGameButton.Text = "Rozpocznij grę";

            for (int i = 0; i < ScoreBoard.BoardWidth; i++)
            {
                diceRolledLabel[i] = new Label();
                diceChoosenLabel[i] = new Label();
                diceRolledLabel[i].Location = new Point(2 + 47 * i, 2);
                diceRolledLabel[i].Size = new Size(47, 47);
                diceRolledLabel[i].Tag = i;
                diceChoosenLabel[i].Tag = i;
                diceChoosenLabel[i].Location = new Point(2 + 47 * i, 2);
                diceChoosenLabel[i].Size = new Size(47, 47);
                diceRolledLabel[i].Image = Properties.Resources.pusty;
                diceChoosenLabel[i].Image = Properties.Resources.pusty;
                diceRolled.Controls.Add(diceRolledLabel[i]);
                diceChoosen.Controls.Add(diceChoosenLabel[i]);
                if (i < 4)
                {
                    playerPanel[i] = new Panel();
                    playerNumber[i] = new Label();
                    playerTextBox[i] = new TextBox();
                    addPlayerButton[i] = new MyButton();
                    playerName[i] = new Label();

                    playerPanel[i].Location = new Point(281, newGameButton.Location.Y + newGameButton.Height + 6 + (33 * i));
                    playerPanel[i].Size = new Size(diceChoosen.Width, 27);
                    playerPanel[i].BackColor = Color.Black;

                    playerNumber[i].Location = new Point(2, 2);
                    playerNumber[i].Size = new Size((2 * playerPanel[i].Width) / 10, playerPanel[i].Height - 4);
                    playerNumber[i].BackColor = Color.LightSteelBlue;
                    playerNumber[i].TextAlign = ContentAlignment.MiddleCenter;
                    playerNumber[i].Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);
                    switch (i)
                    {
                        case 0: playerNumber[i].Text = "I"; break;
                        case 1: playerNumber[i].Text = "II"; break;
                        case 2: playerNumber[i].Text = "III"; break;
                        case 3: playerNumber[i].Text = "IV"; break;
                    }

                    playerTextBox[i].Location = new Point(playerNumber[i].Location.X + playerNumber[i].Width + 2, 2);
                    playerTextBox[i].Size = new Size((5 * playerPanel[i].Width) / 10 + 6, playerPanel[i].Height - 4);
                    playerTextBox[i].Visible = false;

                    playerName[i].Location = new Point(playerTextBox[i].Location.X, 2);
                    playerName[i].Size = new Size(playerTextBox[i].Width, playerTextBox[i].Height);
                    playerName[i].BackColor = Color.LemonChiffon;
                    playerName[i].Tag = i;
                    playerName[i].TextAlign = ContentAlignment.MiddleCenter;
                    playerName[i].Font = new Font("Verdana", 10, FontStyle.Bold);

                    addPlayerButton[i].Location = new Point(throwDiceButtonLocationX, 1);
                    addPlayerButton[i].Size = new Size(throwButtonWidth, playerPanel[i].Height - 2);
                    addPlayerButton[i].Text = " Dodaj";
                    addPlayerButton[i].TextAlign = ContentAlignment.MiddleCenter;
                    addPlayerButton[i].BackColor = SystemColors.Control;
                    addPlayerButton[i].Tag = i;

                    main.Controls.Add(playerPanel[i]);
                    playerPanel[i].Controls.Add(playerNumber[i]);
                    playerPanel[i].Controls.Add(playerTextBox[i]);
                    playerPanel[i].Controls.Add(addPlayerButton[i]);
                    playerPanel[i].Controls.Add(playerName[i]);
                }
            }

            for (int i = 0; i < ScoreBoard.BoardWidth; i++)
            {
                for (int j = 0; j < ScoreBoard.BoardHeight; j++)
                {
                    scoreBoard.Board[i, j].Tag = new Cell() { X = i, Y = j };
                    if(i != 0 && j != 0) scoreBoard.Board[i, j].Text = "";
                    if (j == 7 || j == 8 || j == 16 || j == 17 || j == 18)
                    {
                        if (i != 0)
                        {
                            scoreBoard.Board[i, j].Text = "0";
                        }
                    }
                    scoresPanel.Controls.Add(scoreBoard.Board[i, j]);
                    if (i > 0)
                    {
                        //tab.Tablica[i, j].MouseEnter += new EventHandler(OknoGlowne_MouseEnter);
                        //tab.Tablica[i, j].MouseLeave += new EventHandler(OknoGlowne_MouseLeave);
                        //tab.Tablica[i,j].MouseClick +=new MouseEventHandler(tablica_MouseClick);
                    }
                }
            }

            main.Controls.Add(scoresPanel);
            main.Controls.Add(diceRolled);
            main.Controls.Add(game);
            main.Controls.Add(diceChoosen);
            main.Controls.Add(newGameButton);
            main.Controls.Add(about);
            main.Controls.Add(showRules);
        }

        /// <summary>
        /// Set labels color for active player
        /// </summary>
        /// <param name="player">number of active player</param>
        protected void setPlayersColors(int player)
        {
            if (player == 0) return;
            for (int i = 1; i < 5; i++)
            {
                if (i == player)
                {
                    scoreBoard.Board[player, 0].BackColor = Color.Orange;
                    playerName[player - 1].BackColor = Color.Orange;
                }
                else
                {
                    scoreBoard.Board[i, 0].BackColor = Color.LightSteelBlue;
                    playerName[i - 1].BackColor = Color.LemonChiffon;
                }
            }
        }

        /// <summary>
        /// Set labels for all players to nonactive
        /// </summary>
        protected void resetPlayersColors()
        {
            for (int i = 1; i < 5; i++)
            {
                scoreBoard.Board[i, 0].BackColor = Color.LightSteelBlue;
                playerName[i - 1].BackColor = Color.LemonChiffon;
            }
        }


    }
}
