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
            SaveSettings();
        }
    }
    public float SoundVolume
    {
        get => soundVolume;
        set
        {
            soundVolume = value;
            settingsChangedEvent.Raise();
            SaveSettings();
        }
    }
    public int DefaultDifficulty { get => defaultDifficulty; }
    public float DefaultSoundVolume { get => defaultSoundVolume; }


    public void SaveSettings()
    {
        PlayerPrefs.SetFloat(PrefTypes.GameDifficulty.Value, difficultyLevel);
        PlayerPrefs.SetFloat(PrefTypes.SoundVolume.Value, soundVolume);
        PlayerPrefs.Save();
    }

    public void LoadSettings()
    {
        DifficultyLevel = PlayerPrefs.HasKey(PrefTypes.GameDifficulty.Value) ? PlayerPrefs.GetFloat(PrefTypes.GameDifficulty.Value) : defaultDifficulty;
        SoundVolume = PlayerPrefs.HasKey(PrefTypes.SoundVolume.Value) ? PlayerPrefs.GetFloat(PrefTypes.SoundVolume.Value) : defaultSoundVolume;
    }

    public void RestoreDefaults()
    {
        DifficultyLevel = defaultDifficulty;
        SoundVolume = defaultSoundVolume;
    }

    private class PrefTypes
    {
        private PrefTypes(string value) { Value = value; }
        public string Value { get; set; }

        public static PrefTypes SoundVolume { get { return new PrefTypes("SoundVolume"); } }
        public static PrefTypes GameDifficulty { get { return new PrefTypes("GameDifficulty"); } }
    }
}
