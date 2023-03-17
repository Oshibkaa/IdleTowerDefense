using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private GameObject _moneyTextPrefab;
    [SerializeField] private ParticleSystem _explosionParticle;
    private UIManager _uiScript;
    private EnemyHealth _enemtHealthScript;

    [Header("Options")]
    private int _money = 1;

    private void Start()
    {
        _uiScript = GameObjectManager.instance.allObjects[1].GetComponent<UIManager>();
        _enemtHealthScript = GetComponent<EnemyHealth>();
        _enemtHealthScript.Death += OnEnemyDied;
    }

    void OnEnemyDied()
    {
        if (_enemtHealthScript.CheckHealth <= 0)
        {
            _uiScript.SetMoney(_money);
            DeathParticleEffect();
        }
    }

    private void DeathParticleEffect()
    {
        Instantiate(_explosionParticle, transform.position, _explosionParticle.transform.rotation);
        GameObject damageUi = Instantiate(_moneyTextPrefab, transform.position, Quaternion.identity);
        Text damageText = damageUi.GetComponentInChildren<Text>();
        damageText.text = "$" + _money.ToString();
    }
}
