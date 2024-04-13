using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexController : MonoBehaviour
{
    public GameDataController GameDataController => GetComponent<GameDataController>();
    public List<Hex> Hexes;
    public List<BuildingObjectData> TierOne;
    public List<BuildingObjectData> TierTwo;
    public List<BuildingObjectData> TierThree;
    private BuildingObjectData SelectedBuildingObjectData;

    private void Start()
    {
        GameDataController.LoadData();
        for(int i = 0; i < Hexes.Count; i++)
        {
            Hexes[i].Initialize(GameDataController.GameData.HexData[i]);
        }
        
        //SwitchHexs(0);
    }

    public void ConstructById(int id)
    {
        ShowAvaliableHexes();
        SelectedBuildingObjectData = TierOne[id];
    }

    public void ShowAvaliableHexes()
    {
        foreach(var hex in Hexes)
        {
            hex.ToggleHiglightObject(true);
        }
    }

    public void SwitchHexs(int currentLevel)
    {
        foreach(var hex in Hexes)
        {
            if(hex.HexData.UnlockLevel == currentLevel)
                hex.HexData.State = "Empty";
            hex.SwitchBlockState();
        }
    }

    private void OnHexSelected(Hex selectedHex)
    {
        foreach(var hex in Hexes)
        {
            hex.ToggleHiglightObject(false);
        }
        selectedHex.Build(SelectedBuildingObjectData);
        SelectedBuildingObjectData = null;
    }

    private void OnBuildingTouched(Hex selectedHex)
    {
        switch(selectedHex.HexData.BuildingData.Tier)
        {
            case 1:
                selectedHex.Upgrade(TierTwo[0]);
                break;
            case 2:
                selectedHex.Upgrade(TierThree[0]);
                break;
        }
    }

    private void OnEnable()
    {
        HexTouch.OnHexTouched += OnHexSelected;
        BuildingTouch.OnBuildingTouched += OnBuildingTouched;
    }

    private void OnDisable()
    {
        HexTouch.OnHexTouched -= OnHexSelected;
        BuildingTouch.OnBuildingTouched -= OnBuildingTouched;
    }

    private void OnApplicationQuit() {
        for(int i = 0; i < Hexes.Count; i++)
        {
            GameDataController.GameData.HexData[i] = Hexes[i].HexData;
        }
        GameDataController.SaveData();
    }
}
