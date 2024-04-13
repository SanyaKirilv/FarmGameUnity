using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameDataController Controller;
    public ResourceUI resourceUI;

    public List<Resource> resource;
    public List<Button> buttons;

    void Update()
    {
        resourceUI.Food.text = Controller.GameData.Resource.Food.ToString();
        resourceUI.Wood.text = Controller.GameData.Resource.Wood.ToString();
        resourceUI.Stone.text = Controller.GameData.Resource.Stone.ToString();
        resourceUI.Worker.text = Controller.GameData.Resource.Worker.ToString();

        for(int i = 0; i < buttons.Count; i++)
        {
            buttons[i].interactable = Controller.GameData.Resource.Food > resource[i].Food &&
                Controller.GameData.Resource.Wood > resource[i].Wood && 
                Controller.GameData.Resource.Stone > resource[i].Stone &&
                Controller.GameData.Resource.Worker > resource[i].Worker;
        }
    }

    public void Build(int index)
    {
        Controller.GameData.Resource.Food -= resource[index].Food;
        Controller.GameData.Resource.Wood -= resource[index].Wood;
        Controller.GameData.Resource.Stone -= resource[index].Stone;
        Controller.GameData.Resource.Worker -= resource[index].Worker;
    }
}
