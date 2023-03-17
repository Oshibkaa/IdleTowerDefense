using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] Text _timeText;

    [Header("Options")]
    private float _timeScale = 1f;

    private void Start()
    {
        Time.timeScale = 1f;
        _timeText.text = "x" + _timeScale.ToString("0.00", System.Globalization.CultureInfo.GetCultureInfo("en-US"));
    }

    public void IncreaseTimeScale()
    {
        _timeScale += 1f;
        if (_timeScale >= 1.5f)
        {
            _timeScale = 1.5f;
        }
        Time.timeScale = _timeScale;
        _timeText.text = "x" + _timeScale.ToString("0.00", System.Globalization.CultureInfo.GetCultureInfo("en-US"));
    }

    public void DecreaseTimeScale()
    {
        _timeScale -= 0.5f;
        if (_timeScale < 1f)
        {
            _timeScale = 0f;
        }
        Time.timeScale = _timeScale;
        _timeText.text = "x" + _timeScale.ToString("0.00", System.Globalization.CultureInfo.GetCultureInfo("en-US"));
    }
}
