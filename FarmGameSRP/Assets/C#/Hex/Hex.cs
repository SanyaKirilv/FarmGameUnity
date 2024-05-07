using UnityEngine;

public class Hex : MonoBehaviour
{
    [Header("Hex objects")]
    [SerializeField] private GameObject block;
    [SerializeField] private GameObject highlight;
    [SerializeField] private GameObject construct;
    [Header("Hex 3D building model")]
    [SerializeField] private GameObject building;

    public void ToggleObjects(bool block, bool highlight, bool construct)
    {
        ToggleBlock(block);
        ToggleHiglight(highlight);
        ToggleConstruct(construct);
    }

    public void ToggleBlock(bool state) => block.SetActive(state);
    public void ToggleHiglight(bool state) => highlight.SetActive(state);
    public void ToggleConstruct(bool state) => construct.SetActive(state);
    public void ToggleBuilding(bool state) => building.GetComponent<BuildingTouch>().enabled = state;

    public void InstanceBuilding(GameObject _building)
    {
        DecreaseBuilding();

        building = Instantiate(_building, new Vector3(0, 30, 0), Quaternion.identity, transform);
        building.transform.localPosition = new Vector3(.5f, 0.4375f, .5f);
    }

    public void DecreaseBuilding() 
    {
        if (building != null)
        {
            Destroy(building);
        }
    }
}
