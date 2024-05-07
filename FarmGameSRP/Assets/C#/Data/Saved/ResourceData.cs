using System;
using UnityEngine;

[System.Serializable]
public class ResourceData
{
    public int Food;
    public int Wood;
    public int Stone;
    public int Worker;

    public void Add(ResourceData resource)
    {
        Food += resource.Food;
        Wood += resource.Wood;
        Stone += resource.Stone;
        Worker += resource.Worker;
    }

    public void Decrease(ResourceData resource)
    {
        Food -= resource.Food;
        Wood -= resource.Wood;
        Stone -= resource.Stone;
        Worker -= resource.Worker;
    }

    public bool CheckForAvailable(ResourceData resource) =>
        Mathf.Abs(Food) >= resource.Food && Mathf.Abs(Wood) >= resource.Wood && Mathf.Abs(Stone) >= resource.Stone && Mathf.Abs(Worker) >= resource.Worker;
}
