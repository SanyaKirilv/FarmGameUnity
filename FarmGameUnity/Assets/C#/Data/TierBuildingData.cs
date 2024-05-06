using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TierBuildingData
{
    public int Tier;
    public GameObject Model;
    public List<ProductionData> Production;
    public ResourceData Requred;
    public ResourceData Returned;
    public TimeData BuildTime;
    public int ScoreAddiction;
}
