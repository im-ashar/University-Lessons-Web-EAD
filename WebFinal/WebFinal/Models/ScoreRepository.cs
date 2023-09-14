namespace WebFinal.Models
{
    public class ScoreRepository
    {
        public int AddScore(int score)
        {
            var db = new AppDbContext();
            var sc = new Score { PlayerScore = score };
            db.Scores.Add(sc);
            db.SaveChanges();
            return GetScore();
        }
        public int GetScore()
        {
            var db = new AppDbContext();
            var listOfScores = db.Scores.ToList();
            int totalScore = 0;
            foreach (var score in listOfScores)
            {
                totalScore = score.PlayerScore + totalScore;
            }
            return totalScore;
        }
    }
}
