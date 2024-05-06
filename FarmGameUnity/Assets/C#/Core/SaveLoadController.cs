using System;
using System.IO;
using UnityEngine;

public class SaveLoadController : MonoBehaviour
{
    [Header("Initial data json")]
    public TextAsset InitialData;
    private string DataFilePath => Path.Combine(Application.persistentDataPath, DataFileName);
    private string DataFileName => $"_data.json";

    public void SaveDataFromMemory(SavedGameData gameData)
    {
        gameData.ExitTime.SetTime(DateTime.Now);
        File.WriteAllText(DataFilePath, JsonUtility.ToJson(gameData));
    }

    public SavedGameData LoadDataFromMemory()
    {
        return CheckForExists ?
            JsonUtility.FromJson<SavedGameData>(File.ReadAllText(DataFilePath)) :
            JsonUtility.FromJson<SavedGameData>(InitialData.text);
    }

    public void ForceDeleteFile() => File.Delete(DataFilePath);

    private bool CheckForExists => File.Exists(DataFilePath);
}
