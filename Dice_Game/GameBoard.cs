﻿namespace Dice_Game
{
    internal class GameBoard
    {
        public GameBoard(Main main)
        {
            initComponents(main);
        }

        //components
        protected ScoreBoard scoreBoard = new ScoreBoard();
        protected Panel scoresPanel = new Panel();//container for scoreBoard
        protected Panel diceRolled = new Panel();//container for rolling dice
        protected Panel diceChoosen = new Panel();//container for choosen dice
        protected Panel game = new Panel();//container for game info
        protected Panel[] playerPanel = new Panel[4];
        protected Panel buttonsPanel = new Panel();
        protected Label turnLabel = new Label();
        protected Label turnNumber = new Label();
        protected Label throwLabel = new Label();
        protected Label throwNumber = new Label();
        protected MyButton throwDiceButton = new MyButton();//button to throw dice
        protected Label[] diceRolledLabel = new Label[5];
        protected Label[] diceChoosenLabel = new Label[5];
        protected Label[] playerNumber = new Label[4];
        protected TextBox[] playerTextBox = new TextBox[4];
        protected MyButton[] addPlayerButton = new MyButton[4];
        protected Label[] playerName = new Label[4];
        protected MyButton newGameButton = new MyButton();//button to start/end game
        protected MyButton bestScoresButton = new MyButton();

        private void initComponents(Main main)
        {
            //set properties for main panels
            scoresPanel.Location = new Point(2, 2);
            scoresPanel.Size = new Size(Scales.ScoresPanelWidth, Scales.ScoresPanelHeight);
            scoresPanel.BackColor = Color.Black;
            diceRolled.Location = new Point(Scales.RightPanelsLocationX, 2);
            diceRolled.Size = new Size(Scales.RightPanelsWidth, Scales.DicedPanelHeight);
            diceRolled.BackColor = Color.Black;
            game.Location = new Point(Scales.RightPanelsLocationX, Scales.GameLocationY);
            game.Size = new Size(Scales.RightPanelsWidth, Scales.GamePanelHeight);
            game.BackColor = Color.Black;
            diceChoosen.Location = new Point(Scales.RightPanelsLocationX, Scales.DicedChoosenPanelLocationY);
            diceChoosen.Size = new Size(Scales.RightPanelsWidth, Scales.DicedPanelHeight);
            diceChoosen.BackColor = Color.Black;

            turnLabel.Location = new Point(2, 2);
            turnLabel.Size = new Size(Scales.GameLabelWidth, Scales.GameInnerHeight);
            turnLabel.Font = new Font(FontFamily.GenericSansSerif, 10);
            turnLabel.TextAlign = ContentAlignment.MiddleCenter;
            turnLabel.BackColor = Color.LemonChiffon;
            turnLabel.Text = "Tura";
            turnNumber.Location = new Point(Scales.TurnNumberLocationX, 2);
            turnNumber.Size = new Size(Scales.GameNumberWidth, Scales.GameInnerHeight);
            turnNumber.TextAlign = ContentAlignment.MiddleCenter;
            turnNumber.BackColor = Color.LemonChiffon;
            turnNumber.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);
            turnNumber.Text = "0";
            throwLabel.Location = new Point(Scales.ThrowLabelLocationX, 2);
            throwLabel.Size = new Size(Scales.GameLabelWidth, Scales.GameInnerHeight);
            throwLabel.Font = new Font(FontFamily.GenericSansSerif, 10);
            throwLabel.TextAlign = ContentAlignment.MiddleCenter;
            throwLabel.BackColor = Color.LemonChiffon;
            throwLabel.Text = "Rzuty";
            throwNumber.Location = new Point(Scales.ThrowNumberLocationX, 2);
            throwNumber.Size = new Size(Scales.GameNumberWidth, Scales.GameInnerHeight);
            throwNumber.TextAlign = ContentAlignment.MiddleCenter;
            throwNumber.BackColor = Color.LemonChiffon;
            throwNumber.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);
            throwNumber.Text = "0";

            throwDiceButton.Location = new Point(Scales.ThrowButtonLocationX, 1);
            throwDiceButton.Size = new Size(Scales.ThrowButtonWidth, Scales.ThrowButtonHeight);
            throwDiceButton.Text = "Rzuć";
            throwDiceButton.BackColor = SystemColors.Control;
            //adding turn panel and throw button to game panel
            game.Controls.Add(turnLabel);
            game.Controls.Add(turnNumber);
            game.Controls.Add(throwLabel);
            game.Controls.Add(throwNumber);
            game.Controls.Add(throwDiceButton);

            for (int i = 0; i < ScoreBoard.BoardWidth; i++)
            {
                diceRolledLabel[i] = new Label();
                diceChoosenLabel[i] = new Label();
                diceRolledLabel[i].Location = new Point(Scales.DicedImageLocationX[i], 2);
                diceRolledLabel[i].Size = new Size(Scales.DicedImageSize, Scales.DicedImageSize);
                diceRolledLabel[i].Tag = i;
                diceChoosenLabel[i].Tag = i;
                diceChoosenLabel[i].Location = new Point(Scales.DicedImageLocationX[i], 2);
                diceChoosenLabel[i].Size = new Size(Scales.DicedImageSize, Scales.DicedImageSize);
                diceRolledLabel[i].Image = Scales.setDiceImage(0);
                diceChoosenLabel[i].Image = Scales.setDiceImage(0);
                diceRolled.Controls.Add(diceRolledLabel[i]);
                diceChoosen.Controls.Add(diceChoosenLabel[i]);
                if (i < 4)
                {
                    playerPanel[i] = new Panel();
                    playerNumber[i] = new Label();
                    playerTextBox[i] = new TextBox();
                    addPlayerButton[i] = new MyButton();
                    playerName[i] = new Label();

                    playerPanel[i].Location = new Point(Scales.RightPanelsLocationX, Scales.PlayerPanelLocationY[i]);
                    playerPanel[i].Size = new Size(Scales.RightPanelsWidth, Scales.PlayerPanelHeight);
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
                    playerTextBox[i].MinimumSize = new Size(Scales.PlayerNameWidth, Scales.PlayerNameHeight);
                    playerTextBox[i].Visible = false;

                    playerName[i].Location = new Point(playerTextBox[i].Location.X, 2);
                    playerName[i].Size = new Size(Scales.PlayerNameWidth, Scales.PlayerNameHeight);
                    playerName[i].BackColor = Color.LemonChiffon;
                    playerName[i].Tag = i;
                    playerName[i].TextAlign = ContentAlignment.MiddleCenter;
                    playerName[i].Font = new Font("Verdana", 10, FontStyle.Bold);

                    addPlayerButton[i].Location = new Point(Scales.ThrowButtonLocationX, 1);
                    addPlayerButton[i].Size = new Size(Scales.ThrowButtonWidth, playerPanel[i].Height - 2);
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

            //panel with buttons
            buttonsPanel.Location = new Point(Scales.RightPanelsLocationX, Scales.ButtonsPanelLocationY);
            buttonsPanel.Size = new Size(Scales.RightPanelsWidth, Scales.ButtonsPanelHeight);
            buttonsPanel.BackColor = Color.Black;
            newGameButton.Location = new Point(1, 1);
            newGameButton.Size = new Size(Scales.RightPanelsWidth - 2, Scales.ButtonsHeight);
            newGameButton.Text = "Rozpocznij grę";
            newGameButton.BackColor = SystemColors.Control;
            bestScoresButton.Location = new Point(1, Scales.ButtonsHeight + 1);
            bestScoresButton.Size = new Size(Scales.RightPanelsWidth - 2, Scales.ButtonsHeight);
            bestScoresButton.Text = "Najlepsze wyniki";
            bestScoresButton.BackColor = SystemColors.Control;
            buttonsPanel.Controls.Add(newGameButton);
            buttonsPanel.Controls.Add(bestScoresButton);

            for (int i = 0; i < ScoreBoard.BoardWidth; i++)
            {
                for (int j = 0; j < ScoreBoard.BoardHeight; j++)
                {
                    scoreBoard.Board[i, j].Tag = new Cell() { X = i, Y = j };
                    if (i != 0 && j != 0) scoreBoard.Board[i, j].Text = "";
                    if (j == 7 || j == 8 || j == 16 || j == 17 || j == 18)
                    {
                        if (i != 0)
                        {
                            scoreBoard.Board[i, j].Text = "0";
                        }
                    }
                    scoresPanel.Controls.Add(scoreBoard.Board[i, j]);
                }
            }

            main.Controls.Add(scoresPanel);
            main.Controls.Add(diceRolled);
            main.Controls.Add(game);
            main.Controls.Add(diceChoosen);
            main.Controls.Add(buttonsPanel);
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
