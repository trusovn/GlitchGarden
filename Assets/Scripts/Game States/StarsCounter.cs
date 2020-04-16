using UnityEngine;

[CreateAssetMenu]
public class StarsCounter : ScriptableObject
{
    [SerializeField] int startStarsCount = 100;

    int starsCount;

    public int StarsCount { get => starsCount; }

    private void OnEnable()
    {
        starsCount = startStarsCount;
    }

    public void AddStars(int amount)
    {
        starsCount += amount;
    }

    public bool SpendStars(int amount)
    {
        if (amount > starsCount)
        {
            return false;
        }
        starsCount -= amount;
        return true;
    }
}
