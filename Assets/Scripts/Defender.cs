using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] Vector2 defenderSpriteOffset;
    [SerializeField] GameObject attackProjectile;
    [SerializeField] Vector2 projectileSpawnOffset;

    public Vector2 DefenderSpriteOffset { get => defenderSpriteOffset; set => defenderSpriteOffset = value; }

    public void Attack()
    {
        if (attackProjectile)
        {
            Instantiate(attackProjectile, transform.position + new Vector3(projectileSpawnOffset.x, projectileSpawnOffset.y, 0), Quaternion.identity);
        }
    }
}
