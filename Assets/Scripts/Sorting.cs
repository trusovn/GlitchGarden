using UnityEngine;

public class Sorting : MonoBehaviour
{
    int sortingValue;

    public int SortingValue { get => sortingValue; }

    public void SetSortingLayerInChildren(string layerName)
    {
        sortingValue = SortingLayer.GetLayerValueFromName(layerName);
        var sprites = GetComponentsInChildren<SpriteRenderer>();
        foreach (var sr in sprites)
        {
            sr.sortingLayerName = layerName;
        }
    }
}
