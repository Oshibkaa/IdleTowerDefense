using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Objects")]
    private Vector3 _baseTransform;

    [Header("Options")]
    [SerializeField] private float _speed = 0.5f;
    [SerializeField] private float _stoppingDistance = 0.1f;
    private bool hasReachedTarget = false;

    private void Start()
    {
        _baseTransform = new Vector3(0f, 2.5f, 0);
    }

    private void FixedUpdate()
    {
        if (!hasReachedTarget)
        {
            float distance = Vector2.Distance(transform.position, _baseTransform);
            if (distance > _stoppingDistance)
            {
                Vector2 direction = (_baseTransform - transform.position).normalized;
                transform.Translate(_speed * Time.fixedDeltaTime * direction);
            }
            else
            {
                hasReachedTarget = true;
            }
        }
    }
}
