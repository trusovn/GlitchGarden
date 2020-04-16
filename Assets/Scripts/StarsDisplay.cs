using UnityEngine;
using UnityEngine.UI;

public class StarsDisplay : MonoBehaviour
{
    [SerializeField] StarsCounter starsCounter = default;
    
    Text starsText;
    int previousStarsValue = -1;

    private void Start()
    {
        starsText = GetComponent<Text>();
    }

    private void UpdateDisplay()
    {
        starsText.text = starsCounter.StarsCount.ToString();
    }

    private void Update() // TODO: do this on event
    {
        if (starsCounter.StarsCount != previousStarsValue)
        {
            UpdateDisplay();
            previousStarsValue = starsCounter.StarsCount;
        }
    }
}
