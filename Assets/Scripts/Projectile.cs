using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float flySpeed = 1;
    [SerializeField] int damagePoints = 25;

    void Update()
    {
        transform.Translate(Vector2.right * flySpeed * Time.deltaTime, Space.World);    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Attacker>())
        {
            collision.GetComponent<Health>().GotDamage(damagePoints);
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
