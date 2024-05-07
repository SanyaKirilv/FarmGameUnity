[System.Serializable]
public class BuildingData
{
    public string Name;
    public int Tier;

    public void SetData(BuildingData data)
    {
        Name = data.Name;
        Tier = data.Tier;
    }
}
