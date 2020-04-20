using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] LevelLoader levelLoader = default;

    static bool controllerInitialized;

    void Awake()
    {
        if (controllerInitialized)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        controllerInitialized = true;
    }

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
