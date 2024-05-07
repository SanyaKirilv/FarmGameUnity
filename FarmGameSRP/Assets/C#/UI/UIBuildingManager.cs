using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBuildingManager : MonoBehaviour
{
    [Header("Main information ui elements")]
    public Image Icon;
    public Text Name;
    public Text Description;

    [Header("Build/Upgrade resources ui elements")]
    public UIResource RequredResources;
    public Text Time;
    public Button Button;
    public GameObject BuildUpgrade;
    [Header("Production ui elements")]
    public List<UIProduction> ProductionList;

   private ResourceData ResourceData => FindAnyObjectByType<GameManager>().ResourceData;

    public void UpdateView(BuildingData data, TierBuildingData tierData, int countTiers, UIBuildingData uiData)
    {
        UpdateMainInformation(uiData, data.Tier);
        UpdateBUResources(tierData, data.Tier, countTiers);
        UpdateProductioList(tierData.Production);
    }

    private void UpdateMainInformation(UIBuildingData uiData, int tier)
    {
        Icon.sprite = uiData.Icon;
        Name.text = uiData.Name + " " + tier + "УР";
        Description.text = uiData.Description;
    }

    private void UpdateBUResources(TierBuildingData tierData, int tier, int countTiers)
    {
        if (BuildUpgrade != null) BuildUpgrade.SetActive(tier != countTiers);
        RequredResources.UpdateView(tierData.Requred);
        Button.interactable = ResourceData.CheckForAvailable(tierData.Requred);
        Time.text = $"{string.Format("{0:d2}", tierData.BuildTime.Hours)}:{string.Format("{0:d2}", tierData.BuildTime.Minutes)}:{string.Format("{0:d2}", tierData.BuildTime.Seconds)}";
    }

    private void UpdateProductioList(List<ProductionData> productionDataList)
    {
        if (productionDataList.Count != 0)
        {
            for (int i = 0; i < productionDataList.Count; i++)
            {
                ProductionList[i].UpdateView(productionDataList[i], ResourceData.CheckForAvailable(productionDataList[i].Requred));
            }
        }
    }
}
