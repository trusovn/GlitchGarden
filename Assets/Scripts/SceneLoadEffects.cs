using System.Collections;
using UnityEngine;

public class SceneLoadEffects : MonoBehaviour
{
    [SerializeField] RectTransform sceneFadeImage = default;
    [SerializeField] float fadeInTime = default;

    void Start()
    {
        StartCoroutine(FadeImageOutWithDelay());
    }

    IEnumerator FadeImageOutWithDelay()
    {
        yield return null;
        LeanTween.alpha(sceneFadeImage, 0, fadeInTime);
    }
}
