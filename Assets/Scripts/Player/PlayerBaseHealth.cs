using UnityEngine;

public class PlayerBaseHealth : MonoBehaviour
{
	[Header("Objects")]
	[SerializeField] private SliderBar _sliderBar;
	private UIManager _uiScript;

	[Header("Options")]
	[SerializeField] private int _maxHealth;
	[SerializeField] private float _currentHealth;

	protected void Start()
	{
		_uiScript = GameObjectManager.instance.allObjects[1].GetComponent<UIManager>();

		_currentHealth = _maxHealth;
		_sliderBar.SetMaxValue(_maxHealth);
	}

	public void TakeDamage(float damage)
	{
		_currentHealth -= damage;

		_sliderBar.SetHealth(_currentHealth);

		if (_currentHealth <= 0)
		{
			_currentHealth = 0;

			DisableObject();
		}
	}

	public void SetHealthValue(int value)
	{
		_currentHealth += value;
		_maxHealth += value;

		_sliderBar.SetMaxValue(_maxHealth);
		_sliderBar.SetHealth(_currentHealth);
	}

	public void DisableObject()
	{
		gameObject.SetActive(false);
		_uiScript.PauseGame();
	}

	public float CheckHealth
	{
		get { return _currentHealth; }
		protected set { _currentHealth = value; }
	}
}
