using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice_Game
{
    internal class Scales
    {
        public static readonly float Scale = 1.5F;
        public static readonly int ScoresPanelSizeX;
        public static readonly int ScoresPanelSizeY;
        public static readonly int DicedPanelSizeX;
        public static readonly int DicedPanelSizeY;
        public static readonly int DicedChoosenPanelLocationY;
        public static readonly int GameLocationX;
        public static readonly int GameLocationY;
        public static readonly int GameSizeX;
        public static readonly int GameSizeY;

        static Scales() 
        {
            if (Scale == 1.0F)
                ScoresPanelSizeX = (int)Math.Round(Scale * 274);
            else
                ScoresPanelSizeX = (int)Math.Round(Scale * 274) - 1;
            if (Scale == 1.0F)
                ScoresPanelSizeY = (int)Math.Round(Scale * 385);
            else
                ScoresPanelSizeY = (int)Math.Round(Scale * 385) - 2;
            DicedPanelSizeX = (int)Math.Round(Scale * 239);
            DicedPanelSizeY = (int)Math.Round(Scale * 51);
            GameSizeX = DicedPanelSizeX;
            GameSizeY = (int)Math.Round(Scale * 27);
            if(Scale == 1.0F)
            {
                GameLocationX = (int)Math.Round(Scale * 281);
                GameLocationY = (int)Math.Round(Scale * 56);
                DicedChoosenPanelLocationY = (int)Math.Round(Scale * (GameLocationY + GameSizeY + 3));
            }
            else
            {
                GameLocationX = (int)Math.Round(Scale * 281) - 7;
                GameLocationY = (int)Math.Round(Scale * 56) - 2;
                DicedChoosenPanelLocationY = GameLocationY + GameSizeY + 3;
            }
        }
    }

}
