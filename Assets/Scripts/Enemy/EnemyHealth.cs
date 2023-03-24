using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
	[Header("Objects")]
	[SerializeField] private GameObject _moneyTextPrefab;
	[SerializeField] private ParticleSystem _explosionParticle;
	private UIManager _uiScript;

	[Header("Options")]
    [SerializeField] private float _currentHealth;
    private float _maxHealth;
	private int _money;

	public event System.Action Death;

	protected void Awake()
    {
		_uiScript = GameObjectManager.instance.allObjects[1].GetComponent<UIManager>();

		_money = EnemyStats.Money;

		SetMaxHealthValue();
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
		_maxHealth = EnemyStats.Health;
		_currentHealth = _maxHealth;
	}

	public void DisableObject()
	{
		_uiScript.SetMoney(_money);
		DeathParticleEffect();
		gameObject.SetActive(false);
	}

	private void DeathParticleEffect()
	{
		Instantiate(_explosionParticle, transform.position, _explosionParticle.transform.rotation);
		GameObject damageUi = Instantiate(_moneyTextPrefab, transform.position, Quaternion.identity);
		Text damageText = damageUi.GetComponentInChildren<Text>();
		damageText.text = "$" + _money.ToString();
	}

	public float CheckHealth
	{
		get { return _currentHealth; }
		protected set { _currentHealth = value; }
	}
}
