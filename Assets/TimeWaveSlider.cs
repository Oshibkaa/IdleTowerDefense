using UnityEngine;
using UnityEngine.UI;

public class TimeWaveSlider : MonoBehaviour
{
	[Header("Objects")]
	[SerializeField] private Slider slider;

	public void SetMaxHealth(float value)
	{
		slider.maxValue = value;
		slider.value = value;
	}

	public void SetHealth(float value)
	{
		slider.value = value;
	}

}