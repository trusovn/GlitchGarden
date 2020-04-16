using UnityEngine;

[CreateAssetMenu]
public class DefendersHolder : CharacterHolder
{
    [SerializeField] FieldCells fieldCells = default;

    public override void Die(GameObject character)
    {
        base.Die(character);
        fieldCells.MarkCellFree((int)character.transform.position.x, (int)character.transform.position.y);
    }
}
