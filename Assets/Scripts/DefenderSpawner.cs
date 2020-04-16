using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;
    bool[] cells;
    Vector2 fieldSize;
    [SerializeField] StarsCounter starsCounter = default;

    private void Start()
    {
        fieldSize = GetComponent<BoxCollider2D>().size;
        cells = new bool[(int)(fieldSize.x * fieldSize.y)];
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
            if (CanPlaceDefenderInCell(cell))
            {
                Instantiate(defender, cell + defender.DefenderOffset, Quaternion.identity);
                SetSellValue(cell);
                starsCounter.SpendStars(defender.StarCost);
            }
        }
    }

    private bool EnoughPointsForDefender(Defender defender)
    {
        return starsCounter.StarsCount >= defender.StarCost;
    }

    private Vector2 GetCellCoordinatesFromMouseClick()
    {
        var position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return new Vector2(Mathf.RoundToInt(position.x), Mathf.RoundToInt(position.y));
    }

    private void SetSellValue(Vector2 cell)
    {
        cells[CellCoordinatesToInt(cell)] = true;
    }

    private bool CanPlaceDefenderInCell(Vector2 cell)
    {
        return !cells[CellCoordinatesToInt(cell)];
    }

    private int CellCoordinatesToInt(Vector2 cell)
    {
        return (int)((cell.x - 1) + (cell.y - 1) * fieldSize.x);
    }
}
