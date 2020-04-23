using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    [SerializeField] GameSettings gameSettings = default;
    [Space]
    [SerializeField] Slider difficulty = default;
    [SerializeField] Slider soundVolume = default;
    [Space]
    [SerializeField] Color emptyFillColor = Color.white;
    [SerializeField] Color fullFillColor = Color.white;

    void Start()
    {
        gameSettings.LoadSettings();
        SetSliderValues();
    }

    private void SetSliderValues()
    {
        difficulty.value = gameSettings.DifficultyLevel;
        soundVolume.value = gameSettings.SoundVolume;
        SetFillColors();
    }

    public void SetFillColors()
    {
        SetSliderFillColor(difficulty);
        SetSliderFillColor(soundVolume);
    }

    private void SetSliderFillColor(Slider slider)
    {
        var newColor = Color.Lerp(emptyFillColor, fullFillColor, slider.value / slider.maxValue);
        slider.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = newColor;
    }

    public void LoadDefaults()
    {
        gameSettings.RestoreDefaults();
        SetSliderValues();
    }
}
