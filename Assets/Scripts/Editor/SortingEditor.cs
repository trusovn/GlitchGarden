using UnityEditor;
using UnityEngine;
using System.Linq;

[CustomEditor(typeof(Sorting))]
public class SortingEditor : Editor
{
    Sorting sorting;

    private void OnEnable()
    {
        sorting = (Sorting)target;
    }

    public override void OnInspectorGUI()
    {
        GUI.changed = false;
        var layers = SortingLayer.layers.Select(x => x.name).ToArray();
        var selected = EditorGUILayout.Popup("Sorting Layer", sorting.SortingValue, layers);
        if (GUI.changed)
        {
            sorting.SetSortingLayerInChildren(layers[selected]);
        }
    }
}
