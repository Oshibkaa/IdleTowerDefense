using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Objects")]
    private PlayerBaseInfo _baseInfoScript;

    [Header("Options")]
    [SerializeField] private int _damage;
    private bool _isHit = false;


    private void Awake()
    {
        _baseInfoScript = GameObjectManager.instance.allObjects[0].GetComponent<PlayerBaseInfo>();

        OnEnable();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && !_isHit)
        {
            _isHit = true;
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(_damage);

           Disabled();
        }
    }

    private void Disabled()
    {
        _isHit = false;
        gameObject.SetActive(false);
    }

    private void OnDamageAttackChanged(int newDamage)
    {
        _damage = newDamage;
    }

    private void OnEnable()
    {
        _baseInfoScript.DamageChanged += OnDamageAttackChanged;
        _damage = _baseInfoScript.Damage;
    }

    private void OnDisable()
    {
        _baseInfoScript.DamageChanged -= OnDamageAttackChanged;
    }
}
