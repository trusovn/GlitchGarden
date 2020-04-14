using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float flySpeed = 1;
    [SerializeField] int damagePoints = 25;

    public int DamagePoints { get => damagePoints; set => damagePoints = value; }

    void Update()
    {
        transform.Translate(Vector2.right * flySpeed * Time.deltaTime, Space.World);    
    }

    private void OnTriggerEnter2D(Collider2D collision) // TODO: deals damage to all. apply only to one.
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
