using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingInfo : MonoBehaviour
{
    public string buildingName;
    public List<BuildingResources> produce;
    public List<BuildingResources> build;
    public TierEnum currentTier;

    private void Update() {
        switch (currentTier) {
            case TierEnum.firstTier:
                
                break;
            case TierEnum.secondTier:

                break;
            case TierEnum.thirdTier:

                break;
        }
    }
}
