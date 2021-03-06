﻿using UnityEngine;

public class RangedFighter : DamageDealer
{
    [SerializeField] GameObject attackProjectile = default;
    [SerializeField] Vector2 projectileSpawnOffset = default;

    protected override void Start()
    {
        base.Start();
        attackDistance = float.PositiveInfinity;
    }

    public override void Attack()
    {
        SpawnProjectile();
    }

    private void SpawnProjectile()
    {
        var projectile = Instantiate(attackProjectile, transform.position + new Vector3(projectileSpawnOffset.x, projectileSpawnOffset.y, 0), Quaternion.identity);
        projectile.GetComponent<Projectile>().DamagePoints = attackPoints;
        Destroy(projectile, projectile.GetComponent<Projectile>().DisposeTime);
    }
}
