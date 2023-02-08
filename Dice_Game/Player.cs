namespace Dice_Game
{
    public class Player
    {
        public Player()
        {
            Name = "Anonim";
            Score = 0;
            Date = DateTime.Now;
        }
        public string Name { get; set; }
        public int Score { get; set; }
        public DateTime Date { get; set; } = new DateTime();

    }
}
