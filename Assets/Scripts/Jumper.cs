using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField] float jumpStartDistance = 1;
    [SerializeField] float jumpMoveSpeed = 2;
    [SerializeField] string jumpTriggerName = "Jump";
    [SerializeField] Collider2D attackCollider = default; // TODO: check for cleanup

    Attacker attacker;
    Animator animator;
    DamageDealer damageDealer;
    string enemyLayerName;
    bool inJump;

    void Start()
    {
        attacker = GetComponent<Attacker>();
        animator = GetComponent<Animator>();
        damageDealer = GetComponent<DamageDealer>();
        enemyLayerName = GetComponent<DamageDealer>().EnemyLayerName;
    }

    private void FixedUpdate()
    {
        var hit = Physics2D.Raycast(transform.position, Vector2.left, distance: jumpStartDistance, layerMask: LayerMask.GetMask(enemyLayerName));
        if (hit.collider != null && hit.collider.GetComponent<Defender>().CanBeJumpedOver && !inJump)
        {
            JumpOver();
        }
    }

    private void JumpOver()
    {
        inJump = true;
        animator.SetTrigger(jumpTriggerName);
        damageDealer.enabled = false;
        attacker.SetMoveSpeed(jumpMoveSpeed);
    }

    public void JumpLanded()
    {
        attacker.SetMoveSpeed(0);
    }

    public void JumpCompleted()
    {
        damageDealer.enabled = true;
        attacker.RestoreMoveSpeed();
        inJump = false;
    }
}
