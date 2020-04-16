using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterHolder : ScriptableObject
{
    private List<GameObject> characters = new List<GameObject>();

    public virtual void Add(GameObject trophy)
    {
        characters.Add(trophy);
    }

    public virtual void Die(GameObject trophy)
    {
        Remove(trophy);
    }

    public virtual void Remove(GameObject trophy)
    {
        characters.Remove(trophy);
    }
}
