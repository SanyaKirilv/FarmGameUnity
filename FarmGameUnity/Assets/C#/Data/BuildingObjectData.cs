using UnityEngine;

[System.Serializable]
public class BuildingObjectData
{
    public string Name;
    public int Tier;
    public GameObject Model;
    public ProductionType[] Production = new ProductionType[3];
    public Time BuildTime;
}
