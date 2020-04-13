using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int starCost = 50;
    [SerializeField] Vector2 defenderOffset;

    public Vector2 DefenderOffset { get => defenderOffset; set => defenderOffset = value; }
    public int StarCost { get => starCost; }
}
