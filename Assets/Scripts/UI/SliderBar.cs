using UnityEngine;
using UnityEngine.UI;

public class SliderBar : MonoBehaviour
{
	[Header("Objects")]
	[SerializeField] private Slider _slider;

	public void SetMaxValue(float value)
	{
		_slider.maxValue = value;
		_slider.value = value;
	}

	public void SetHealth(float value)
	{
		_slider.value = value;
	}

}