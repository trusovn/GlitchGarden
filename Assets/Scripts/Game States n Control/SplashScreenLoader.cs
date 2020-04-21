using System.Collections;
using UnityEngine;

public class SplashScreenLoader : MonoBehaviour
{
    [SerializeField] LevelLoader levelLoader = default;

    void Start()
    {
        StartCoroutine(LoadStartSceneWithDelay());
    }

    IEnumerator LoadStartSceneWithDelay()
    {
        yield return new WaitForSeconds(3);
        levelLoader.LoadStartScene();
    }
}
