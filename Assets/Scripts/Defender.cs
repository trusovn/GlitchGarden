using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] Vector2 defenderOffset;
    [SerializeField] GameObject attackProjectile = default;
    [SerializeField] Vector2 projectileSpawnOffset = default;
    [SerializeField] int starCost = 50;

    public Vector2 DefenderOffset { get => defenderOffset; set => defenderOffset = value; }
    public int StarCost { get => starCost; }

    public void Attack()
    {
        if (attackProjectile)
        {
            Instantiate(attackProjectile, transform.position + new Vector3(projectileSpawnOffset.x, projectileSpawnOffset.y, 0), Quaternion.identity);
        }
    }
}
