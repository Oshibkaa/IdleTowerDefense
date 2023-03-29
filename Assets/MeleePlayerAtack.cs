using UnityEngine;

public class MeleePlayerAtack : MonoBehaviour
{
    [Header("Objects")]
    private PlayerBaseInfo _baseInfoScript;

    [Header("Options")]
    private int _damage;

    private void Start()
    {
        _baseInfoScript = GameObjectManager.instance.allObjects[0].GetComponent<PlayerBaseInfo>();

        Subscribe();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(_damage);
        }
    }

    private void OnDamageAttackChanged(int newDamage)
    {
        _damage = newDamage;
    }

    private void Subscribe()
    {
        _baseInfoScript.DamageChanged += OnDamageAttackChanged;
        _damage = _baseInfoScript.Damage;
    }
}
