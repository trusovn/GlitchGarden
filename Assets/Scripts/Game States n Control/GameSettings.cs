using UnityEngine;

[CreateAssetMenu]
public class GameSettings : ScriptableObject
{
    [SerializeField] [Range(1, 5)] int defaultDifficulty = 1;
    [SerializeField] [Range(0, 1)] float defaultSoundVolume = .1f;
    [SerializeField] GameEvent settingsChangedEvent = default;
    private float soundVolume;
    private float difficultyLevel;

    public float DifficultyLevel
    {
        get => difficultyLevel;
        set
        {
            difficultyLevel = value;
            settingsChangedEvent.Raise();
        }
    }
    public float SoundVolume
    {
        get => soundVolume;
        set
        {
            soundVolume = value;
            settingsChangedEvent.Raise();
        }
    }
    public int DefaultDifficulty { get => defaultDifficulty; }
    public float DefaultSoundVolume { get => defaultSoundVolume; }

    public void RestoreDefaults()
    {
        DifficultyLevel = defaultDifficulty;
        SoundVolume = defaultSoundVolume;
    }
}