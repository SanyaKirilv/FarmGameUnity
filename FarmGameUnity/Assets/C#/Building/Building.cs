using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] private BuildingData data;
    [SerializeField] private UIBuildingData uiData;
    [SerializeField] private List<TierBuildingData> tierData;

    public BuildingData Data { get => data; }
    public UIBuildingData UIData { get => uiData; }
    public List<TierBuildingData> TierData { get => tierData; }
}
