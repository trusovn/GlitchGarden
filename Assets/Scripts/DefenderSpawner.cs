using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;
    [SerializeField] StarsCounter starsCounter = default;
    [SerializeField] FieldCells fieldCells = default;

    private void Start()
    {
        var collider = GetComponent<BoxCollider2D>();
        fieldCells.InitNewField((int)collider.size.x, (int)collider.size.y);
    }

    public void SetSelectedDefender(Defender defender)
    {
        this.defender = defender;
    }

    private void OnMouseDown()
    {
        if (defender && EnoughPointsForDefender(defender))
        {
            var cell = GetCellCoordinatesFromMouseClick();
            if (fieldCells.CanPlaceDefenderInCell(cell))
            {
                Instantiate(defender, cell + defender.DefenderOffset, Quaternion.identity);
                fieldCells.MarkCellOccupied(cell);
                starsCounter.SpendStars(defender.StarCost);
            }
        }
    }

    private bool EnoughPointsForDefender(Defender defender)
    {
        return starsCounter.StarsCount >= defender.StarCost;
    }

    private Vector2Int GetCellCoordinatesFromMouseClick()
    {
        var position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return new Vector2Int(Mathf.RoundToInt(position.x), Mathf.RoundToInt(position.y));
    }
}
