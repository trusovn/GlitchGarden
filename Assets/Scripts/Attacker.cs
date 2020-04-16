using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0, 5)]
    [SerializeField] float moveSpeed = 1;
    [SerializeField] Vector2 attackerOffset = default;

    bool canMove = false;
    DamageDealer attackersDamageDealer;
    Collider2D attackersMainCollider;

    public Vector2 AttackerOffset { get => attackerOffset; }
    public bool CanMove { get => canMove; set => canMove = value; }

    private void Awake()
    {
        attackersMainCollider = GetComponent<Collider2D>();
        attackersMainCollider.enabled = false;
        attackersDamageDealer = GetComponent<DamageDealer>();
        attackersDamageDealer.enabled = false;
    }

    public void ObjectSpawned()
    {
        attackersMainCollider.enabled = true;
        attackersDamageDealer.enabled = true;
        canMove = true;
    }

    void Update()
    {
        if (canMove && !attackersDamageDealer.InAttack) // TODO: add small random delay after killing and enemy, so few attackers won't move identically.
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }
    }
}
