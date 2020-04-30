using UnityEngine;

[CreateAssetMenu]
public class LevelConfiguration : ScriptableObject
{
    [Rename("Level timer, seconds")]
    [SerializeField] float levelTime = default; // TODO: this is set in levelDifficulties
    [SerializeField] [Range(1, 5)] int currentDifficulty;
    [SerializeField] public LevelDifficulty[] levelDifficulties; // TODO: remove public. Accessed in LevelDifficultyDrawer.

    float timeLeft;

    public float TimeLeft { get => timeLeft; set => timeLeft = value; }
    public float LevelTime { get => levelTime; }

    public void ResetTimer()
    {
        timeLeft = levelTime;
    }
}
