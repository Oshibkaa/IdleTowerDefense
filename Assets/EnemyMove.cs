using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private Transform _player;

    [Header("Options")]
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private float _stoppingDistance = 1.0f;
    private bool hasReachedTarget = false;

    private void Start()
    {
        _player = GameObjectManager.instance.allObjects[0].transform;
    }

    private void FixedUpdate()
    {
        if (!hasReachedTarget)
        {
            float distance = Vector2.Distance(transform.position, _player.position);
            if (distance > _stoppingDistance)
            {
                Vector2 direction = (_player.position - transform.position).normalized;
                transform.Translate(_speed * Time.deltaTime * direction);
            }
            else
            {
                hasReachedTarget = true;
            }
        }
    }
}
