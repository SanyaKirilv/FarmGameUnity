using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildQuest : Quest
{
    [SerializeField] private string buildingName;
    [SerializeField] private int count;
    private HexController HexController => FindAnyObjectByType<HexController>();

    public override void UpdateProgress()
    {
        base.UpdateProgress();
        var _count = HexController.CountByName(buildingName);
        taskText.text = $"Постоить {count} здания типа [{buildingName}]";
        progressText.text = $"{_count}/{count}";
        button.interactable = _count >= count;
    }
}
