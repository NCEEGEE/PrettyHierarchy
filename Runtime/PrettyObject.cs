using UnityEngine;
using UnityEditor;

namespace PrettyHierarchy
{
    [DisallowMultipleComponent]
    public class PrettyObject : MonoBehaviour
    {
#if UNITY_EDITOR
        //[Header("Background")]
        [SerializeField]
        private bool useDefaultBackgroundColor;
        [SerializeField]
        private Color32 backgroundColor = new Color32(255, 255, 255, 255);
        //[Header("Text")]
        [SerializeField]
        private bool useDefaultTextColor;
        [SerializeField]
        private Color32 textColor = new Color32(255, 255, 255, 255);
        [SerializeField]
        private Font font;
        [SerializeField]
        private int fontSize = 12;
        [SerializeField]
        private FontStyle fontStyle = FontStyle.Normal;
        [SerializeField]
        private TextAnchor alignment = TextAnchor.UpperLeft;
        [SerializeField]
        private bool textDropShadow;

        public bool UseDefaultBackgroundColor { get { return useDefaultBackgroundColor; } }
        public Color32 BackgroundColor { get { return new Color32(backgroundColor.r, backgroundColor.g, backgroundColor.b, 255); } }

        public bool UseDefaultTextColor { get { return useDefaultTextColor; } }
        public Color32 TextColor { get { return textColor; } }
        public Font Font { get { return font; } }
        public int FontSize { get { return fontSize; } }
        public FontStyle FontStyle { get { return fontStyle; } }
        public TextAnchor Alignment { get { return alignment; } }
        public bool TextDropShadow { get { return textDropShadow; } }

        private void OnValidate()
        {
            EditorApplication.RepaintHierarchyWindow();
        }
#endif
    }
}