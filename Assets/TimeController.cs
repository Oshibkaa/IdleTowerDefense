using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    private float timeScale = 1f;
    [SerializeField] Text _timeText;

    private void Start()
    {
        Time.timeScale = 1f;
        _timeText.text = "x" + timeScale;
    }

    public void IncreaseTimeScale()
    {
        timeScale += 1f;
        if (timeScale >= 1.5f)
        {
            timeScale = 1.5f;
        }
        Time.timeScale = timeScale;
        _timeText.text = "x" + timeScale;
    }

    public void DecreaseTimeScale()
    {
        timeScale -= 0.5f;
        if (timeScale < 1f)
        {
            timeScale = 0f;
        }
        Time.timeScale = timeScale;
        _timeText.text = "x" + timeScale;
    }
}
