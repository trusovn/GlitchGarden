using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
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
        //var gameController = FindObjectOfType<GameController>();
        //if (gameController)
        //{
        //    gameController.ResetGame();
        //}
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
