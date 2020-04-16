using UnityEngine;

[CreateAssetMenu]
public class FieldCells : ScriptableObject
{
    bool[] cells;
    Vector2Int fieldSize;

    public void InitNewField(int x, int y)
    {
        fieldSize = new Vector2Int(x, y);
        cells = new bool[fieldSize.x * fieldSize.y];
    }

    public void MarkCellOccupied(Vector2Int cell)
    {
        cells[CellCoordinatesToInt(cell)] = true;
    }

    public void MarkCellFree(Vector2Int cell)
    {
        cells[CellCoordinatesToInt(cell)] = false;
    }

    public bool CanPlaceDefenderInCell(Vector2Int cell)
    {
        return !cells[CellCoordinatesToInt(cell)];
    }

    private int CellCoordinatesToInt(Vector2Int cell)
    {
        return (cell.x - 1) + (cell.y - 1) * fieldSize.x;
    }
}
