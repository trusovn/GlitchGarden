using UnityEngine;

[CreateAssetMenu]
public class LevelConfiguration : ScriptableObject
{
    [Rename("Level timer, seconds")]
    [SerializeField] float levelTime = default;

    float timeLeft;

    public float TimeLeft { get => timeLeft; set => timeLeft = value; }
    public float LevelTime { get => levelTime; }

    public void ResetTimer()
    {
        timeLeft = levelTime;
    }
}
