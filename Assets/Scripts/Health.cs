using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int healthPoints = 10;
    [SerializeField] float timeForDestroyingGO = 5;
    [SerializeField] int minorDamageThreshold = 5;
    [SerializeField] CharacterHolder characterHolder = default;

    VisualSoundCharacterEffects visualSoundCharacterEffects;

    private void Start()
    {
        visualSoundCharacterEffects = GetComponent<VisualSoundCharacterEffects>();
        characterHolder.Add(gameObject);
    }

    public void GotDamage(int points)
    {
        healthPoints -= points;
        
        if (healthPoints <= 0)
        {
            Die();
        } 
        else
        {
            visualSoundCharacterEffects.PlayDamageEffects(points <= minorDamageThreshold);
        }
    }

    void Die() // TODO: consider moving visual effects and actual 'death' implementation details out of here. Same goes for visual effects at damage.
    {
        characterHolder.Die(gameObject);
        visualSoundCharacterEffects.PlayDeathEffects();
        gameObject.GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject, timeForDestroyingGO);
    }

    private void OnDisable()
    {
        characterHolder.Remove(gameObject);
    }
}
