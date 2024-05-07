using UnityEngine;
using UnityEngine.UI;

public class ResourceBar : MonoBehaviour
{
    [Header("Base resources")]
    [SerializeField] private Text foodText;
    [SerializeField] private Text woodText;
    [SerializeField] private Text stoneText;
    [SerializeField] private Text workerText;
    [Header("Extra resources")]
    [SerializeField] private Text gemsText;
    [Header("Level resources")]
    [SerializeField] private Text levelText;
    [SerializeField] private Image score;

    private SavedGameData GameData => FindAnyObjectByType<GameManager>().GameData;

    private void Update() => UpdateData();

    private void UpdateData()
    {
        ResourceData resource = GameData.Resources;
        LevelData levelData = GameData.Level;

        foodText.text = resource.Food.ToString();
        woodText.text = resource.Wood.ToString();
        stoneText.text = resource.Stone.ToString();
        workerText.text = resource.Worker.ToString();

        gemsText.text = GameData.Gems.ToString();

        levelText.text = levelData.Level.ToString();
        score.fillAmount = (float)levelData.Score / (float)levelData.ScoreToNextLevel;
    }
}
