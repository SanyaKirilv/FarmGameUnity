using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBuildingController : MonoBehaviour
{
    public static Action<Building> OnBuildingSelected;
    [Header("Base ui objects")]
    [SerializeField] private Text Label;
    [SerializeField] private GameObject CancelButton;
    [Header("Building views")]
    [SerializeField] private List<UIBuildingManager> buildingList;
    [SerializeField] private List<UIBuildingManager> buildingDataList;

    private int currentBuildingIndex;
    private HexManager selectedHexManager;
    private GameObject BaseView => transform.GetChild(0).gameObject;
    private GameManager GameManager => FindAnyObjectByType<GameManager>();

    private void OnEnable()
    {
        BuildingTouch.OnBuildingTouched += SetInformation;
        HexManager.OnHexSelected += HideView;
        UIProduction.OnProductionStarted += StartProduction;
    }

    private void OnDisable()
    {
        BuildingTouch.OnBuildingTouched -= SetInformation;
        HexManager.OnHexSelected -= HideView;
        UIProduction.OnProductionStarted -= StartProduction;
    }

    public void ShowView() => SetInformation(currentBuildingIndex);

    public void HideView()
    {
        BaseView.SetActive(false);
        CancelButton.SetActive(false);
        ClearScreen(buildingList);
        ClearScreen(buildingDataList);
    }

    public void ChangeBuilding(int num)
    {
        ClearScreen(buildingList);
        currentBuildingIndex = currentBuildingIndex + num > GameManager.Buildings.Count - 1 ? 0 :
            currentBuildingIndex + num < 0 ? GameManager.Buildings.Count - 1 : currentBuildingIndex += num;
        SetInformation(currentBuildingIndex);
    }

    public void BuildBuilding()
    {
        OnBuildingSelected?.Invoke(GameManager.GetBuildingByIndex(currentBuildingIndex));
        CancelButton.SetActive(true);
        BaseView.SetActive(false);
    }

    public void CancelBuilding()
    {
        OnBuildingSelected?.Invoke(null);
        HideView();
    }

    public void UpgradeBuilding()
    {
        selectedHexManager.Upgrade();
        selectedHexManager = null;
        HideView();
    }

    public void StartProduction(string production)
    {
        selectedHexManager.SetProductionData(production);
        HideView();
    }

    private void SetInformation(int index)
    {
        Label.text = "Список зданий";
        BaseView.SetActive(true);
        CancelButton.SetActive(false);

        Building building = GameManager.GetBuildingByIndex(index);
        UpdateView(buildingList, building.Data, building.TierData[0], building.TierData.Count, building.UIData);
    }

    private void SetInformation(HexManager hexManager)
    {
        Label.text = "Информация о здании";
        BaseView.SetActive(true);
        CancelButton.SetActive(false);
        selectedHexManager = hexManager;

        BuildingData data = hexManager.HexData.BuildingData;
        Building building = GameManager.GetBuildingByName(data.Name);
        UpdateView(buildingDataList, data, building.TierData[data.Tier - 1], building.TierData.Count, building.UIData);
    }

    private void UpdateView(List<UIBuildingManager> list, BuildingData data, TierBuildingData tierData, int countTiers, UIBuildingData uiData)
    {
        UIBuildingManager view = list[tierData.Production.Count > 0 ? 0 : 1];
        view.gameObject.SetActive(true);
        view.UpdateView(data, tierData, countTiers, uiData);
    }

    private void ClearScreen(List<UIBuildingManager> views)
    {
        foreach (UIBuildingManager view in views)
        {
            view.gameObject.SetActive(false);
        }
    }
}
