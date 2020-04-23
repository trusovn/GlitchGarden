using UnityEngine;
using UnityEngine.UI;

public class StarsDisplay : MonoBehaviour
{
    [SerializeField] StarsCounter starsCounter = default;
    
    Text starsText;

    private void Start()
    {
        starsText = GetComponent<Text>();
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        starsText.text = starsCounter.StarsCount.ToString();
    }
}
