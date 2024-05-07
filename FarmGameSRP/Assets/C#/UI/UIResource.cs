using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class UIResource
{
    public GameObject Food;
    public GameObject Wood;
    public GameObject Stone;
    public GameObject Worker;

    public void UpdateView(ResourceData resource)
    {
        ResourceControl(Food, resource.Food);
        ResourceControl(Wood, resource.Wood);
        ResourceControl(Stone, resource.Stone);
        ResourceControl(Worker, resource.Worker);
    }

    private void ResourceControl(GameObject resource, int count)
    {
        if (resource != null)
        {
            resource.SetActive(count > 0);
            resource.GetComponentInChildren<Text>().text = count.ToString();
        }
    }
}
