using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    [SerializeField] GameSettings gameSettings = default;
    [SerializeField] Slider difficulty = default;
    [SerializeField] Slider soundVolume = default;

    void Start()
    {
        SetSliderValues();
    }

    private void SetSliderValues()
    {
        difficulty.value = gameSettings.DifficultyLevel;
        soundVolume.value = gameSettings.SoundVolume;
    }

    public void LoadDefaults()
    {
        gameSettings.RestoreDefaults();
        SetSliderValues();
    }
}
