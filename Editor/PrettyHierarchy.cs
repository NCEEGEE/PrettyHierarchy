using System;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace PrettyHierarchy
{
    [InitializeOnLoad]
    public static class PrettyHierarchy
    {
        static PrettyHierarchy()
        {
            EditorApplication.hierarchyWindowItemOnGUI += HandleHierarchyWindowItemOnGUI;
        }

        private static void HandleHierarchyWindowItemOnGUI(int instanceID, Rect selectionRect)
        {
            UnityEngine.Object instance = EditorUtility.InstanceIDToObject(instanceID);

            if (instance != null)
            {
                PrettyObject prettyObject = (instance as GameObject).GetComponent<PrettyObject>();

                if (prettyObject != null)
                {
                    HierarchyItem item = new HierarchyItem(instanceID, selectionRect, prettyObject);
                    PainBackground(item);
                    PaintHoverOverlay(item);
                    PaintText(item);
                    PaintCollapseToggleIcon(item);
                    PaintPrefabIcon(item);
                    PaintEditPrefabIcon(item);
                }
            }
        }

        private static void PainBackground(HierarchyItem item)
        {
            Color32 color = item.IsSelected ? EditorColors.GetDefaultBackgroundColor(EditorUtils.IsHierarchyFocused, item.IsSelected) : item.PrettyObject.BackgroundColor;
            EditorGUI.DrawRect(item.BackgroundRect, color);
        }

        private static void PaintHoverOverlay(HierarchyItem item)
        {
            if (item.IsHovered && !item.IsSelected)
            {
                EditorGUI.DrawRect(item.BackgroundRect, EditorColors.HoverOverlay);
            }
        }

        private static void PaintText(HierarchyItem item)
        {
            Color color = item.IsSelected ? EditorColors.GetDefaultTextColor(EditorUtils.IsHierarchyFocused, item.IsSelected) : item.PrettyObject.TextColor;

            GUIStyle labelGUIStyle = new GUIStyle
            {
                normal = new GUIStyleState { textColor = color },
                fontStyle = item.PrettyObject.FontStyle,
                alignment = item.PrettyObject.Alignment,
                fontSize = item.PrettyObject.FontSize,
                font = item.PrettyObject.Font
            };

            if (item.PrettyObject.TextDropShadow)
            {
                EditorGUI.DropShadowLabel(item.TextRect, item.PrettyObject.name, labelGUIStyle);
            }
            else
            {
                EditorGUI.LabelField(item.TextRect, item.PrettyObject.name, labelGUIStyle);
            }
        }

        private static void PaintCollapseToggleIcon(HierarchyItem item)
        {
            if (item.GameObject.transform.childCount > 0)
            {
                Type sceneHierarchyWindowType = typeof(Editor).Assembly.GetType("UnityEditor.SceneHierarchyWindow");
                PropertyInfo sceneHierarchyWindow = sceneHierarchyWindowType.GetProperty("lastInteractedHierarchyWindow", BindingFlags.Public | BindingFlags.Static);

                int[] expandedIDs = (int[])sceneHierarchyWindowType.GetMethod("GetExpandedIDs", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(sceneHierarchyWindow.GetValue(null), null);

                string iconID = expandedIDs.Contains(item.InstanceID) ? "IN Foldout on" : "IN foldout";

                GUI.DrawTexture(item.CollapseToggleIconRect, EditorGUIUtility.IconContent(iconID).image);
            }
        }

        private static void PaintPrefabIcon(HierarchyItem item)
        {
            GUIContent content = EditorGUIUtility.ObjectContent(EditorUtility.InstanceIDToObject(item.InstanceID), null);
            GUI.DrawTexture(item.PrefabIconRect, content.image);
        }

        private static void PaintEditPrefabIcon(HierarchyItem item)
        {
            if (PrefabUtility.GetCorrespondingObjectFromOriginalSource(item.GameObject) != null && PrefabUtility.IsAnyPrefabInstanceRoot(item.GameObject))
            {
                GUI.DrawTexture(item.EditPrefabIconRect, EditorGUIUtility.IconContent("ArrowNavigationRight").image);
            }
        }
    }
}