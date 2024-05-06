[System.Serializable]
public class ProductionData
{
    public string Name;
    public ResourceData Requred;
    public ResourceData Produced;
    public TimeData ProductionTime;
    public int ScoreAddiction;

    public void SetData(ProductionData data)
    {
        Name = data.Name;
        Requred = data.Requred;
        Produced = data.Produced;
        ProductionTime = data.ProductionTime;
        ScoreAddiction = data.ScoreAddiction;
    }
}
