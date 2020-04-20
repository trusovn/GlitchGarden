using UnityEngine;

[CreateAssetMenu]
public class LevelConfiguration : ScriptableObject
{
    [SerializeField] float levelTime = default;

    public float LevelTime { get => levelTime; }
}
