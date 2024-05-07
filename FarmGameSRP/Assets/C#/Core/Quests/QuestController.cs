using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestController : MonoBehaviour
{
    [SerializeField] private List<Quest> quests;
    private GameManager GameManager => FindAnyObjectByType<GameManager>();
    private List<string> QuestData {get => GameManager.GameData.QuestData; set => GameManager.GameData.QuestData = value; }

    private void OnEnable() => Quest.OnQuestCompleted += QuestComplete;

    private void OnDisable() => Quest.OnQuestCompleted -= QuestComplete;

    private void Start() => UpdateData();

    private void QuestComplete((string code, int pointsGained) quest)
    {
        QuestData.Add(quest.code);
        GameManager.LevelData.Add(quest.pointsGained);
        UpdateData();
    }

    private void UpdateData()
    {
        for (int i = 0; i < quests.Count; i++)
            for (int j = 0; j < QuestData.Count; j++)
                if(quests[i].Code == QuestData[j])
                    quests[i].ToggleQuest(false);
    }

    private void Update()
    {
        for (int i = 0; i < quests.Count; i++)
            quests[i].UpdateProgress();
    }
}
