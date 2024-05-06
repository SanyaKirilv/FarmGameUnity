using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static Action<bool> ToggleLockPresentationState;
    [Header("Saved game data")]
    public SavedGameData GameData;
    [Header("Controllers")]
    [SerializeField] private SaveLoadController saveLoadController;
    [SerializeField] private HexController hexController;
    [Header("Buildings")]
    public List<Building> Buildings;
    public ResourceData ResourceData { get => GameData.Resources; set => ResourceData = value; }
    public LevelData LevelData => GameData.Level;
    private bool lockPresentationState = false;

    private void Start() => LoadGame();

    public Building GetBuildingByName(string name)
    {
        return name switch
        {
            "Дом" => Buildings[0],
            "Ферма" => Buildings[1],
            "Лесопилка" => Buildings[2],
            "Каменоломня" => Buildings[3],
            "Колодец" => Buildings[4],
            "Мельница" => Buildings[5],
            "Гильдия Войнов" => Buildings[6],
            "Гильдия Лучников" => Buildings[7],
            "Замок" => Buildings[8],
            _ => null,
        };
    }

    public Building GetBuildingByIndex(int index) => Buildings[index];

    private void LoadGame()
    {
        GameData = saveLoadController.LoadDataFromMemory();
        hexController.SetHexData(GameData.Hexes);
        LevelData.Add(0);
    }

    public void SaveGame()
    {
        GameData.Hexes = hexController.GetHexData(GameData.Hexes);
        saveLoadController.SaveDataFromMemory(GameData);
    }

    public void DropGame()
    {
        saveLoadController.ForceDeleteFile();
        SceneManager.LoadScene("GameScene");
    }

    public void ToggleLockState()
    {
        lockPresentationState = !lockPresentationState;
        ToggleLockPresentationState?.Invoke(lockPresentationState);
    }

    public void ByuGems(int count) => GameData.Gems += count;

    public void QuitApplication() => Application.Quit();

    private void OnApplicationQuit() => SaveGame();
}
