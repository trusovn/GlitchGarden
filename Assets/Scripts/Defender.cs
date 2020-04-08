using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] GameObject attackProjectile;
    [SerializeField] Vector2 projectileSpawnOffset;

    public void Attack()
    {
        if (attackProjectile)
        {
            Instantiate(attackProjectile, transform.position + new Vector3(projectileSpawnOffset.x, projectileSpawnOffset.y, 0), Quaternion.identity);
        }
    }
}
