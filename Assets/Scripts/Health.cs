using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int healthPoints = 10;

    public void GotDamage(int points)
    {
        healthPoints -= points;
        if (healthPoints <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
