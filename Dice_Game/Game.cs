using Newtonsoft.Json;

namespace Dice_Game
{
    internal class Game : GameBoard
    {
        public Game(Main main, float scale) : base(main, scale)
        {
            generate = new Random();
            player = new DicePlayer[4];
            throwResult = new int[5];
            numberCount = new int[6];
            choosenDice = new bool[5];
            choosenCategories = new bool[4, 19];
            addPlayerMode = new int[4];
            initGame();
        }

        #region definition of variables

        Random? generate;
        BestScores highScores = new BestScores();

        private int[] throwResult; //throw result on each dice
        private int[] numberCount; //count how many of each number was rolled
        private bool[] choosenDice; //if true this dice is choosen
        private bool[,] choosenCategories; // if [i,j] is true, i category is choosen by j player

        private DicePlayer[] player;
        private bool isGameOn; //true ig game is started, otherwise false
        private int currentTurn;
        private int currentThrow;
        private bool showPossiblePoints; //indicate if points should be shown in table for current player
        private int currentPlayer; //index of active player
        //private int firstPlayer; //index of first player in game
        private int lastPlayer; //index of last player in game
        private int[] addPlayerMode; //use to determine state of addPlayer button

        private const string _bestScoresFileDirectory = "bs";
        private const string _pathBestScores = _bestScoresFileDirectory + @"\bestscores.json";
        #endregion

        private void initGame()
        {
            for (int i = 0; i < 4; i++)
            {
                addPlayerMode[i] = 0;
                player[i] = new DicePlayer();
            }
            initNewGame();
            turnNumber.Text = "0"; //set to 0 after launching program
            isGameOn = false; //set to false because initNewGame set this true

            initBestScoresFile();
        }

        private void initNewGame()
        {
            isGameOn = true;
            currentTurn = 1;
            currentThrow = 0;
            currentPlayer = findFirstPlayer();
            //firstPlayer = currentPlayer;
            lastPlayer = findLastPlayer();
            setPlayersColors(currentPlayer);
            showPossiblePoints = false;
            turnNumber.Text = currentTurn.ToString();
            throwNumber.Text = currentThrow.ToString();

            for (int i = 0; i < ScoreBoard.BoardWidth; i++)
            {
                choosenDice[i] = false;
                throwResult[i] = 1;
                numberCount[i] = 0;
            }
            numberCount[5] = 0;
            for (int i = 0; i < ScoreBoard.BoardHeight; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (i == 0 || i == 7 || i == 8 || i == 16 || i == 17 || i == 18)
                    {
                        choosenCategories[j, i] = true;
                    }
                    else
                    {
                        choosenCategories[j, i] = false;
                    }
                }
            }

            for (int i = 0; i < ScoreBoard.BoardWidth; i++)
            {
                for (int j = 0; j < ScoreBoard.BoardHeight; j++)
                {
                    if (i != 0 && j != 0) scoreBoard.Board[i, j].Text = "";
                    if (j == 7 || j == 8 || j == 16 || j == 17 || j == 18)
                    {
                        if (i != 0)
                        {
                            scoreBoard.Board[i, j].Text = "0";
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Ends current game
        /// </summary>
        /// <param name="mode">if true all turns was played</param>
        private void endCurrentGame(bool mode)
        {
            isGameOn = false;
            newGameButton.Text = "Rozpocznij grę";
            resetPlayersColors();
            for (int i = 0; i < 5; i++)
            {
                choosenDice[i] = false;
                diceChoosenLabel[i].Image = Scales.setDiceImage(0);
                diceRolledLabel[i].Image = Scales.setDiceImage(0);
            }
            if(mode)
            {
                for (int i = 0; i < 4; i++)
                {
                    Player tPlayer = new Player();
                    if (player[i].Active)
                    {
                        tPlayer.Name = player[i].Name;
                        tPlayer.Score = player[i].Score;
                        tPlayer.Date = DateTime.Now;
                        if (highScores.addBestScore(tPlayer))
                        {
                            string hsSerialized = JsonConvert.SerializeObject(highScores, Formatting.Indented);
                            File.WriteAllText(_pathBestScores, hsSerialized);
                            MessageBox.Show($"Gracz {player[i].Name} uzyskał jeden z najlepszych wyników" +
                                Environment.NewLine + "Wejdź w Najlepsze wyniki aby sprawdzić pozycję.",
                                "Gratulacje!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }

                if (numberOfPlayers() > 1)
                {
                    int winnerIndex = findFirstPlayer() - 1;
                    for(int i=winnerIndex; i < 4; i++)
                    {
                        if (player[i].Active && player[i].Score > player[winnerIndex].Score) 
                        {
                            winnerIndex = i;
                        }
                    }
                    int[] winners = new int[4] {0, 0, 0, 0};
                    int winnersCount = 0;
                    for(int i = 0; i < 4; i++)
                    {
                        if (player[i].Active && player[i].Score == player[winnerIndex].Score)
                        {
                            winners[i] = 1;
                            winnersCount++;
                        }
                    }

                    if(winnersCount == 1)
                        MessageBox.Show($"Gracz {player[winnerIndex].Name} wygrał. Gratulacje!",
                        "Koniec gry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show($"Gra zakończona remisem.",
                        "Koniec gry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>
        /// Return number of first player in game or 0 if no player was found
        /// </summary>
        /// <returns></returns>
        private int findFirstPlayer()
        {
            for (int i = 0; i < 4; i++)
            {
                if (player[i].Active) return i + 1;
            }
            return 0;
        }

        /// <summary>
        /// Return number of last player in game  or 0 if no player was found
        /// </summary>
        /// <returns></returns>
        private int findLastPlayer()
        {
            for (int i = 3; i >= 0; i--)
            {
                if (player[i].Active) return i + 1;
            }
            return 0;
        }

        /// <summary>
        /// Return count of added players
        /// </summary>
        /// <returns></returns>
        private int numberOfPlayers()
        {
            int result = 0;
            for (int i = 0; i < 4; i++)
            {
                if (player[i].Active) result++;
            }
            return result;
        }

        /// <summary>
        /// Implementation of single throw
        /// </summary>
        private void throwHandle()
        {
            turnNumber.Text = currentTurn.ToString();
            throwNumber.Text = currentThrow.ToString();
            makeThrow();
            displayThrow();
        }
        private void makeThrow()
        {
            if (generate != null)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (!choosenDice[i])
                    {
                        throwResult[i] = generate.Next(6) + 1;
                    }
                }
                countRepeats();
            }
        }
        private void countRepeats()
        {
            int count;
            for (int i = 1; i < 7; i++)
            {
                count = 0;
                for (int j = 0; j < 5; j++)
                {
                    if (throwResult[j] == i) count++;
                }
                numberCount[i - 1] = count;
            }
        }
        private void displayThrow()
        {
            for (int i = 0; i < 5; i++)
            {
                if (!choosenDice[i])
                {
                    switch (throwResult[i])
                    {
                        case 1: diceRolledLabel[i].Image = Scales.setDiceImage(1); break;
                        case 2: diceRolledLabel[i].Image = Scales.setDiceImage(2); break;
                        case 3: diceRolledLabel[i].Image = Scales.setDiceImage(3); break;
                        case 4: diceRolledLabel[i].Image = Scales.setDiceImage(4); break;
                        case 5: diceRolledLabel[i].Image = Scales.setDiceImage(5); break;
                        case 6: diceRolledLabel[i].Image = Scales.setDiceImage(6); break;
                    }
                }
            }
        }
        private void changeCurrentPLayer()
        {
            for (int i = 0; i < 4; i++)
            {
                currentPlayer++;
                if (currentPlayer < 5)
                {
                    if (player[currentPlayer - 1].Active)
                    {
                        setPlayersColors(currentPlayer);
                        return;
                    }
                }
                else//start from beggining if last player was reached
                {
                    currentPlayer = 0;
                    i--;
                }
            }
        }

        /// <summary>
        /// Method update points on scoreBoard
        /// </summary>
        /// <param name="i">player number</param>
        /// <param name="j">catgory number</param>
        /// <param name="p">false - preview mode, true - type mode</param>
        private void updatePoints(int i, int j, bool p)
        {
            int points = 0;
            bool upper = false;
            switch (j)//switch category
            {
                case 1:
                    scoreBoard.Board[i, j].Text = numberCount[0].ToString();
                    points = numberCount[0];
                    upper = true;
                    break;
                case 2:
                    scoreBoard.Board[i, j].Text = (numberCount[1] * 2).ToString();
                    points = 2 * numberCount[1];
                    upper = true;
                    break;
                case 3:
                    scoreBoard.Board[i, j].Text = (numberCount[2] * 3).ToString();
                    points = 3 * numberCount[2];
                    upper = true;
                    break;
                case 4:
                    scoreBoard.Board[i, j].Text = (numberCount[3] * 4).ToString();
                    points = 4 * numberCount[3];
                    upper = true;
                    break;
                case 5:
                    scoreBoard.Board[i, j].Text = (numberCount[4] * 5).ToString();
                    points = 5 * numberCount[4];
                    upper = true;
                    break;
                case 6:
                    scoreBoard.Board[i, j].Text = (numberCount[5] * 6).ToString();
                    points = 6 * numberCount[5];
                    upper = true;
                    break;
                case 9:
                    upper = false;
                    if (isTwoPairs())
                    {
                        points = 20 + (5 * (3 - currentThrow));
                        scoreBoard.Board[i, j].Text = points.ToString();
                    }
                    else
                    {
                        points = 0;
                        scoreBoard.Board[i, j].Text = "0";
                    }
                    break;
                case 10:
                    upper = false;
                    if (isThreeOfAKind())
                    {
                        points = 25 + (5 * (3 - currentThrow));
                        scoreBoard.Board[i, j].Text = points.ToString();
                    }
                    else
                    {
                        points = 0;
                        scoreBoard.Board[i, j].Text = "0";
                    }
                    break;
                case 11:
                    upper = false;
                    if (isFourOfAKind())
                    {
                        points = 35 + (5 * (3 - currentThrow));
                        scoreBoard.Board[i, j].Text = points.ToString();
                    }
                    else
                    {
                        points = 0;
                        scoreBoard.Board[i, j].Text = "0";
                    }
                    break;
                case 12:
                    upper = false;
                    if (isStraight())
                    {
                        points = 30 + (5 * (3 - currentThrow));
                        scoreBoard.Board[i, j].Text = points.ToString();
                    }
                    else
                    {
                        points = 0;
                        scoreBoard.Board[i, j].Text = "0";
                    }
                    break;
                case 13:
                    upper = false;
                    if (isFullHouse())
                    {
                        points = 30 + (5 * (3 - currentThrow));
                        scoreBoard.Board[i, j].Text = points.ToString();
                    }
                    else
                    {
                        points = 0;
                        scoreBoard.Board[i, j].Text = "0";
                    }
                    break;
                case 14:
                    upper = false;
                    if (isYahtzee())
                    {
                        points = 50 + (5 * (3 - currentThrow));
                        scoreBoard.Board[i, j].Text = points.ToString();
                    }
                    else
                    {
                        points = 0;
                        scoreBoard.Board[i, j].Text = "0";
                    }
                    break;
                case 15:
                    points = chance();
                    upper = false;
                    scoreBoard.Board[i, j].Text = chance().ToString();
                    break;
            }
            if (p)
            {
                if (isYahtzee())
                    player[currentPlayer - 1].Yahtzees++;//increase yahtzees only after click
                if (upper)
                    player[i - 1].UpperSum += points;
                else
                    player[i - 1].LowerSum += points;

                if (isUpperBonus() && player[i - 1].UpperBonus == 0)
                    player[i - 1].UpperBonus = 20;
                if (isLowerBonus() && player[i - 1].LowerBonus == 0)
                    player[i - 1].LowerBonus = 30;
                if (isYahtzeeBonus())
                    player[i - 1].YahtzeeBonus += 40;

                calculateOverallScore();

                scoreBoard.Board[i, 7].Text = player[i - 1].UpperSum.ToString();
                scoreBoard.Board[i, 8].Text = player[i - 1].UpperBonus.ToString();
                scoreBoard.Board[i, 16].Text = player[i - 1].LowerSum.ToString();
                scoreBoard.Board[i, 17].Text = (player[i - 1].LowerBonus + player[i - 1].YahtzeeBonus).ToString();
                scoreBoard.Board[i, 18].Text = player[i - 1].Score.ToString();
                currentThrow = 4;
            }
        }

        #region methods calculating points
        private bool isTwoPairs()
        {
            int pairs = 0;
            if (isYahtzee()) return true;
            if (isFourOfAKind()) return true;
            for (int i = 0; i < 6; i++)
            {
                if (numberCount[i] >= 2)
                {
                    pairs++;
                }
                if (pairs == 2) return true;
            }
            return false;
        }
        private bool isThreeOfAKind()
        {
            for (int i = 0; i < 6; i++)
            {
                if (numberCount[i] >= 3) return true;
            }
            return false;
        }
        private bool isFourOfAKind()
        {
            for (int i = 0; i < 6; i++)
            {
                if (numberCount[i] >= 4) return true;
            }
            return false;
        }
        private bool isStraight()
        {
            if (isYahtzee()) return true;
            if (numberCount[0] == 1 && numberCount[1] == 1 && numberCount[2] == 1 &&
                numberCount[3] == 1 && numberCount[4] == 1) return true;
            if (numberCount[5] == 1 && numberCount[1] == 1 && numberCount[2] == 1 &&
                numberCount[3] == 1 && numberCount[4] == 1) return true;
            return false;
        }
        private bool isFullHouse()
        {
            bool three = false, two = false;
            if (isYahtzee()) return true;
            for (int i = 0; i < 6; i++)
            {
                if (numberCount[i] == 3) three = true;
                if (numberCount[i] == 2) two = true;
                if (two && three) return true;
            }
            return false;
        }
        private bool isYahtzee()
        {
            for (int i = 0; i < 6; i++)
            {
                if (numberCount[i] == 5) return true;
            }
            return false;
        }
        private int chance()
        {
            int sum = 0;
            for (int i = 0; i < 5; i++)
            {
                sum += throwResult[i];
            }
            return sum;
        }
        private bool isUpperBonus()// +20 points for at least 60 points in upper categories
        {
            if (player[currentPlayer - 1].UpperSum >= 60) return true;
            return false;
        }
        private bool isLowerBonus() // +30 points for gaining all lower categories
        {
            if (scoreBoard.Board[1, 9].Text != "" && scoreBoard.Board[1, 9].Text != "0"
                && scoreBoard.Board[currentPlayer, 10].Text != "" && scoreBoard.Board[currentPlayer, 10].Text != "0"
                && scoreBoard.Board[currentPlayer, 11].Text != "" && scoreBoard.Board[currentPlayer, 11].Text != "0"
                && scoreBoard.Board[currentPlayer, 12].Text != "" && scoreBoard.Board[currentPlayer, 12].Text != "0"
                && scoreBoard.Board[currentPlayer, 13].Text != "" && scoreBoard.Board[currentPlayer, 13].Text != "0"
                && scoreBoard.Board[currentPlayer, 14].Text != "" && scoreBoard.Board[currentPlayer, 14].Text != "0"
                && scoreBoard.Board[currentPlayer, 15].Text != "" && scoreBoard.Board[currentPlayer, 15].Text != "0")
                return true;
            return false;
        }
        private bool isYahtzeeBonus() // +40 points for any extra Yahtzee except first
        {
            if (isYahtzee() && player[currentPlayer - 1].Yahtzees > 1
                && scoreBoard.Board[currentPlayer, 14].Text != "0") return true;
            return false;
        }
        private void calculateOverallScore()
        {
            int i = currentPlayer - 1;
            player[i].Score = player[i].UpperSum + player[i].LowerSum + player[i].UpperBonus + player[i].LowerBonus + player[i].YahtzeeBonus;
        }
        #endregion

        private void initBestScoresFile()
        {
            Directory.CreateDirectory(_bestScoresFileDirectory).
                Attributes |= FileAttributes.Hidden;
            
            if (File.Exists(_pathBestScores))
            {
                string hsDeserialized = File.ReadAllText(_pathBestScores);
                if(hsDeserialized != null)
                    highScores = JsonConvert.DeserializeObject<BestScores>(hsDeserialized);
            }
            else
            {
                highScores.createDefaultList();
                string hsSerialized = JsonConvert.SerializeObject(highScores, Formatting.Indented);
                File.WriteAllText(_pathBestScores, hsSerialized);
            }
        }

        public void MouseEventsInitalize()
        {
            newGameButton.MouseClick += new MouseEventHandler(NewGameButton_MouseClick);
            throwDiceButton.MouseClick += new MouseEventHandler(throwDiceButton_MouseClick);
            bestScoresButton.MouseClick += new MouseEventHandler(bestScoresButton_MouseClick);
            for (int i = 0; i < 5; i++)
            {
                diceRolledLabel[i].MouseClick += new MouseEventHandler(diceRolledLabel_MouseClick);
                diceChoosenLabel[i].MouseClick += new MouseEventHandler(diceChoosenLabel_MouseClick);
                if (i < 4)
                {
                    playerName[i].MouseDoubleClick += new MouseEventHandler(playerName_MouseDoubleClick);
                    addPlayerButton[i].MouseClick += new MouseEventHandler(addPlayerButton_MouseClick);
                }
            }
            for (int i = 1; i < ScoreBoard.BoardWidth; i++)
            {
                for (int j = 1; j < ScoreBoard.BoardHeight; j++)
                {
                    scoreBoard.Board[i, j].MouseEnter += new EventHandler(scoreBoard_MouseEnter);
                    scoreBoard.Board[i, j].MouseLeave += new EventHandler(scoreBoard_MouseLeave);
                    scoreBoard.Board[i, j].MouseClick += new MouseEventHandler(scoreBoard_MouseClick);
                }
            }
        }

        public void ShowPlayerTextBox(int playerNumber)
        {
            playerName[playerNumber].Visible = false;
            playerTextBox[playerNumber].Visible = true;
            addPlayerButton[playerNumber].Text = "Dodaj";
            addPlayerMode[playerNumber] = 1;
        }

        #region MouseEventHandlers implementation
        private void playerName_MouseDoubleClick(object? sender, MouseEventArgs e)
        {
            if (!isGameOn && sender != null)
            {
                Label label = (Label)sender;
                int i = (int)label.Tag;

                ShowPlayerTextBox(i);
            }
        }
        private void addPlayerButton_MouseClick(object? sender, MouseEventArgs e)
        {
            if (sender != null)
            {
                MyButton button = (MyButton)sender;
                int i = (int)button.Tag;

                if (addPlayerMode[i] != 0 && playerTextBox[i].Text.Length > 2)
                {
                    if (addPlayerMode[i] == 1)//adding player name mode
                    {
                        addPlayerButton[i].Text = "Usuń";
                        playerName[i].Text = playerTextBox[i].Text;
                        playerTextBox[i].Visible = false;
                        playerName[i].Visible = true;
                        addPlayerMode[i] = 2;
                        player[i].Active = true;
                        player[i].Name = playerName[i].Text;
                    }
                    else if (addPlayerMode[i] == 2 && isGameOn == false)//remove player when game is off
                    {
                        addPlayerButton[i].Text = "Dodaj";
                        playerName[i].Text = "";
                        addPlayerMode[i] = 0;
                        player[i].Active = false;
                        player[i].Name = "";
                    }
                }
            }
        }
        public void NewGameButtonClicked()
        {
            if (numberOfPlayers() > 0)
            {
                if (isGameOn)
                {
                    isGameOn = false;
                    newGameButton.Text = "Rozpocznij grę";
                    endCurrentGame(false);
                }
                else
                {
                    isGameOn = false;
                    newGameButton.Text = "Zakończ grę";
                    initNewGame();
                }
            }
            else
            {
                isGameOn = false;
                string message = "Nie dodano żanych graczy.";
                message += Environment.NewLine;
                message += "Dodaj gracza kilkając dwa razy w pole obok przycisku 'Dodaj'";
                MessageBox.Show(message, "UWAGA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void NewGameButton_MouseClick(object? sender, MouseEventArgs e)
        {
            NewGameButtonClicked();
        }
        private void throwDiceButton_MouseClick(object? sender, MouseEventArgs e)
        {
            showPossiblePoints = true;
            if (isGameOn)
            {
                if (currentThrow == 3)
                {
                    MessageBox.Show($"Gracz {player[currentPlayer - 1].Name} musi przypisać punkty do wybranej kategorii.",
                        "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    currentThrow++;
                    throwHandle();
                }
            }
        }
        private void diceRolledLabel_MouseClick(object? sender, MouseEventArgs e)
        {
            if (sender != null)
            {
                Label dice = (Label)sender;
                int i = (int)dice.Tag;

                if (!choosenDice[i])
                {
                    diceChoosenLabel[i].Image = diceRolledLabel[i].Image;
                    diceRolledLabel[i].Image = Scales.setDiceImage(0);
                    choosenDice[i] = true;
                }
            }
        }
        private void diceChoosenLabel_MouseClick(object? sender, MouseEventArgs e)
        {
            if (sender != null)
            {
                Label dice = (Label)sender;
                int i = (int)dice.Tag;

                if (choosenDice[i])
                {
                    diceRolledLabel[i].Image = diceChoosenLabel[i].Image;
                    diceChoosenLabel[i].Image = Scales.setDiceImage(0);
                    choosenDice[i] = false;
                }
            }
        }
        private void scoreBoard_MouseEnter(object? sender, EventArgs e)
        {
            if (sender != null)
            {
                if (isGameOn && showPossiblePoints)
                {
                    Label pole = (Label)sender;
                    int i, j;
                    i = ((Cell)pole.Tag).X;
                    j = ((Cell)pole.Tag).Y;

                    if (i == currentPlayer && !choosenCategories[i - 1, j])
                    {
                        updatePoints(i, j, false);
                    }
                }
            }
        }
        private void scoreBoard_MouseLeave(object? sender, EventArgs e)
        {
            if (sender != null)
            {
                if (isGameOn && showPossiblePoints)
                {
                    Label pole = (Label)sender;
                    int i, j;
                    i = ((Cell)pole.Tag).X;
                    j = ((Cell)pole.Tag).Y;

                    if (i == currentPlayer && !choosenCategories[i - 1, j])
                        scoreBoard.Board[i, j].Text = "";
                }
            }
        }
        private void scoreBoard_MouseClick(object? sender, EventArgs e)
        {
            if (sender != null)
            {
                if (isGameOn && showPossiblePoints)
                {
                    Label pole = (Label)sender;
                    int i, j;
                    i = ((Cell)pole.Tag).X;
                    j = ((Cell)pole.Tag).Y;

                    if (i != currentPlayer)
                        return;
                    if (j == 0 || j == 7 || j == 8 || j == 16 || j == 17 || j == 18)
                        return;

                    // if column of current player and not choosen category ten assign points
                    if (i == currentPlayer && !choosenCategories[i - 1, j])
                    {
                        choosenCategories[i - 1, j] = true;
                        updatePoints(i, j, true);

                        //set next player turn
                        currentThrow = 0;
                        if (currentPlayer == lastPlayer)
                            currentTurn++;
                        for (int k = 0; k < 5; k++)
                        {
                            choosenDice[k] = false;
                            diceChoosenLabel[k].Image = Scales.setDiceImage(0);
                            diceRolledLabel[k].Image = Scales.setDiceImage(0);
                        }
                        turnNumber.Text = currentTurn.ToString();
                        throwNumber.Text = currentThrow.ToString();
                        //last turn and last player click = end game
                        if (currentTurn == 14)
                        {
                            endCurrentGame(true);
                            return;
                        }
                    }
                    changeCurrentPLayer();
                    showPossiblePoints = false; //if category is choosen don't show possible points in other categories
                }
            }
        }
        private void bestScoresButton_MouseClick(object? sender, MouseEventArgs e)
        {
            BestScoresWindow bs = new BestScoresWindow();
            bs.Show();
            bs.DisplayBestResults(highScores.BestScoresList);
        }
        #endregion
    }
}