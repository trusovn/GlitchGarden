using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MeleeFighter : DamageDealer
{
    [SerializeField] Collider2D attackCollider = default;

    protected override void Start()
    {
        base.Start();
        attackDistance = Mathf.Abs(attackCollider.bounds.center.x - attackCollider.bounds.max.x);
    }

    public override void Attack()
    {
        HitEnemy();
    }

    private void HitEnemy()
    {
        var enemies = GetEnemiesInRange<Health>();
        foreach (var enemy in enemies)
        {
            enemy.GotDamage(attackPoints);
        }
    }

    private List<T> GetEnemiesInRange<T>()
    {
        var attackArea = new Vector2(attackCollider.bounds.size.x, attackCollider.bounds.size.y);
        var enemies = Physics2D.OverlapBoxAll(MyAttackPosition(), new Vector2(1, 1), 0, LayerMask.GetMask(enemyLayerName));
        return new List<T>(enemies.Select(e => e.gameObject.GetComponent<T>()));
    }

    protected override Vector2 MyAttackPosition()
    {
        return attackCollider.bounds.center;
    }
}
