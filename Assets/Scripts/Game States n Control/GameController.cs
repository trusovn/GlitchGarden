using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] LevelLoader levelLoader = default;
    [SerializeField] LevelConfiguration levelConfiguration = default;

    private void Update()
    {
        levelConfiguration.TimeLeft -= Time.deltaTime;
        if (levelConfiguration.TimeLeft <= 0)
        {
            levelLoader.LoadGameOver();
        }
    }
}
