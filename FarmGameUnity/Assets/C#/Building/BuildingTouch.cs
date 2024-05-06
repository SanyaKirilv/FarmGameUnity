using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingTouch : MonoBehaviour, IPointerDownHandler
{
    public static Action<HexManager> OnBuildingTouched;
    public void OnPointerDown(PointerEventData eventData) => OnBuildingTouched?.Invoke(GetComponentInParent<HexManager>());
}
