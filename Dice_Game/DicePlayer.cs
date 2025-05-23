﻿namespace Dice_Game
{
    internal class DicePlayer : Player
    {
        public DicePlayer()
        {
            resetPlayer(true);
        }
        public int UpperSum { get; set; }
        public int LowerSum { get; set; }
        public int UpperBonus { get; set; }
        public int LowerBonus { get; set; }
        public int YahtzeeBonus { get; set; }
        public bool Active { get; set; } //indicate if player is currently playing
        public int Yahtzees { get; set; }

        public void resetPlayer(bool mode)
        {
            if(mode) Active = false;
            YahtzeeBonus = 0;
            UpperBonus = 0;
            LowerBonus = 0;
            UpperSum = 0;
            LowerSum = 0;
            Yahtzees = 0;
            Score = 0;
        }
    }
}
