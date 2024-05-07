using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest : MonoBehaviour
{
    public static Action<(string, int)> OnQuestCompleted;
    public string Code;
    [SerializeField] private int pointsGained;
    [Header("Quest ui components")]
    public Text taskText;
    public Text progressText;
    public Button button;

    public void ToggleQuest(bool state) => this.gameObject.SetActive(state);
    public void ConfirmQuest() => OnQuestCompleted?.Invoke((Code, pointsGained));

    public virtual void UpdateProgress() { }
}
