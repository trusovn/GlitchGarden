using UnityEngine;

[System.Serializable]
public class AttackerSpawnConfig
{
    [Tooltip("Attacker prefab")]
    [SerializeField] GameObject attackerPrefab;
    [Tooltip("Relative to other attackers, proportion of how many of these and when they will be spawned on level's timeline.")]
    [SerializeField] AnimationCurve spawnTimeWeight;
}
