using System.Collections.Generic;
using UnityEngine;

public class HexController : MonoBehaviour
{
    [Header("Map of hex")]
    [SerializeField] private List<HexManager> hexMap;

    private Building selectedBuilding;

    private void OnEnable()
    {
        UIBuildingController.OnBuildingSelected += SetBuilding;
        HexTouch.OnHexSelected += SetBuildingToHex;
    }

    private void OnDisable()
    {
        UIBuildingController.OnBuildingSelected -= SetBuilding;
        HexTouch.OnHexSelected -= SetBuildingToHex;
    }

    public void SetHexData(List<HexData> hexData)
    {
        AppendHexMap();
        for (int i = 0; i < hexMap.Count; i++)
        {
            hexMap[i].HexData.SetData(hexData[i]);
            hexMap[i].CheckSavedState();
        }
    }

    public List<HexData> GetHexData(List<HexData> hexData)
    {
        for (int i = 0; i < hexMap.Count; i++)
            hexData[i].SetData(hexMap[i].HexData);
        return hexData;
    }

    public void CancelBuilding()
    {
        selectedBuilding = null;
        ToggleAvailableHex(false);
    }

    private void SetBuilding(Building building)
    {
        selectedBuilding = building;
        ToggleAvailableHex(building != null);
    }

    private void SetBuildingToHex(HexManager hex)
    {
        if (selectedBuilding != null)
            hex.SetBuildingData(selectedBuilding.Data);
        CancelBuilding();
    }

    private void ToggleAvailableHex(bool state)
    {
        foreach (HexManager hex in hexMap)
            hex.ToggleHiglight(state);
    }

    private void AppendHexMap() => hexMap = new List<HexManager>(GetComponentsInChildren<HexManager>());
}
