using UnityEngine;

[CreateAssetMenu]
public class StarsCounter : ScriptableObject
{
    [SerializeField] int startStarsCount = 100;
    [SerializeField] GameEvent onStarsCollected = default;

    int starsCount;

    public int StarsCount
    {
        get => starsCount;
        private set
        {
            starsCount = value;
            onStarsCollected.Raise();
        }
    }

    private void OnEnable()
    {
        StarsCount = startStarsCount;
    }

    public void AddStars(int amount)
    {
        StarsCount += amount;
    }

    public bool SpendStars(int amount)
    {
        if (amount > StarsCount)
        {
            return false;
        }
        StarsCount -= amount;
        return true;
    }
}
