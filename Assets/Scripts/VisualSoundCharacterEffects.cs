using UnityEngine;

public class VisualSoundCharacterEffects : MonoBehaviour
{
    [SerializeField] GameObject deathParticleSystemPrefab = default;
    [SerializeField] Transform deathPSPosition = default;

    Attacker attacker;
    Animator animator;

    private void Start()
    {
        attacker = GetComponent<Attacker>();
        animator = GetComponent<Animator>();
    }

    public void PlayDamageEffects(bool minorDamage = false)
    {
        if (minorDamage)
        {
            animator.SetTrigger("MinorDamage");
        }
        else
        {
            animator.SetTrigger("Damage");
            if (attacker)
            {
                attacker.CanMove = false;
            }
        }
    }

    public void PlayDeathEffects()
    {
        animator.SetTrigger("Death");
        if (attacker)
        {
            attacker.CanMove = false;
        }
    }

    public void PlayDeathPS()
    {
        var go = Instantiate(deathParticleSystemPrefab, deathPSPosition.position, Quaternion.identity, transform);
        Destroy(go, go.GetComponent<ParticleSystem>().main.duration);
    }

    public void DagameAnimationEnds()
    {
        attacker.CanMove = true;
    }
}
