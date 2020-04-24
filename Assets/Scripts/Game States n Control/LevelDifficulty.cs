using UnityEngine;

[System.Serializable]
public class LevelDifficulty
{
    [SerializeField] int startStarsCount;
    [SerializeField] float levelDuration;
    [SerializeField][Range(0, 10)] float spawnSpeed;
    [SerializeField] AttackerSpawnConfig[] attackerSpawnConfigs;
}
