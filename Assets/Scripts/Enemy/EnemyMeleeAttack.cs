using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    private PlayerBaseHealth _playerBaseHealthScript;

    [Header("Options")]
    [SerializeField] private int _damage = 1;

    private void Start()
    {
        _playerBaseHealthScript = GameObjectManager.instance.allObjects[0].GetComponent<PlayerBaseHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _playerBaseHealthScript.TakeDamage(_damage);
        }
    }
}
