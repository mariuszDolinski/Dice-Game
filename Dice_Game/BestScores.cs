namespace Dice_Game
{
    internal class BestScores
    {
        public List<Player> BestScoresList { get; set; } = new List<Player>();

        public void createDefaultList()
        {
            for (int i = 0; i < 10; i++)
            {
                BestScoresList.Add(new Player());
            }
        }

        public bool addBestScore(Player player)
        {
            if (BestScoresList.Last().Score < player.Score)
            {
                BestScoresList.Add(player);
                BestScoresList = BestScoresList.OrderByDescending(a => a.Score).ToList();
                BestScoresList.RemoveAt(BestScoresList.Count - 1);
                return true;
            }
            return false;
        }
    }
}
