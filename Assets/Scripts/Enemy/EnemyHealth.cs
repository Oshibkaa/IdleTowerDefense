using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Options")]
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _currentHealth;

	public event System.Action Death;

	protected void Start()
    {
        _currentHealth = _maxHealth;
    }

	public void TakeDamage(int damage)
	{
		_currentHealth -= damage;

		if (_currentHealth <= 0)
		{
			_currentHealth = 0;

			if (Death != null)
			{
				Death();
			}

			DisableObject();
		}
	}

	public void SetMaxHealthValue()
	{
		_currentHealth = _maxHealth;
	}

	public void DisableObject()
	{
		gameObject.SetActive(false);
	}

	public int CheckHealth
	{
		get { return _currentHealth; }
		protected set { _currentHealth = value; }
	}
}
