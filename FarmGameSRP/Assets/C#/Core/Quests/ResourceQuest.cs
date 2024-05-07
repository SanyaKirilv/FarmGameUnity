using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceQuest : Quest
{
    [SerializeField] private string resourceName;
    [SerializeField] private int count;
    private GameManager GameManager => FindAnyObjectByType<GameManager>();

    public override void UpdateProgress()
    {
        base.UpdateProgress();
        var _count = ResourceCount(resourceName);
        taskText.text = $"Накопить {count} ед ресурса [{resourceName}]";
        progressText.text = $"{_count}/{count}";
        button.interactable = _count >= count;
    }

    private int ResourceCount(string name)
    {
        return name switch
        {
            "Еда" => GameManager.ResourceData.Food,
            "Дерево" => GameManager.ResourceData.Wood,
            "Камень" => GameManager.ResourceData.Stone,
            "Рабочий" => GameManager.ResourceData.Worker,
            _ => 0,
        };
    }
}
