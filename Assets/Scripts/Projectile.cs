using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float flySpeed = 1;

    void Update()
    {
        transform.Translate(Vector2.right * flySpeed * Time.deltaTime, Space.World);    
    }
}
