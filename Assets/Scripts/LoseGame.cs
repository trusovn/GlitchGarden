using UnityEngine;

public class LoseGame : MonoBehaviour
{
    [SerializeField] LevelLoader levelLoader = default;
    [SerializeField] RectTransform sceneFadeImage = default;
    [SerializeField] float sceneFadeTime = default;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LaunchGameOver();
    }

    private void LaunchGameOver()
    {
        LeanTween.alpha(sceneFadeImage, 1, sceneFadeTime);
        LeanTween.delayedCall(sceneFadeTime, levelLoader.LoadGameOver);
    }
}
