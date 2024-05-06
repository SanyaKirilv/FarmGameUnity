using UnityEngine;

public class AdaptiveUI : MonoBehaviour
{
    public bool Width, Height;

    private void Start() => UpdateArea();

    private void UpdateArea()
    {
        Rect safeArea = Screen.safeArea;
        RectTransform myRectTransform = transform.GetComponent<RectTransform>();

        Vector2 anchorMin = safeArea.position;
        Vector2 anchorMax = safeArea.position + safeArea.size;

        anchorMin.x = Width ? anchorMin.x /= Screen.width : 0;
        anchorMin.y = Height ? anchorMin.y /= Screen.height : 0;
        anchorMax.x = 1; //Width ? anchorMax.x /= Screen.width : 1;
        anchorMax.y = Height ? anchorMax.y /= Screen.height : 1;

        myRectTransform.anchorMin = anchorMin;
        myRectTransform.anchorMax = anchorMax;
    }
}
