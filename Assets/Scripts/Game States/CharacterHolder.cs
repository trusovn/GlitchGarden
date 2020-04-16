using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterHolder : ScriptableObject
{
    private List<GameObject> characters = new List<GameObject>();

    public virtual void Add(GameObject character)
    {
        characters.Add(character);
    }

    public virtual void Die(GameObject character)
    {
        Remove(character);
    }

    public virtual void Remove(GameObject character)
    {
        characters.Remove(character);
    }
}
