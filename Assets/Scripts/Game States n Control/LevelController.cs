using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour
{
    [SerializeField] LevelLoader levelLoader = default;
    [SerializeField] LevelConfiguration levelConfiguration = default;
    [Space]
    [SerializeField] GameObject winTextPrefab = default;
    [SerializeField] CharacterHolder attackersHolder = default;
    [Tooltip("Time win overlay shown before going to scene selection")] 
    [SerializeField] float winScreenTime = default;
    [Tooltip("Win screen animation time")]
    [SerializeField] float winScreenAnimationTime = default;
    [Space]
    [SerializeField] [Scene] string nextScene = default;

    bool gameOver;

    private void Start()
    {
        levelConfiguration.ResetTimer();
    }

    private void Update()
    {
        LevelTimeProgress();
    }

    private void LevelTimeProgress()
    {
        levelConfiguration.TimeLeft -= Time.deltaTime;
        if (levelConfiguration.TimeLeft <= 0 && !gameOver)
        {
            gameOver = true;
            StartCoroutine(EndLevel());
        }
    }

    private IEnumerator EndLevel()
    {
        FindObjectOfType<AttackerSpawner>().Spawn = false;
        yield return new WaitUntil(() => attackersHolder.Count <= 0);
        ShowWinOverlay();
        LeanTween.delayedCall(winScreenTime, () => levelLoader.LoadScene(nextScene));
    }

    private void ShowWinOverlay()
    {
        var canvas = FindObjectOfType<Canvas>();
        var winText = Instantiate(winTextPrefab).GetComponent<RectTransform>();
        var fullScale = winText.localScale;
        winText.localScale = Vector3.zero;
        LeanTween.scale(winText, fullScale, winScreenAnimationTime).setEase(LeanTweenType.easeOutBounce);
    }
}
