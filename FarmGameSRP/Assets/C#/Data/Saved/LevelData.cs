using System;

[Serializable]
public class LevelData
{
    public static Action<int> OnLevelUp;
    public int Level;
    public int Score;

    public void Add(int score)
    {
        Score += score;
        while (Score >= ScoreToNextLevel)
        {
            Score -= ScoreToNextLevel;
            Level++;
            OnLevelUp?.Invoke(Level);
        }
    }
    public int ScoreToNextLevel => 50 * Level;
}
