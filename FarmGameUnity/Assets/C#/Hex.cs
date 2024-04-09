using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hex : MonoBehaviour
{
    [Header("Hex saved data")]
    public HexData HexData;
    [Header("Hex 3D objects")]
    [SerializeField] private GameObject BlockObject;
    [SerializeField] private GameObject HighlightObject;
    [SerializeField] private GameObject ConstructionZone;
    [Header("Building data")]
    [SerializeField] private BuildingObjectData BuildingObjectData;
    [SerializeField] private GameObject BuildingObject;

    public void Initialize(HexData HexData)
    {
        this.HexData = HexData;
        SwitchBlockState();
        BuildingObjectData.Name = HexData.BuildingData.Name;
        BuildingObjectData.Tier = HexData.BuildingData.Tier;
        BuildingObjectData = GetBuildingObjectData(HexData.BuildingData);
        switch (HexData.State)
        {
            case "Locked":
                break;
            case "Empty":
                break;
            case "Building":
                StartCoroutine(Construct(HexData.BuildingData.ElapsedTime));
                break;
            case "Occupied":
                InstantiateBuilding();
                break;
        }
    }

    public void Build(BuildingObjectData buildingObjectData)
    {
        HexData.BuildingData.Name = buildingObjectData.Name;
        HexData.BuildingData.Tier = buildingObjectData.Tier;
        BuildingObjectData = buildingObjectData;
        LaunchProcess();
    }

    public void Upgrade(BuildingObjectData buildingObjectData)
    {
        BuildingObjectData = buildingObjectData;
        HexData.BuildingData.Tier = buildingObjectData.Tier;
        LaunchProcess();
    }

    public void SwitchBlockState() => BlockObject.SetActive(HexData.State == "Locked");

    private void LaunchProcess()
    {
        HexData.State = "Building";
        HexData.BuildingData.State = "Building";
        StartCoroutine(Construct(BuildingObjectData.BuildTime.FullTime));
    }

    public void ToggleHiglightObject(bool state) => HighlightObject.SetActive(HexData.State == "Empty" && state);

    private IEnumerator Construct(int time)
    {
        ConstructionZone.SetActive(true);
        HexData.BuildingData.ElapsedTime = time;
        while(HexData.BuildingData.ElapsedTime != 0)
        {
            HexData.BuildingData.ElapsedTime--;
            yield return new WaitForSeconds(1);
        }
        InstantiateBuilding();
        HexData.State = "Occupied";
        HexData.BuildingData.State = "Available";
        ConstructionZone.SetActive(false);
    }

    private void InstantiateBuilding()
    {
        if(BuildingObject != null)
            Destroy(BuildingObject.gameObject);

        BuildingObject = Instantiate(BuildingObjectData.Model,
                new Vector3(0, 0, 0), Quaternion.identity, this.transform);
        BuildingObject.transform.localPosition = new Vector3(.5f, 0, .5f);
    }

    public BuildingObjectData GetBuildingObjectData(BuildingData BuildingData)
    {
        switch (BuildingData.Tier)
        {
            case 1:
                return GetComponentInParent<HexController>().TierOne[0];
            case 2:
                return GetComponentInParent<HexController>().TierTwo[0];
            case 3:
                return GetComponentInParent<HexController>().TierThree[0];
        }
        return null;
    }
}
