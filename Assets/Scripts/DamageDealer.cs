using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] protected int attackPoints = default;
    [SerializeField] string attackAnimationParam = "Attacking"; // TODO: replace with parameter selection dropdown (AnimatorController.parameters?)
    [SerializeField] protected string enemyLayerName = "Attacker"; // TODO: replace with layer selection dropdown

    protected float attackDistance;
    protected Animator animator;
    protected Attacker attacker;
    Collider2D myCollider;

    private void Start()
    {
        animator = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
        myCollider = GetComponent<Collider2D>();
    }

    public virtual void Attack() { }

    private void FixedUpdate()
    {
        if (CheckEnemyInAttackRange())
        {
            SetAttacking(true);
        }
        else
        {
            SetAttacking(false);
        }
    }

    private bool CheckEnemyInAttackRange()
    {
        var attackDirection = Vector2.right;
        if (attacker)
        {
            attackDirection *= -1;
        }
        var hit = Physics2D.Raycast(MyAttackPosition(), attackDirection, distance: attackDistance, layerMask: LayerMask.GetMask(enemyLayerName));
        return hit;
    }

    private void SetAttacking(bool isAttacking)
    {
        animator.SetBool(attackAnimationParam, isAttacking);
        if (attacker)
        {
            attacker.CanMove = !isAttacking;
        }
    }

    protected virtual Vector2 MyAttackPosition()
    {
        return myCollider.bounds.center;
    }
}
