using UnityEngine;
using UnityEngine.UI;

public class ResourceChanger : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private Text get, cost;
    [SerializeField] private Sprite iconImage;
    public ResourceData getResources;
    [SerializeField] private int costGems;
    [SerializeField] private Button ChangeButton;
    private GameManager GameManager => FindAnyObjectByType<GameManager>();

    private void Update() => ChangeButton.interactable = GameManager.GameData.Gems >= costGems;

    private void Start()
    {
        icon.sprite = iconImage;
        get.text = (getResources.Food > 0 ? getResources.Food : getResources.Wood > 0 ? getResources.Wood : getResources.Stone > 0 ? getResources.Stone : getResources.Worker > 0 ? getResources.Worker : 0).ToString();
        cost.text = costGems.ToString();
    }
    
    public void Change()
    {
        GameManager.GameData.Gems -= costGems;
        GameManager.GameData.Resources.Add(getResources);
    }
}
