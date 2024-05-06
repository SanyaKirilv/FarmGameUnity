[System.Serializable]
public class HexData
{
    public string Name;
    public string State;
    public string Production;
    public int UnlockLevel;
    public BuildingData BuildingData;
    public int ElapsedTime;

    public void SetData(HexData data)
    {
        Name = data.Name;
        State = data.State;
        Production = data.Production;
        UnlockLevel = data.UnlockLevel;
        BuildingData = data.BuildingData;
        ElapsedTime = data.ElapsedTime;
    }
}
