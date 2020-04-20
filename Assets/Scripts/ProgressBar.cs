using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] LevelConfiguration levelConfiguration = default;

    [Header("Handle animation settings")]
    [SerializeField] RectTransform sliderHandle = default;
    [SerializeField] float scaleSize = default;
    [SerializeField] float scaleSpeed = default;

    private void Start()
    {
        SetHandleAnimation();
    }

    private void SetHandleAnimation()
    {
        LeanTween.scale(sliderHandle, sliderHandle.localScale * scaleSize, 1 / scaleSpeed).setEaseInOutBounce().setLoopPingPong();
    }

    private void Update()
    {
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelConfiguration.LevelTime;
    }
}
