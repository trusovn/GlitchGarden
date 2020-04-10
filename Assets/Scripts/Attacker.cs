using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0, 5)]
    [SerializeField] float moveSpeed = 1;
    [SerializeField] Vector2 attackerOffset = default;

    bool spawned = false;
    bool canMove = true;

    public Vector2 AttackerOffset { get => attackerOffset; }
    public bool CanMove { get => canMove; set => canMove = value; }

    public void ObjectSpawned()
    {
        spawned = true;
    }

    public bool IsSpawned()
    {
        return spawned;
    }

    public void SetMoveSpeed(float moveSpeed)
    {
        this.moveSpeed = moveSpeed;
    }

    void Update()
    {
        if (spawned && canMove)
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }
    }
}
