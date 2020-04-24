using UnityEngine;

[System.Serializable]
public class AttackerSpawnConfig
{
    [Tooltip("Attacker prefab")]
    [SerializeField] GameObject attackerPrefab;
    [Tooltip("First time spawn. 0 - beginning, 1 - end.")]
    [SerializeField] [Range(0, 1)] float spawnFirstTime;
    [Tooltip("Relative to other attackers, proportion of how many of these will be spawned once the process starts.")]
    [SerializeField] int weight;
}
