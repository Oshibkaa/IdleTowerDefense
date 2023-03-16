using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [Header("Objects")]
    private UIManager _ui;
    [SerializeField] private GameObject _moneyTextPrefab;
    [SerializeField] private ParticleSystem _explosionParticle;

    [Header("Options")]
    [SerializeField] private int _maxhealth = 1;
    [SerializeField] private int _health = 1;
    private int _money = 1;

    private void Start()
    {
        _health = _maxhealth;
        _ui = FindObjectOfType<UIManager>();
    }

    public void UpdateHealth()
    {
        _health = _maxhealth;
    }

    public void TakeDamage(int value)
    {
        Debug.Log("Enemy is hit!");
        _health -= value;

        if (_health <= 0)
        {
            DeathParticle();
            _ui.SetGold(_money);
            Die();
        }
    }

    public bool IsAlive()
    {
        return _health > 0;
    }

    private void DeathParticle()
    {
        Instantiate(_explosionParticle, transform.position, _explosionParticle.transform.rotation);
        GameObject damageUi = Instantiate(_moneyTextPrefab, transform.position, Quaternion.identity);
        Text damageText = damageUi.GetComponentInChildren<Text>();
        damageText.text = "$" + _money.ToString();
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("You lose :(");
        }
    }
}
