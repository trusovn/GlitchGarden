using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int starCost = 50;
    [SerializeField] Vector2 defenderOffset;
    [SerializeField] bool canBeJumpedOver = false;

    public Vector2 DefenderOffset { get => defenderOffset; set => defenderOffset = value; }
    public int StarCost { get => starCost; }
    public bool CanBeJumpedOver { get => canBeJumpedOver; }
}
