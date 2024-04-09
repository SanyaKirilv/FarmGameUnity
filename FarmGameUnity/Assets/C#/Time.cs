[System.Serializable]
public class Time
{
    public int Hours;
    public int Minutes;
    public int Seconds;
    public int FullTime => Hours * 60 + Minutes * 60 + Seconds;
}
