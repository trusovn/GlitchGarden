using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] Vector2 defenderSpriteOffset;
    [SerializeField] GameObject attackProjectile = default;
    [SerializeField] Vector2 projectileSpawnOffset = default;
    [SerializeField] int starCost = 50;

    public Vector2 DefenderSpriteOffset { get => defenderSpriteOffset; set => defenderSpriteOffset = value; }

    public void Attack()
    {
        if (attackProjectile)
        {
            Instantiate(attackProjectile, transform.position + new Vector3(projectileSpawnOffset.x, projectileSpawnOffset.y, 0), Quaternion.identity);
        }
    }
}
