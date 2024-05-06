using System.Collections.Generic;

[System.Serializable]
public class SavedGameData
{
    public ResourceData Resources;
    public LevelData Level;
    public int Gems;
    public TimeData ExitTime;
    public List<HexData> Hexes;
}
