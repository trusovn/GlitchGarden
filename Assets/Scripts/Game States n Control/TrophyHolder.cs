﻿using UnityEngine;

[CreateAssetMenu]
public class TrophyHolder : DefendersHolder
{
    public override void Die(GameObject trophy)
    {
        base.Die(trophy);
        var particles = trophy.GetComponentsInChildren<ParticleSystem>();
        foreach (var ps in particles)
        {
            ps.Stop(true);
        }
    }
}
