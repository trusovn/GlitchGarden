using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] GameSettings gameSettings = default;   
    AudioSource audioSource;

    void Start()
    {
        if (FindObjectsOfType<MusicPlayer>().Length > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
        UpdateSoundVolume();
    }

    public void UpdateSoundVolume()
    {
        audioSource.volume = gameSettings.SoundVolume;
    }
}
