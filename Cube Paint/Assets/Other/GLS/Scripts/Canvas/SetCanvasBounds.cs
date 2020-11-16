using UnityEngine;

namespace GLS
{
    /// <summary>
    /// CanvasをSafeAreaに対応させるクラス
    /// </summary>
    public class SetCanvasBounds : MonoBehaviour
    {
        private void Start()
        {
            ApplySafeArea(Screen.safeArea);
        }

        private void ApplySafeArea(Rect area)
        {
            var panel = GetComponent<RectTransform>();

            var anchorMin = area.position;
            var anchorMax = area.position + area.size;

            anchorMin.x /= Screen.width;
            anchorMin.y /= Screen.height;
            anchorMax.x /= Screen.width;
            anchorMax.y /= Screen.height;

            panel.anchorMin = anchorMin;
            panel.anchorMax = anchorMax;
        }
    }
}
