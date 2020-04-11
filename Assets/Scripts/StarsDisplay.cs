using UnityEngine;
using UnityEngine.UI;

public class StarsDisplay : MonoBehaviour
{
    [SerializeField][Rename("Start Stars Count")] int starsCount = 100; // todo: move this to some kind of LevelSetup GO, as otherwise it's hard to locate.
    Text starsText;

    public int StarsCount { get => starsCount; }

    private void Start()
    {
        starsText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        starsText.text = starsCount.ToString();
    }

    public void AddStars(int amount)
    {
        starsCount += amount;
        UpdateDisplay();
    }

    public bool SpendStars(int amount)
    {
        if (amount > starsCount)
        {
            return false;
        }
        starsCount -= amount;
        UpdateDisplay();
        return true;
    }
}
