using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelQuest : Quest
{
    [SerializeField] private int count;
    private GameManager GameManager => FindAnyObjectByType<GameManager>();

    public override void UpdateProgress()
    {
        base.UpdateProgress();
        var _count = GameManager.LevelData.Level;
        taskText.text = $"Достичь {count} уровня";
        progressText.text = $"{_count}/{count}";
        button.interactable = _count >= count;
    }
}
