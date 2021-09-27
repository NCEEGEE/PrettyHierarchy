using UnityEditor;
using UnityEngine;

namespace PrettyHierarchy
{
    [CustomEditor(typeof(PrettyObject)), CanEditMultipleObjects]
    public class PrettyObjectEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.LabelField("Background");

            SerializedProperty useDefaultBackgroundColor = serializedObject.FindProperty("useDefaultBackgroundColor");
            EditorGUILayout.PropertyField(useDefaultBackgroundColor, new GUIContent("Use Default Color"));

            if (!useDefaultBackgroundColor.boolValue)
            {
                SerializedProperty backgroundColor = serializedObject.FindProperty("backgroundColor");
                EditorGUILayout.PropertyField(backgroundColor);
            }

            EditorGUILayout.Space(7f);

            EditorGUILayout.LabelField("Text");

            SerializedProperty useDefaultTextColor = serializedObject.FindProperty("useDefaultTextColor");
            EditorGUILayout.PropertyField(useDefaultTextColor, new GUIContent("Use Default Color"));

            if (!useDefaultTextColor.boolValue)
            {
                SerializedProperty textColor = serializedObject.FindProperty("textColor");
                EditorGUILayout.PropertyField(textColor);
            }

            SerializedProperty font = serializedObject.FindProperty("font");
            EditorGUILayout.PropertyField(font);

            SerializedProperty fontSize = serializedObject.FindProperty("fontSize");
            EditorGUILayout.PropertyField(fontSize);

            SerializedProperty fontStyle = serializedObject.FindProperty("fontStyle");
            EditorGUILayout.PropertyField(fontStyle);

            SerializedProperty alignment = serializedObject.FindProperty("alignment");
            EditorGUILayout.PropertyField(alignment);

            SerializedProperty dropShadow = serializedObject.FindProperty("textDropShadow");
            EditorGUILayout.PropertyField(dropShadow);

            serializedObject.ApplyModifiedProperties();
        }
    }
}
