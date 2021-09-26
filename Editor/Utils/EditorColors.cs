using UnityEditor;
using UnityEngine;

namespace PrettyHierarchy
{
    public static class EditorColors
    {
        // DARK THEME - Background
        private static Color32 darkBackground = new Color32(56, 56, 56, 255);
        private static Color32 darkObjectSelectedBackground = new Color32(77, 77, 77, 255);
        private static Color32 darkObjectSelectedWindowFocusedBackground = new Color32(44, 93, 134, 255);
        private static Color32 darkOverOverlay = new Color32(255, 255, 255, 15);
        // DARK THEME - Text
        private static Color32 darkText = new Color32(210, 210, 210, 255);
        private static Color32 darkTextHighlighted = new Color32(255, 255, 255, 255);
        private static byte darkTextAlphaObjectEnabled = 255;
        private static byte darkTextAlphaObjectDisabled = 103;

        // LIGHT THEME - Background
        private static Color32 lightBackground = new Color32(200, 200, 200, 255);
        private static Color32 lightObjectSelectedBackground = new Color32(178, 178, 178, 255);
        private static Color32 lightObjectSelectedWindowFocusedBackground = new Color32(58, 114, 176, 255);
        private static Color32 lightHoverOverlay = new Color32(0, 0, 0, 21);
        // LIGHT THEME - Text
        private static Color32 lightText = new Color32(2, 2, 2, 255);
        private static Color32 lightTextHighlighted = new Color32(255, 255, 255, 255);
        private static byte lightTextAlphaObjectEnabled = 255;
        private static byte lightTextAlphaObjectDisabled = 95;

        /// <summary>
        /// Returns the background color for a hierarchy object that is not selected.
        /// </summary>
        public static Color32 Background { get { return EditorGUIUtility.isProSkin ? darkBackground : lightBackground; } }
        /// <summary>
        /// Returns the background color for a hierarchy object that is selected while the hierarchy window is NOT the focus.
        /// </summary>
        public static Color32 ObjectSelectedBackground { get { return EditorGUIUtility.isProSkin ? darkObjectSelectedBackground : lightObjectSelectedBackground; } }
        /// <summary>
        /// Returns the text color for a hierarchy object that is selected while the hierarchy window is the focus.
        /// </summary>
        public static Color32 ObjectSelectedWindowFocusedBackground { get { return EditorGUIUtility.isProSkin ? darkObjectSelectedWindowFocusedBackground : lightObjectSelectedWindowFocusedBackground; } }
        /// <summary>
        /// Returns the background overlay color when the object is hovered in the hierarchy. This should be drawn on top of the background color.
        /// </summary>
        public static Color32 HoverOverlay { get { return EditorGUIUtility.isProSkin ? darkOverOverlay : lightHoverOverlay; } }


        /// <summary>
        /// Returns the default text color
        /// </summary>
        public static Color32 Text { get { return EditorGUIUtility.isProSkin ? darkText : lightText; } }
        /// <summary>
        /// Returns the highlighted text color. Highlight happens when those 3 conditions are true: Object is selected / Object is active / Window is focused
        /// </summary>
        public static Color32 TextHighlighted { get { return EditorGUIUtility.isProSkin ? darkTextHighlighted : lightTextHighlighted; } }
        /// <summary>
        /// Returns the alpha of the text for a GameObject enabled in the hierarchy. This alpha should be applied to the final color.
        /// </summary>
        public static byte TextAlphaObjectEnabled { get { return EditorGUIUtility.isProSkin ? darkTextAlphaObjectEnabled : lightTextAlphaObjectEnabled; } }
        /// <summary>
        /// Returns the alpha of the text for a GameObject disabled in the hierarchy. This alpha should be applied to the final color.
        /// </summary>
        public static byte TextAlphaObjectDisabled { get { return EditorGUIUtility.isProSkin ? darkTextAlphaObjectDisabled : lightTextAlphaObjectDisabled; } }

        /// <summary>
        /// Returns the tint color of the "collapse" icon texture.
        /// </summary>
        public static Color CollapseIconTintColor { get { return EditorGUIUtility.isProSkin ? Color.white : Color.black; } }
        /// <summary>
        /// Returns the tint color of the "edit prefab" icon texture.
        /// </summary>
        public static Color EditPrefabIconTintColor { get { return EditorGUIUtility.isProSkin ? Color.white : Color.black; } }

        /// <summary>
        /// Returns the correct hierarchy background color depending on the context.
        /// </summary>
        public static Color32 GetDefaultBackgroundColor(bool windowIsFocused, bool selectionContainsObject)
        {
            return selectionContainsObject ? windowIsFocused ? ObjectSelectedWindowFocusedBackground : ObjectSelectedBackground : Background;
        }

        /// <summary>
        /// Returns the correct hierarchy text color depending on the context.
        /// </summary>
        public static Color32 GetDefaultTextColor(bool windowIsFocused, bool selectionContainsObject, bool objectIsEnabled)
        {
            bool textHighlighted = IsTextHighlighted(windowIsFocused, selectionContainsObject, objectIsEnabled);
            Color32 color = textHighlighted ? TextHighlighted : Text;
            color.a = objectIsEnabled ? TextAlphaObjectEnabled : TextAlphaObjectDisabled;
            return color;
        }

        /// <summary>
        /// Returns whether or not the text should be displayed as highlighted.
        /// </summary>
        public static bool IsTextHighlighted(bool windowIsFocused, bool selectionContainsObject, bool objectIsEnabled)
        {
            return windowIsFocused && selectionContainsObject && objectIsEnabled;
        }
    }
}