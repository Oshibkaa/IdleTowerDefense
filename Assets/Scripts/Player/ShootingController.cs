using UnityEngine;

public class ShootingController : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private Transform _firePointTransform;
    [SerializeField] private GameObject _bulletPrefab, _rangeArea;
    [SerializeField] private ObjectPooler _objectPool;
    private GameObject _currentTarget;
    private PlayerBaseInfo _baseInfoScript;

    [Header("Options")]
    [SerializeField] private float projectileSpeed = 10f;
    private float _attackRange;
    private float _attackInterval;
    private float _lastAttackTime;

    private void Start()
    {
        _rangeArea.transform.localScale = new Vector3(2.5f, 2.5f, 0);

        _baseInfoScript = GameObjectManager.instance.allObjects[0].GetComponent<PlayerBaseInfo>();

        _attackRange = _baseInfoScript.RangeOfAttack;
        _attackInterval = _baseInfoScript.AttackSpeed;

        _baseInfoScript.AttackSpeedChanged += OnSpeedAttackChanged;
        _baseInfoScript.RangeOfAttackChanged += OnRangeOfAttackChanged;
    }

    void Update()
    {
        if (_currentTarget != null && _currentTarget.GetComponent<EnemyHealth>().CheckHealth > 0)
        {
            Attack(_currentTarget);
        }
        else
        {
            _currentTarget = FindNewTarget();
        }
    }

    GameObject FindNewTarget()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(_firePointTransform.position, _attackRange);
        GameObject closestTarget = null;
        float closestDistance = Mathf.Infinity;

        foreach (Collider2D hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Enemy") && hitCollider.GetComponent<EnemyHealth>().CheckHealth > 0)
            {
                float distanceToTarget = Vector2.Distance(_firePointTransform.position, hitCollider.transform.position);
                if (distanceToTarget < closestDistance)
                {
                    closestTarget = hitCollider.gameObject;
                    closestDistance = distanceToTarget;
                }
            }
        }

        return closestTarget;
    }

    void Attack(GameObject target)
    {
        if (Time.time - _lastAttackTime > _attackInterval)
        {
            Vector3 targetDirection = target.transform.position - _firePointTransform.position;
            targetDirection.Normalize();

            GameObject bullet = _objectPool.GetObject();
            if (bullet != null)
            {
                bullet.transform.position = _firePointTransform.position;
                bullet.transform.rotation = Quaternion.identity;
                bullet.SetActive(true);

                Rigidbody2D projectileRigidbody = bullet.GetComponent<Rigidbody2D>();
                projectileRigidbody.velocity = targetDirection * projectileSpeed;

                _lastAttackTime = Time.time;
            }
        }
    }

    private void OnSpeedAttackChanged(float newSpeed)
    {
        _attackInterval = 1f / newSpeed;
    }

    private void OnRangeOfAttackChanged(float newRange)
    {
        _attackRange = newRange;
        _rangeArea.transform.localScale += new Vector3(1.0f, 1.0f, 0);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_firePointTransform.position, _attackRange);
    }
}