using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int starCost = 50;
    [SerializeField] Vector2 defenderOffset;
    [SerializeField] GameObject attackProjectile = default;
    [SerializeField] Vector2 projectileSpawnOffset = default;
    [SerializeField] float attackDistance = default;
    [SerializeField] string attackAnimationParam = "Attacking";

    Animator animator;

    public Vector2 DefenderOffset { get => defenderOffset; set => defenderOffset = value; }
    public int StarCost { get => starCost; }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Attack()
    {
        if (attackProjectile)
        {
            Instantiate(attackProjectile, transform.position + new Vector3(projectileSpawnOffset.x, projectileSpawnOffset.y, 0), Quaternion.identity);
        }
    }

    private void FixedUpdate()
    {
        if (attackDistance < 0) { return; } // Trophy

        if (CheckEnemyInAttackRange())
        {
            SetAttacking(true);
        }
        else
        {
            SetAttacking(false);
        }
    }

    private bool CheckEnemyInAttackRange()
    {
        var hit = Physics2D.Raycast(transform.position, Vector2.right, distance: attackDistance, layerMask: LayerMask.GetMask("Attacker"));
        return hit;
    }

    private void SetAttacking(bool canAttack)
    {
        animator.SetBool(attackAnimationParam, canAttack);
    }
}
