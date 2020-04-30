using UnityEditor;
using UnityEngine.UIElements;

[CustomEditor(typeof(LevelConfiguration))]
public class LevelConfigurationEditor : Editor
{
    public override VisualElement CreateInspectorGUI()
    {
        var container = new VisualElement();
        UIElementsEditorHelper.FillDefaultInspector(container, serializedObject, false);
        return container;
    }
}