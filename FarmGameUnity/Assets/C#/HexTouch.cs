using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class HexTouch : MonoBehaviour, IPointerDownHandler
{
    public static Action<Hex> OnHexTouched;
    public void OnPointerDown(PointerEventData eventData) => OnHexTouched?.Invoke(GetComponentInParent<Hex>());
}
