using Dice_Game.Properties;

namespace Dice_Game
{
    internal class Scales
    {
        public static readonly float Scale = 1.5F;
        public static readonly int ScoresPanelWidth;
        public static readonly int ScoresPanelHeight;
        public static readonly int RightPanelsWidth;
        public static readonly int DicedPanelHeight;
        public static readonly int DicedChoosenPanelLocationY;
        public static readonly int[] DicedImageLocationX;
        public static readonly int DicedImageSize;
        public static readonly int RightPanelsLocationX;
        public static readonly int GameLocationY;
        public static readonly int GamePanelHeight;
        public static readonly int GameLabelWidth;
        public static readonly int GameInnerHeight;
        public static readonly int GameNumberWidth;
        public static readonly int TurnNumberLocationX;
        public static readonly int ThrowLabelLocationX;
        public static readonly int ThrowNumberLocationX;
        public static readonly int ThrowButtonLocationX;
        public static readonly int ThrowButtonWidth;
        public static readonly int ThrowButtonHeight;
        public static readonly int PlayerPanelLocationX;
        public static readonly int[] PlayerPanelLocationY;
        public static readonly int PlayerPanelHeight;
        public static readonly int PlayerNameWidth;
        public static readonly int PlayerNameHeight;
        public static readonly int ButtonsPanelLocationY;
        public static readonly int ButtonsPanelHeight;
        public static readonly int ButtonsHeight;

        //bestscore
        public static readonly int WindowWidthBS;
        public static readonly int WindowHeightBS;
        public static readonly int PanelWidthBS;
        public static readonly int PanelHeightBS;
        public static readonly int FirstColBS;
        public static readonly int SecondColBS;
        public static readonly int ThirdColBS;
        public static readonly int FourthColBS;
        public static readonly int CellHeightBS;

        static Scales() 
        {
            if (Scale == 1.0F)
                ScoresPanelWidth = (int)Math.Round(Scale * 274);
            else
                ScoresPanelWidth = (int)Math.Round(Scale * 274) - 1;
            if (Scale == 1.0F)
                ScoresPanelHeight = (int)Math.Round(Scale * 385);
            else
                ScoresPanelHeight = (int)Math.Round(Scale * 385) - 2;
            RightPanelsWidth = (int)Math.Round(Scale * 239);
            DicedPanelHeight = (int)Math.Round(Scale * 51);
            GamePanelHeight = (int)Math.Round(Scale * 27);
            if(Scale == 1.0F)
            {
                RightPanelsLocationX = (int)Math.Round(Scale * 281);
                GameLocationY = (int)Math.Round(Scale * 56);
                DicedChoosenPanelLocationY = (int)Math.Round(Scale * (GameLocationY + GamePanelHeight + 4));
            }
            else
            {
                RightPanelsLocationX = (int)Math.Round(Scale * 281) - 7;
                GameLocationY = (int)Math.Round(Scale * 56) - 2;
                DicedChoosenPanelLocationY = GameLocationY + GamePanelHeight + 3;
            }
            DicedImageLocationX = new int[ScoreBoard.BoardWidth];
            for(int i =0; i< ScoreBoard.BoardWidth; i++)
            {
                DicedImageLocationX[i] = 2 + (int)Math.Round(Scale * 47 * i);
            }
            DicedImageSize = (int)Math.Round(Scale * 48);
            GameLabelWidth = (int)Math.Round((double)(5 * RightPanelsWidth / 20));
            GameInnerHeight = (Scale == 1.0F) ? (int)Math.Round(Scale * 23) : (int)Math.Round(Scale * 24);
            GameNumberWidth = (int)Math.Round((double)(RightPanelsWidth / 10 + 3));
            TurnNumberLocationX = GameLabelWidth + 4;
            ThrowLabelLocationX = GameLabelWidth + GameNumberWidth + 6;
            ThrowNumberLocationX = 2 * GameLabelWidth + GameNumberWidth + 8;
            ThrowButtonLocationX = 2 * GameLabelWidth + 2 * GameNumberWidth + 9;
            ThrowButtonWidth = (int)Math.Round((double)(5 * RightPanelsWidth / 20 + 5));
            ThrowButtonHeight = GameInnerHeight + 2;
            PlayerPanelHeight = (int)Math.Round(Scale * 27);
            PlayerPanelLocationY = new int[4];
            for (int i = 0; i < 4; i++)
            {
                if (Scale == 1.5F)
                    PlayerPanelLocationY[i] = (int)Math.Round((double)(DicedChoosenPanelLocationY + DicedPanelHeight + 3 + (43 * i)));
                else
                    PlayerPanelLocationY[i] = (int)Math.Round((double)(DicedChoosenPanelLocationY + DicedPanelHeight + 3 + (31 * i)));
            }
            int offset = (Scale == 1.0) ? 6 : 8;
            PlayerNameWidth = (5 * RightPanelsWidth) / 10 + offset;
            PlayerNameHeight = PlayerPanelHeight - 4;
            ButtonsPanelLocationY = PlayerPanelLocationY[3] + PlayerPanelHeight + 3;
            ButtonsPanelHeight = (int)Math.Round(Scale * 52);
            ButtonsHeight = (int)Math.Round(Scale * 25);

            //bestscores
            if(Scale == 1.0F)
            {
                WindowWidthBS = (int)Math.Round(Scale * 500);
                WindowHeightBS = (int)Math.Round(Scale * 267);
                PanelWidthBS = (int)Math.Round(Scale * 475);
                PanelHeightBS = (int)Math.Round(Scale * 224);
            }
            else
            {
                WindowWidthBS = (int)Math.Round(Scale * 490);
                WindowHeightBS = (int)Math.Round(Scale * 259);
                PanelWidthBS = (int)Math.Round(Scale * 475);
                PanelHeightBS = (int)Math.Round(Scale * 224);
            }

            FirstColBS = WindowWidthBS / 10 - (int)Math.Round(Scale * 18);
            SecondColBS = 9 * WindowWidthBS / 20 - (int)Math.Round(Scale * 2);
            ThirdColBS = 3 * WindowWidthBS / 20 - (int)Math.Round(Scale * 2);
            FourthColBS = 3 * WindowWidthBS / 10 - (int)Math.Round(Scale * 8);
            CellHeightBS = (int)Math.Round(Scale * 19);
        }
        /// <summary>
        /// set dice image depends on scale
        /// </summary>
        /// <param name="i">number on dice, 0 for empty slot</param>
        public static Bitmap setDiceImage(int i)
        {
            if(Scale == 1.5F)
            {
                switch (i)
                {
                    case 1: return Resources.dice01y;
                    case 2: return Resources.dice02y;
                    case 3: return Resources.dice03y;
                    case 4: return Resources.dice04y;
                    case 5: return Resources.dice05y;
                    case 6: return Resources.dice06y;
                    default: return Resources.empty;
                }
            }
            else
            {
                switch (i)
                {
                    case 1: return Resources.kosci01;
                    case 2: return Resources.kosci02;
                    case 3: return Resources.kosci03;
                    case 4: return Resources.kosci04;
                    case 5: return Resources.kosci05;
                    case 6: return Resources.kosci06;
                    default: return Resources.pusty;
                }
            }
        }
    }

}
