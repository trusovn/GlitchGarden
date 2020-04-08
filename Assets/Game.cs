using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] Defender defender = default;
    
    private void OnMouseDown()
    {
        var position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Instantiate(defender, new Vector2(position.x, position.y), Quaternion.identity);
    }
}
