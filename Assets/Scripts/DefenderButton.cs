using UnityEngine;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] GameObject defender;

    Color inactiveColor;
    SpriteRenderer buttonImageRenderer;

    private void Start()
    {
        buttonImageRenderer = GetComponentInChildren<SpriteRenderer>();
        inactiveColor = buttonImageRenderer.color;
    }
    
    private void OnMouseDown()
    {
        var menuButtons = FindObjectsOfType<DefenderButton>();
        foreach (var button in menuButtons)
        {
            button.SetInactiveColor();
        }
        SetColor(Color.white);
        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defender.GetComponent<Defender>());
    }

    private void SetColor(Color color)
    {
        buttonImageRenderer.color = color;
    }

    private void SetInactiveColor()
    {
        SetColor(inactiveColor);
    }
}
