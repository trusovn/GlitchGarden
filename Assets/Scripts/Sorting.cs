using UnityEngine;

public class Sorting : MonoBehaviour
{
    int sortingValue;

    public int SortingValue { get => sortingValue; }

    public void UpdateChildrenSortingLayer(string layerName)
    {
        sortingValue = SortingLayer.GetLayerValueFromName(layerName);
        var sprites = GetComponentsInChildren<SpriteRenderer>();
        Debug.Log(layerName);
        foreach (var sr in sprites)
        {
            sr.sortingLayerName = layerName;
            Debug.Log(sr.gameObject.name);
        }
    }
}
