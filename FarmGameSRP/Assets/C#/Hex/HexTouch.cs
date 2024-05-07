using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class HexTouch : MonoBehaviour, IPointerDownHandler
{
    public static Action<HexManager> OnHexSelected;
    public void OnPointerDown(PointerEventData eventData) => OnHexSelected?.Invoke(GetComponentInParent<HexManager>());
}
