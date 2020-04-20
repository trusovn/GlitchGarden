using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu]
public class LevelLoader : ScriptableObject
{
    [SerializeField] [Scene] string startScene = default;
    [SerializeField] [Scene] string gameOverScene = default;
    [SerializeField] [Scene] string firstGameScene = default;

    public void LoadGameOver()
    {
        SceneManager.LoadScene(gameOverScene);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(firstGameScene);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(startScene);
    }

    public void QuitApp()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
