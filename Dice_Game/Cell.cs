using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice_Game
{
    internal class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            return (X == ((Cell)obj).X) && (Y == ((Cell)obj).Y);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
