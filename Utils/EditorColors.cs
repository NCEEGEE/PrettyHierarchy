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
        private static Color32 darkObjectSelectedText = new Color32(210, 210, 210, 255);
        private static Color32 darkObjectSelectedWindowFocusedText = new Color32(255, 255, 255, 255);

        // LIGHT THEME - Background
        private static Color32 lightBackground = new Color32(194, 194, 194, 255);
        private static Color32 lightObjectSelectedBackground = new Color32(174, 174, 174, 255);
        private static Color32 lightObjectSelectedWindowFocusedBackground = new Color32(58, 114, 176, 255);
        private static Color32 lightHoverOverlay = new Color32(0, 0, 0, 21);
        // LIGHT THEME - Text
        private static Color32 lightText = new Color32(0, 0, 0, 255);
        private static Color32 lightObjectSelectedText = new Color32(2, 2, 2, 255);
        private static Color32 lightObjectSelectedWindowFocusedText = new Color32(255, 255, 255, 255);


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
        /// Returns the text color for a hierarchy object that is not selected
        /// </summary>
        public static Color32 Text { get { return EditorGUIUtility.isProSkin ? darkText : lightText; } }
        /// <summary>
        /// Returns the text color for a hierarchy object that is selected while the hierarchy window is NOT the focus.
        /// </summary>
        public static Color32 ObjectSelectedText { get { return EditorGUIUtility.isProSkin ? darkObjectSelectedText : lightObjectSelectedText; } }
        /// <summary>
        /// Returns the text color for a hierarchy object that is selected while the hierarchy window is the focus.
        /// </summary>
        public static Color32 ObjectSelectedWindowFocusedText { get { return EditorGUIUtility.isProSkin ? darkObjectSelectedWindowFocusedText : lightObjectSelectedWindowFocusedText; } }


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
        public static Color32 GetDefaultTextColor(bool windowIsFocused, bool selectionContainsObject)
        {
            return selectionContainsObject ? windowIsFocused ? ObjectSelectedWindowFocusedText : ObjectSelectedText : Text;
        }
    }
}