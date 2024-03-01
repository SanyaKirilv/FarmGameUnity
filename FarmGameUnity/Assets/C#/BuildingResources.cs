using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BuildingResources
{
    [Header("Tier of building")]
    public TierEnum tier;
    [Header("IO resources")]
    public List<ResourcesEnum> inputResources;
    public List<ResourcesEnum> outputResources;
    [Header("Time to do something in seconds")]
    public float requrementTime;
}
