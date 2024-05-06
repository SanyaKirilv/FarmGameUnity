using System;
using System.Collections;
using UnityEngine;

public class HexManager : MonoBehaviour
{
    public static Action OnHexSelected;
    [Header("Hex saved data")]
    public HexData HexData;
    public int ProductionTime => ProductionData.ProductionTime.GetTime;
    public int BuildTime => TierData.BuildTime.GetTime;

    private Hex Hex => GetComponent<Hex>();
    private GameManager GameManager => FindAnyObjectByType<GameManager>();
    private BuildingData BuildingData => HexData.BuildingData;
    private TierBuildingData TierData => GameManager.GetBuildingByName(BuildingData.Name).TierData[BuildingData.Tier - 1];
    private ProductionData ProductionData => GetProductionByName(TierData, HexData.Production);
    private LevelData LevelData => GameManager.LevelData;
    private TimeData ExitTime => GameManager.GameData.ExitTime;

    private void OnEnable() => LevelData.OnLevelUp += CheckLevelUp;
    private void OnDisable() => LevelData.OnLevelUp -= CheckLevelUp;

    private void CheckLevelUp(int level)
    {
        HexData.State = level >= HexData.UnlockLevel && HexData.State == "Locked" ? (HexData.Name != "WaterUnlocked" ? "Empty" : "Water") : HexData.State;
        if (HexData.State != "Production" || HexData.State != "Building") CheckSavedState();
    }

    public void SetBuildingData(BuildingData data)
    {
        OnHexSelected?.Invoke();
        BuildingData.SetData(data);
        Build();
    }

    public void SetProductionData(string name)
    {
        HexData.Production = name;
        Production();
    }

    public void ToggleHiglight(bool value) => Hex.ToggleHiglight(value && HexData.State == "Empty");

    public void CheckSavedState()
    {
        switch (HexData.State)
        {
            case "Locked":
                Hex.ToggleObjects(true, false, false);
                break;
            case "Water":
                Hex.ToggleObjects(false, false, false);
                break;
            case "Empty":
                Hex.ToggleObjects(false, false, false);
                break;
            case "Building":
                Hex.ToggleObjects(false, false, true);
                ResumeBuild();
                break;
            case "Available":
                Hex.ToggleObjects(false, false, false);
                Hex.InstanceBuilding(TierData.Model);
                break;
            case "Production":
                Hex.ToggleObjects(false, false, false);
                Hex.InstanceBuilding(TierData.Model);
                ResumeProduction();
                break;
            default:
                break;
        }
    }

    public void Upgrade()
    {
        HexData.BuildingData.Tier += 1;
        Hex.DecreaseBuilding();
        Build();
    }

    private void Build()
    {
        GameManager.ResourceData.Decrease(TierData.Requred);
        BuildProcess(TierData.BuildTime.GetTime);
    }

    private void ResumeBuild() => BuildProcess(HexData.ElapsedTime - ExitTime.DifferenceInSeconds);

    private void BuildProcess(int time)
    {
        HexData.State = "Building";
        Hex.ToggleObjects(false, false, true);
        _ = StartCoroutine(ProcessOne(time));
    }

    private IEnumerator ProcessOne(int seconds)
    {
        HexData.ElapsedTime = seconds;
        while (HexData.ElapsedTime > 0)
        {
            HexData.ElapsedTime--;
            yield return new WaitForSeconds(1);
        }
        Hex.InstanceBuilding(TierData.Model);
        HexData.State = "Available";
        Hex.ToggleObjects(false, false, false);
        GameManager.ResourceData.Add(TierData.Returned);
        LevelData.Add(TierData.ScoreAddiction);
    }

    private void Production()
    {
        GameManager.ResourceData.Decrease(ProductionData.Requred);
        ProductionProcess(ProductionData.ProductionTime.GetTime);
    }

    private void ResumeProduction() => ProductionProcess(HexData.ElapsedTime - ExitTime.DifferenceInSeconds);

    private void ProductionProcess(int time)
    {
        HexData.State = "Production";
        Hex.ToggleBuilding(false);
        _ = StartCoroutine(ProcessTwo(time));
    }

    private IEnumerator ProcessTwo(int seconds)
    {
        HexData.ElapsedTime = seconds;
        while (HexData.ElapsedTime > 0)
        {
            HexData.ElapsedTime--;
            yield return new WaitForSeconds(1);
        }
        HexData.State = "Available";
        GameManager.ResourceData.Add(ProductionData.Produced);
        LevelData.Add(ProductionData.ScoreAddiction);
        HexData.Production = "";
        Hex.ToggleBuilding(true);
    }

    public ProductionData GetProductionByName(TierBuildingData tierData, string name)
    {
        return name switch
        {
            "Малое" => tierData.Production[0],
            "Среднее" => tierData.Production[1],
            "Крупное" => tierData.Production[2],
            _ => null,
        };
    }
}
