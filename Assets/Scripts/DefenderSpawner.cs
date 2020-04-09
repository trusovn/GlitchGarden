using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;
    
    public void SetSelectedDefender(Defender defender)
    {
        this.defender = defender;
    }

    private void OnMouseDown()
    {
        Instantiate(defender, GetCellCoordinatesFromMouseClick() + defender.DefenderSpriteOffset, Quaternion.identity);
    }

    private Vector2 GetCellCoordinatesFromMouseClick()
    {
        var position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return new Vector2(Mathf.RoundToInt(position.x), Mathf.RoundToInt(position.y));
    }
}
