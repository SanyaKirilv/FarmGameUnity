using UnityEngine;
using UnityEngine.UI;

public class StateTimerUI : MonoBehaviour
{
    [SerializeField] private GameObject messageUI;
    [SerializeField] private Image durationUI;

    private HexManager HexManager => GetComponentInParent<HexManager>();
    private HexData HexData => HexManager.HexData;

    private void Start() => UpdateLockView(false);

    private void Update() => UpdateView();

    private void OnEnable() => GameManager.ToggleLockPresentationState += UpdateLockView;
    private void OnDisable() => GameManager.ToggleLockPresentationState -= UpdateLockView;

    private void UpdateView()
    {
        var hexManager = GetComponentInParent<HexManager>();
        var hexData = hexManager.HexData;
        switch (hexData.State)
        {
            case "Empty":
                durationUI.fillAmount = 0;
                UpdateMessage(false, $"");
                break;
            case "Building":
                durationUI.fillAmount = 1 - (float)hexData.ElapsedTime / (float)hexManager.BuildTime;
                UpdateMessage(true, $"Строится:\n{hexData.BuildingData.Name} {hexData.BuildingData.Tier}УР\nОсталось:\n{hexData.ElapsedTime}s");
                break;
            case "Available":
                durationUI.fillAmount = 0;
                UpdateMessage(false, $"");
                break;
            case "Production":
                durationUI.fillAmount = 1 - (float)hexData.ElapsedTime / (float)hexManager.ProductionTime;
                UpdateMessage(true, $"Производство:\n{hexData.Production}\nОсталось:\n{hexData.ElapsedTime}s");
                break;
            default:
                break;
        }
    }

    private void UpdateLockView(bool value)
    {
        durationUI.fillAmount = 1;
        UpdateMessage(value, $"{HexData.UnlockLevel}\nlvl");
    }

    private void UpdateMessage(bool state, string message)
    {
        messageUI.SetActive(state);
        messageUI.GetComponentInChildren<Text>().text = message;
    }
}
