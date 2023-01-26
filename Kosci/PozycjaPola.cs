using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kosci
{
    class PozycjaPola
    {
        public int X { get; set; }
        public int Y { get; set; }

        public override bool Equals(object obj)
        {
            return (X == ((PozycjaPola)obj).X) && (Y == ((PozycjaPola)obj).Y);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
