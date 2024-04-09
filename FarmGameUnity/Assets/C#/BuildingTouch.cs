using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingTouch : MonoBehaviour, IPointerDownHandler
{
    public static Action<Hex> OnBuildingTouched;
    public void OnPointerDown(PointerEventData eventData) => OnBuildingTouched?.Invoke(GetComponentInParent<Hex>());
}
