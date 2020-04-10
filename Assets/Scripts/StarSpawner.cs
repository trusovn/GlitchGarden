using UnityEngine;
using UnityEngine.Events;

public class StarSpawner : MonoBehaviour
{
    [SerializeField] int starPoints = default;
    [SerializeField] float spawnEveryNSeconds = default;
    [SerializeField] string animationStarSpawnTrigger = "NewStar";
    [SerializeField] Transform starSpawnPosition = default;
    //public void AddStarsToDisplay()
    //{
    //    addStarsMethod.Invoke(starCosts);
    //}

    public void SpawnStar()
    {
        
    }
}
