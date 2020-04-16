using System.Collections;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    [SerializeField] int starPoints = default;
    [SerializeField] float spawnEveryNSeconds = default;
    [SerializeField] string animationStarSpawnTrigger = "NewStar";
    [SerializeField] float starTimeToLive = default;
    [SerializeField] GameObject starPrefab = default;

    Animator spawnerAnimator;

    private void Start()
    {
        spawnerAnimator = GetComponent<Animator>();
        StartCoroutine(StarSpawnAnimationTrigger());
    }

    IEnumerator StarSpawnAnimationTrigger()
    {
        while (true)
        {
            spawnerAnimator.SetTrigger(animationStarSpawnTrigger);
            yield return new WaitForSeconds(spawnEveryNSeconds);
        }
    }

    // called by Animation
    public void SpawnStar()
    {
        var starGO = Instantiate(starPrefab, transform.position, Quaternion.identity);
        var star = starGO.GetComponentInChildren<Star>();
        star.TimeToLive = starTimeToLive;
        star.StarPoints = starPoints;
    }
}
