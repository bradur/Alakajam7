// Date   : 21.09.2019 16.57
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomPropertyDrawer(typeof(Enemy))]
public class EnemyEditor : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 1;


        // Calculate rects
        var typeRect = new Rect(position.x, position.y, 120, position.height);
        var spawnRect = new Rect(position.x + 125, position.y, 150, position.height);

        // Draw fields - passs GUIContent.none to each so they are drawn without labels
        EditorGUI.PropertyField(typeRect, property.FindPropertyRelative("type"), GUIContent.none);
        EditorGUI.indentLevel = 0;
        EditorGUI.PropertyField(spawnRect, property.FindPropertyRelative("spawn"), GUIContent.none);

        EditorGUI.indentLevel = indent;
        EditorGUI.EndProperty();
    }
}

[CustomPropertyDrawer(typeof(EnemyPrefabMapping))]
public class EnemyPrefabMappingEditor : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;


        // Calculate rects
        var typeRect = new Rect(position.x, position.y, 100, position.height);
        var spawnRect = new Rect(position.x + 105, position.y, 150, position.height);

        // Draw fields - passs GUIContent.none to each so they are drawn without labels
        EditorGUI.PropertyField(typeRect, property.FindPropertyRelative("type"), GUIContent.none);
        EditorGUI.indentLevel = 0;
        EditorGUI.PropertyField(spawnRect, property.FindPropertyRelative("prefab"), GUIContent.none);

        EditorGUI.indentLevel = indent;
        EditorGUI.EndProperty();
    }
}