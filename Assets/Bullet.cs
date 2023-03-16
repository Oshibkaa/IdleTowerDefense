using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Objects")]

    [Header("Options")]
    [SerializeField] private int _damage;
    private bool _isHit = false;

    private PlayerBaseInfo _baseInfo;

    private void Start()
    {
        _baseInfo = FindObjectOfType<PlayerBaseInfo>();
        _damage = _baseInfo.Damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && !_isHit)
        {
            _isHit = true;
            collision.gameObject.GetComponent<Enemy>().TakeDamage(_damage);

            Destroy();
        }
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
