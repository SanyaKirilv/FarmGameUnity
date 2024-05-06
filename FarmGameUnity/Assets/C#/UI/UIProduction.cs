using System;
using UnityEngine;
using UnityEngine.UI;

public class UIProduction : MonoBehaviour
{
    public static Action<string> OnProductionStarted;
    [Header("Resources")]
    [SerializeField] private UIResource Requred;
    [SerializeField] private UIResource Produced;
    [Header("Other")]
    [SerializeField] private Text Type;
    [SerializeField] private Text Time;
    [SerializeField] private Button Button;

    private ProductionData CurrentProductionData;

    public void UpdateView(ProductionData productionData, bool isAvailable)
    {
        CurrentProductionData = productionData;
        TimeData time = CurrentProductionData.ProductionTime;

        Requred.UpdateView(CurrentProductionData.Requred);
        Produced.UpdateView(CurrentProductionData.Produced);

        Type.text = CurrentProductionData.Name;
        Time.text = $"{string.Format("{0:d2}", time.Hours)}:{string.Format("{0:d2}", time.Minutes)}:{string.Format("{0:d2}", time.Seconds)}";

        if (Button != null)
        {
            Button.interactable = isAvailable;
        }
    }

    public void StartProduction()
    {
        OnProductionStarted?.Invoke(CurrentProductionData.Name);
        GetComponentInParent<UIBuildingController>().HideView();
    }
}
