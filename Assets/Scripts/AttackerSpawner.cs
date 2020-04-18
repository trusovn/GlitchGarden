using System.Collections;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] attackers = default;
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

    IEnumerator SpawnAttackers() // todo: spawn new attackers with orderInLayer incrementing so faster ones will draw over those they overtake.
    {
        while (true)
        {
            if (spawn)
            {
                SpawnAttacker();
            }
            yield return new WaitForSeconds(Random.Range(1 / (spawnPerSecond + spawnRandomFactor), 1 / (spawnPerSecond - spawnRandomFactor)));
        }
        
    }

    private void SpawnAttacker()
    {
        var attackerIndex = Random.Range(0, attackers.Length);
        var prefabYPosition = Random.Range(spwanYMin, spwanYMax + 1);
        var offset = attackers[attackerIndex].GetComponent<Attacker>().AttackerOffset;
        var attacker = Instantiate(attackers[attackerIndex], new Vector2(spawnXPosition, prefabYPosition) + offset, Quaternion.identity);
        attacker.GetComponent<Sorting>().SetSortingLayerInChildren($"Lane {prefabYPosition}");
        attacker.transform.parent = transform;
    }
}
