﻿// https://forum.unity.com/threads/property-drawers.595369/#post-5426619
using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

public static class UIElementsEditorHelper
{
    public static void FillDefaultInspector(VisualElement container, SerializedObject serializedObject, bool hideScript)
    {
        SerializedProperty property = serializedObject.GetIterator();
        if (property.NextVisible(true)) // Expand first child.
        {
            do
            {
                if (property.propertyPath == "m_Script" && hideScript)
                {
                    continue;
                }
                var field = new PropertyField(property);
                field.name = "PropertyField:" + property.propertyPath;


                if (property.propertyPath == "m_Script" && serializedObject.targetObject != null)
                {
                    field.SetEnabled(false);
                }

                container.Add(field);
            }
            while (property.NextVisible(false));
        }
    }
}