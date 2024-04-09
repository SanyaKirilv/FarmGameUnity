using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBuilder : MonoBehaviour
{
    public GameObject Tile;
    public int width;
    public int height;
    public Transform parent;

    void Awake()
    {
        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < width; y++)
            {
                var xOffset = x * 1f - x * .25f;
                var yOffset = y * 0.8660254f + (!(x % 2 == 0) ? 0 : 0.8660254f/2);
                var position = new Vector3(xOffset, 0, yOffset);
                var obj = Instantiate(Tile);
                obj.transform.position = position;
                obj.name = $"{x}, {y}";
                obj.GetComponent<Hex>().HexData.Name = obj.name;
                obj.GetComponent<Hex>().HexData.State = "Empty";
                obj.transform.parent = parent;
                parent.GetComponent<HexController>().Hexes.Add(obj.GetComponent<Hex>());
            }
        }
    }

}
