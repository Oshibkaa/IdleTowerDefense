using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    [Header("Objects")]
    private PlayerBaseHealth _playerBaseHealthScript;

    [Header("Options")]
    private float _damage;

    private void Awake()
    {
        _playerBaseHealthScript = GameObjectManager.instance.allObjects[0].GetComponent<PlayerBaseHealth>();
        SetDamageValue();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _playerBaseHealthScript.TakeDamage(_damage);
        }
    }

    public void SetDamageValue()
    {
        _damage = EnemyStats.Damage;
    }
}
