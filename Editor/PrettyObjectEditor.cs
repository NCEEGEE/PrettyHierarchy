using UnityEditor;
using UnityEngine;

namespace PrettyHierarchy
{
    [CustomEditor(typeof(PrettyObject))]
    public class PrettyObjectEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.LabelField("Background");

            SerializedProperty useDefaultBackgroundColor = serializedObject.FindProperty("useDefaultBackgroundColor");
            useDefaultBackgroundColor.boolValue = EditorGUILayout.Toggle("Use Default Color", useDefaultBackgroundColor.boolValue);

            if (!useDefaultBackgroundColor.boolValue)
            {
                SerializedProperty backgroundColor = serializedObject.FindProperty("backgroundColor");
                backgroundColor.colorValue = EditorGUILayout.ColorField("Background Color", backgroundColor.colorValue);
            }

            EditorGUILayout.Space(7f);

            EditorGUILayout.LabelField("Text");

            SerializedProperty useDefaultTextColor = serializedObject.FindProperty("useDefaultTextColor");
            useDefaultTextColor.boolValue = EditorGUILayout.Toggle("Use Default Color", useDefaultTextColor.boolValue);

            if (!useDefaultTextColor.boolValue)
            {
                SerializedProperty textColor = serializedObject.FindProperty("textColor");
                textColor.colorValue = EditorGUILayout.ColorField("Background Color", textColor.colorValue);
            }

            SerializedProperty font = serializedObject.FindProperty("font");
            font.objectReferenceValue = EditorGUILayout.ObjectField("Font", font.objectReferenceValue, typeof(Font), false);

            SerializedProperty fontSize = serializedObject.FindProperty("fontSize");
            EditorGUILayout.PropertyField(fontSize);

            SerializedProperty fontStyle = serializedObject.FindProperty("fontStyle");
            EditorGUILayout.PropertyField(fontStyle);

            SerializedProperty alignment = serializedObject.FindProperty("alignment");
            EditorGUILayout.PropertyField(alignment);

            SerializedProperty dropShadow = serializedObject.FindProperty("textDropShadow");
            dropShadow.boolValue = EditorGUILayout.Toggle("Drop Shadow", dropShadow.boolValue);

            serializedObject.ApplyModifiedProperties();
        }
    }
}
