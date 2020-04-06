using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0, 5)]
    [SerializeField] float moveSpeed = 1;
    [SerializeField] float spriteYOffset = 0;

    bool spawned = false;

    public float SpriteYOffset { get => spriteYOffset; }

    public void ObjectSpawned()
    {
        spawned = true;
    }

    public void SetMoveSpeed(float moveSpeed)
    {
        this.moveSpeed = moveSpeed;
    }

    void Update()
    {
        if (spawned)
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }
    }
}
