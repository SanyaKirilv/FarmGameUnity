using System;

[Serializable]
public class TimeData
{
    public int Year;
    public int Month;
    public int Day;
    public int Hours;
    public int Minutes;
    public int Seconds;

    public void SetTime(DateTime dateTime)
    {
        Year = dateTime.Year;
        Month = dateTime.Month;
        Day = dateTime.Day;
        Hours = dateTime.Hour;
        Minutes = dateTime.Minute;
        Seconds = dateTime.Second;
    }

    public DateTime GetDateTime => new(Year, Month, Day, Hours, Minutes, Seconds);

    public int GetTime => (Hours * 3600) + (Minutes * 60) + Seconds;

    public int DifferenceInSeconds => (int)DateTime.Now.Subtract(GetDateTime).TotalSeconds;
}
