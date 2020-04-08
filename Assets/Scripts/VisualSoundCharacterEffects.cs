using UnityEngine;

public class VisualSoundCharacterEffects : MonoBehaviour
{
    [SerializeField] ParticleSystem deathParticleSystem = default;
    
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
        deathParticleSystem.Play();
    }

    public void DagameAnimationEnds()
    {
        attacker.CanMove = true;
    }
}
