using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] GameObject attackerPrefab = default;
    [Range(5, 10)][SerializeField] int spawnXPosition = 10;
    [Range(1, 5)] [SerializeField] int spwanYMin = 1;
    [Range(1, 5)] [SerializeField] int spwanYMax = 5;
    [Range(0, 10)][SerializeField] float spawnPerSecond = 1;
    [Range(0, 5)][SerializeField] float spawnRandomFactor = 0.5f;
    [SerializeField] bool spawn = true;

    public bool Spawn { get => spawn; set => spawn = value; }

    void Start()
    {
        StartCoroutine(SpawnAttackers());
    }
    IEnumerator SpawnAttackers()
    {
        while (true)
        {
            if (spawn)
            {
                var prefabYPosition = Random.Range(spwanYMin, spwanYMax + 1);
                var yOffset = attackerPrefab.GetComponent<Attacker>().SpriteYOffset;
                var attacker = Instantiate(attackerPrefab, new Vector2(spawnXPosition, prefabYPosition + yOffset), Quaternion.identity);
                attacker.GetComponent<SpriteRenderer>().sortingLayerName = $"Lane {prefabYPosition}";
            }
            yield return new WaitForSeconds(Random.Range(1 / (spawnPerSecond + spawnRandomFactor), 1 / (spawnPerSecond - spawnRandomFactor)));
        }
        
    }
}
