using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] GameObject attackProjectile = default;
    [SerializeField] Vector2 projectileSpawnOffset = default;
    [SerializeField] int attackPoints = default;
    [SerializeField] float attackDistance = default;
    [SerializeField] string attackAnimationParam = "Attacking";
    [SerializeField] string attackersLayerName = "Attacker";

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Attack()
    {
        if (attackProjectile)
        {
            SpawnProjectile();
        }
        else
        {
            HitAttackers();
        }
    }

    private void HitAttackers()
    {
        var enemies = GetEnemiesInRange<Health>();
        foreach (var enemy in enemies)
        {
            enemy.GotDamage(attackPoints);
        }
    }

    private void SpawnProjectile()
    {
        var projectile = Instantiate(attackProjectile, transform.position + new Vector3(projectileSpawnOffset.x, projectileSpawnOffset.y, 0), Quaternion.identity);
        projectile.GetComponent<Projectile>().DamagePoints = attackPoints;
    }

    private void FixedUpdate()
    {
        if (attackDistance < 0) { return; } // Trophy, gravestone, etc.

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
        var hit = Physics2D.Raycast(transform.position, Vector2.right, distance: attackDistance, layerMask: LayerMask.GetMask(attackersLayerName));
        return hit;
    }

    private void SetAttacking(bool canAttack)
    {
        animator.SetBool(attackAnimationParam, canAttack);
    }

    private List<T> GetEnemiesInRange<T>()
    {
        var enemies = Physics2D.OverlapBoxAll(new Vector2(transform.position.x, transform.position.y), new Vector2(1, 1), 0, LayerMask.GetMask(attackersLayerName));
        return new List<T>(enemies.Select(e => e.gameObject.GetComponent<T>()));
    }
}
