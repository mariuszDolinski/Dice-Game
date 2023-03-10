using Dice_Game.Properties;

namespace Dice_Game
{
    internal class Scales
    {
        public static int MenuHeight { get; set; }
        public static float Scale { get; set; }
        public static int ScoresPanelWidth;
        public static int ScoresPanelHeight;
        public static int RightPanelsWidth;
        public static int DicedPanelHeight;
        public static int DicedChoosenPanelLocationY;
        public static int[] DicedImageLocationX;
        public static int DicedImageSize;
        public static int RightPanelsLocationX;
        public static int GameLocationY;
        public static int GamePanelHeight;
        public static int GameLabelWidth;
        public static int GameInnerHeight;
        public static int GameNumberWidth;
        public static int TurnNumberLocationX;
        public static int ThrowLabelLocationX;
        public static int ThrowNumberLocationX;
        public static int ThrowButtonLocationX;
        public static int ThrowButtonWidth;
        public static int ThrowButtonHeight;
        public static int PlayerPanelLocationX;
        public static int[] PlayerPanelLocationY;
        public static int PlayerPanelHeight;
        public static int PlayerNameWidth;
        public static int PlayerNameHeight;
        public static int ButtonsPanelLocationY;
        public static int ButtonsPanelHeight;
        public static int ButtonsHeight;

        //bestscore
        public static int WindowWidthBS;
        public static int WindowHeightBS;
        public static int PanelWidthBS;
        public static int PanelHeightBS;
        public static int FirstColBS;
        public static int SecondColBS;
        public static int ThirdColBS;
        public static int FourthColBS;
        public static int CellHeightBS;

        public static void Init(float scale) 
        {
            Scale = scale;
            int offset;
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
                RightPanelsLocationX = (int)Math.Round(Scale * 277);
                GameLocationY = (int)Math.Round(Scale * 56) + MenuHeight - 1;
                DicedChoosenPanelLocationY = (int)Math.Round(Scale * (GameLocationY + GamePanelHeight + 2));
            }
            else
            {
                RightPanelsLocationX = (int)Math.Round(Scale * 281) - 7;
                GameLocationY = (int)Math.Round(Scale * 56) - 2 + MenuHeight;
                DicedChoosenPanelLocationY = GameLocationY + GamePanelHeight + 3;
            }
            DicedImageLocationX = new int[ScoreBoard.BoardWidth];
            for(int i =0; i< ScoreBoard.BoardWidth; i++)
            {
                DicedImageLocationX[i] = 2 + (int)Math.Round(Scale * 47 * i);
            }
            DicedImageSize = (Scale == 1.5F) ? (int)Math.Round(Scale * 48) : (int)Math.Round(Scale * 47);
            GameLabelWidth = (int)Math.Round((double)(5 * RightPanelsWidth / 20));
            GameInnerHeight = (Scale == 1.0F) ? (int)Math.Round(Scale * 23) : (int)Math.Round(Scale * 24);
            GameNumberWidth = (int)Math.Round((double)(RightPanelsWidth / 10 + 3));
            offset = (Scale == 1.0) ? 3 : 4;
            TurnNumberLocationX = GameLabelWidth + offset;
            offset = (Scale == 1.0) ? 4 : 6;
            ThrowLabelLocationX = GameLabelWidth + GameNumberWidth + offset;
            offset = (Scale == 1.0) ? 5 : 8;
            ThrowNumberLocationX = 2 * GameLabelWidth + GameNumberWidth + offset;
            offset = (Scale == 1.0) ? 5 : 9;
            ThrowButtonLocationX = 2 * GameLabelWidth + 2 * GameNumberWidth + offset;
            ThrowButtonWidth = (int)Math.Round((double)(5 * RightPanelsWidth / 20 + 5));
            ThrowButtonHeight = GameInnerHeight + 2;
            PlayerPanelHeight = (int)Math.Round(Scale * 27);
            PlayerPanelLocationY = new int[4];
            for (int i = 0; i < 4; i++)
            {
                if (Scale == 1.5F)
                    PlayerPanelLocationY[i] = (int)Math.Round((double)(DicedChoosenPanelLocationY + DicedPanelHeight + 3 + (43 * i)));
                else
                    PlayerPanelLocationY[i] = (int)Math.Round((double)(DicedChoosenPanelLocationY + DicedPanelHeight + 3 + (29 * i))-1);
            }
            offset = (Scale == 1.0) ? 6 : 8;
            PlayerNameWidth = (5 * RightPanelsWidth) / 10 + offset;
            PlayerNameHeight = PlayerPanelHeight - 4;
            if(Scale == 1.5F)
                ButtonsPanelLocationY = PlayerPanelLocationY[3] + PlayerPanelHeight + 3;
            else
                ButtonsPanelLocationY = PlayerPanelLocationY[3] + PlayerPanelHeight + 2;
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
