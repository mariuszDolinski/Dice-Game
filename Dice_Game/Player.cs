using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice_Game
{
    internal class Player
    {
        public Player() 
        {
            Name= string.Empty;
            Score = 0;
        } 
        public string Name { get; set; }
        public int Score { get; set; }

    }
}
