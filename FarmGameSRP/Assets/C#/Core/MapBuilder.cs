using UnityEngine;

public class MapBuilder : MonoBehaviour
{
    public GameObject Tile;
    public int width;
    public int height;
    public Transform parent;

    private void Awake()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                float xOffset = (x * 1f) - (x * .25f);
                float yOffset = (y * 0.8660254f) + (!(x % 2 == 0) ? 0 : 0.8660254f / 2);
                Vector3 position = new(xOffset, 0, yOffset);
                GameObject obj = Instantiate(Tile);
                obj.transform.position = position;
                obj.name = $"{x}, {y}";
                //obj.GetComponent<HexManager>().HexData.Name = obj.name;
                obj.transform.parent = parent;
            }
        }
    }

}
