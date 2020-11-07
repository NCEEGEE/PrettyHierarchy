using UnityEngine;
using UnityEditor;

namespace PrettyHierarchy
{
    [DisallowMultipleComponent]
    public class PrettyObject : MonoBehaviour
    {
        [Header("Background")]
        [SerializeField]
        private Color32 backgroundColor = new Color32(255, 255, 255, 255);
        [Header("Text")]
        [SerializeField]
        private Font font;
        [SerializeField]
        private Color32 textColor = new Color32(255, 255, 255, 255);
        [SerializeField]
        private int fontSize = 12;
        [SerializeField]
        private FontStyle fontStyle = FontStyle.Normal;
        [SerializeField]
        private TextAnchor alignment = TextAnchor.UpperLeft;
        [SerializeField]
        private bool textDropShadow;

        public Color32 BackgroundColor { get { return new Color32(backgroundColor.r, backgroundColor.g, backgroundColor.b, 255); } }
        public Font Font { get { return font; } }
        public Color32 TextColor { get { return textColor; } }
        public int FontSize { get { return fontSize; } }
        public FontStyle FontStyle { get { return fontStyle; } }
        public TextAnchor Alignment { get { return alignment; } }
        public bool TextDropShadow { get { return textDropShadow; } }

        private void OnValidate()
        {
            EditorApplication.RepaintHierarchyWindow();
        }
    }
}