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

    public void PlayDamageEffects()
    {
        animator.SetTrigger("Damage");
        attacker.CanMove = false;
    }

    public void PlayDeathEffects()
    {
        animator.SetTrigger("Death");
        attacker.CanMove = false;
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
