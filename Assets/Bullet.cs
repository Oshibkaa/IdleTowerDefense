using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Objects")]

    [Header("Options")]
    [SerializeField] private int _damage = 1;
    private bool _isHit = false;

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
