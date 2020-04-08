using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int healthPoints = 10;
    [SerializeField] float timeForDestroyingGO = 5;

    VisualSoundCharacterEffects visualSoundCharacterEffects;

    private void Start()
    {
        visualSoundCharacterEffects = GetComponent<VisualSoundCharacterEffects>();
    }

    public void GotDamage(int points)
    {
        if (!GetComponent<Attacker>().IsSpawned())
        {
            return;
        }
        healthPoints -= points;
        
        if (healthPoints <= 0)
        {
            Die();
        } 
        else
        {
            visualSoundCharacterEffects.PlayDamageEffects();
        }
    }

    void Die()
    {
        visualSoundCharacterEffects.PlayDeathEffects();
        gameObject.GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject, timeForDestroyingGO);
    }
}
