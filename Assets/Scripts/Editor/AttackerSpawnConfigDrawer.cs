using UnityEngine;
using UnityEditor;


[CustomPropertyDrawer(typeof(AttackerSpawnConfig))]
public class AttackerSpawnConfigDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var prefab = property.FindPropertyRelative("attackerPrefab");
        var spawnTimeWeight = property.FindPropertyRelative("spawnTimeWeight");

        EditorGUI.BeginProperty(position, label, property);
        EditorGUILayout.BeginHorizontal();
        EditorGUI.indentLevel = 0;
        var origIndent = EditorGUI.indentLevel;
        EditorGUILayout.PropertyField(prefab, GUIContent.none);
        EditorGUILayout.PropertyField(spawnTimeWeight, GUIContent.none);
        EditorGUI.indentLevel = origIndent;
        EditorGUILayout.EndHorizontal();
        EditorGUI.EndProperty();
    }
}
