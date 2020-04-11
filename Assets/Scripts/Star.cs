using UnityEngine;

public class Star : MonoBehaviour
{
    int starPoints = 10;
    float timeToLive = 20;

    public int StarPoints { get => starPoints; set => starPoints = value; }
    public float TimeToLive { get => timeToLive; set => timeToLive = value; }

    private void Start()
    {
        Destroy(gameObject, timeToLive);
    }

    private void OnMouseDown()
    {
        FindObjectOfType<StarsDisplay>().AddStars(starPoints);
        Destroy(gameObject);
    }
}
