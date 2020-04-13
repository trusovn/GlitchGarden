using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] GameObject attackProjectile = default;
    [SerializeField] Vector2 projectileSpawnOffset = default;
    [SerializeField] int attackPoints = default;
    [SerializeField] string attackAnimationParam = "Attacking"; // TODO: replace with parameter selection dropdown (AnimatorController.parameters?)
    [SerializeField] string enemyLayerName = "Attacker"; // TODO: replace with layer selection dropdown
    [SerializeField] Collider2D attackCollider = default;

    float attackDistance;
    Animator animator;
    Attacker attacker;

    private void Start()
    {
        animator = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
        if (attackProjectile)
        {
            attackDistance = float.PositiveInfinity;
        }
        else
        {
            attackDistance = Mathf.Abs(attackCollider.bounds.center.x - attackCollider.bounds.max.x);
        }
    }

    public void Attack()
    {
        if (attackProjectile)
        {
            SpawnProjectile();
        }
        else
        {
            HitEnemy();
        }
    }

    private void HitEnemy()
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
        var attackDirection = Vector2.right;
        if (attacker)
        {
            attackDirection *= -1;
        }
        var hit = Physics2D.Raycast(MyAttackPosition(), attackDirection, distance: attackDistance, layerMask: LayerMask.GetMask(enemyLayerName));
        return hit;
    }

    private void SetAttacking(bool isAttacking)
    {
        animator.SetBool(attackAnimationParam, isAttacking);
        if (attacker)
        {
            attacker.CanMove = !isAttacking;
        }
    }

    private List<T> GetEnemiesInRange<T>()
    {
        var attackArea = new Vector2(attackCollider.bounds.size.x, attackCollider.bounds.size.y);
        var enemies = Physics2D.OverlapBoxAll(MyAttackPosition(), new Vector2(1, 1), 0, LayerMask.GetMask(enemyLayerName));
        return new List<T>(enemies.Select(e => e.gameObject.GetComponent<T>()));
    }

    private Vector2 MyAttackPosition()
    {
        return attackCollider.bounds.center;
    }
}
