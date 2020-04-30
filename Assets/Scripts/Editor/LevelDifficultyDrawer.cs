using UnityEngine;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

[CustomPropertyDrawer(typeof(LevelDifficulty))]
public class LevelDifficultyDrawer : PropertyDrawer
{
    public override VisualElement CreatePropertyGUI(SerializedProperty property)
    {
        var container = new VisualElement();
        container.Add(new Label("Difficulty " + property.propertyPath));
        container.Add(new Label("Difficulty " + property.type));
        container.Add(new Label("Difficulty " + ((LevelConfiguration)property.serializedObject.targetObject).levelDifficulties.Length));
        //container.Add(new PropertyField())        
        container.Add(new PropertyField(property.FindPropertyRelative("startStarsCount")));
        var attackers = property.FindPropertyRelative("levelAttackers");
        container.Add(new Label("Attackers size: " + attackers.arraySize.ToString()));
        var header = new VisualElement();
        header.style.display = DisplayStyle.Flex;
        header.style.flexDirection = FlexDirection.Row;
        header.style.justifyContent = Justify.SpaceAround;
        header.Add(new Label("Attacker"));
        header.Add(new Label("Spawn Time and Weight"));
        container.Add(header);
        for (int i = 0; i < attackers.arraySize; i++)
        {
            container.Add(new PropertyField(attackers.GetArrayElementAtIndex(i)));
        }
        return container;
    }
}