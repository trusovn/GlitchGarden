using UnityEngine;

[CreateAssetMenu]
public class GameSettings : ScriptableObject
{
    [SerializeField][Range(1, 5)] int defaultDifficulty = 1;
    [SerializeField] [Range(0, 1)] float defaultSoundVolume = .1f;
    public float DifficultyLevel { get; set; }
    public float SoundVolume { get; set; }
    public int DefaultDifficulty { get => defaultDifficulty; }
    public float DefaultSoundVolume { get => defaultSoundVolume; }

    public void RestoreDefaults()
    {
        DifficultyLevel = defaultDifficulty;
        SoundVolume = defaultSoundVolume;
    }
}