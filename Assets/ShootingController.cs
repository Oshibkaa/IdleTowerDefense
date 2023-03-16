using UnityEngine;

public class ShootingController : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private Transform attackTransform;
    [SerializeField] private GameObject projectilePrefab, RangeArea;
    private GameObject currentTarget;
    private PlayerBaseInfo _baseInfo;

    [Header("Options")]
    [SerializeField] private float projectileSpeed = 10f;
    private float _attackRange;
    private float _attackInterval;
    private float _lastAttackTime;

    private void Start()
    {
        RangeArea.transform.localScale = new Vector3(60, 60, 0);
        _baseInfo = FindObjectOfType<PlayerBaseInfo>();
        _attackRange = _baseInfo.RangeOfAttack;
        _attackInterval = _baseInfo.AttackSpeed;
        _baseInfo.AttackSpeedChanged += OnSpeedAttackChanged;
        _baseInfo.RangeOfAttackChanged += OnRangeOfAttackChanged;
    }

    void Update()
    {
        if (currentTarget != null && currentTarget.GetComponent<Enemy>().IsAlive())
        {
            Attack(currentTarget);
        }
        else
        {
            currentTarget = FindNewTarget();
        }
    }

    GameObject FindNewTarget()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(attackTransform.position, _attackRange);
        GameObject closestTarget = null;
        float closestDistance = Mathf.Infinity;

        foreach (Collider2D hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Enemy") && hitCollider.GetComponent<Enemy>().IsAlive())
            {
                float distanceToTarget = Vector2.Distance(attackTransform.position, hitCollider.transform.position);
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
            // Вычисляем направление к цели
            Vector3 targetDirection = target.transform.position - attackTransform.position;
            targetDirection.Normalize();

            // Создаем пулю и запускаем ее в сторону цели
            GameObject projectile = Instantiate(projectilePrefab, attackTransform.position, Quaternion.identity);
            Rigidbody2D projectileRigidbody = projectile.GetComponent<Rigidbody2D>();
            projectileRigidbody.velocity = targetDirection * projectileSpeed;

            _lastAttackTime = Time.time;
        }
    }

    private void OnSpeedAttackChanged(float newSpeed)
    {
        _attackInterval = 1f / newSpeed;
    }

    private void OnRangeOfAttackChanged(float newRange)
    {
        _attackRange = newRange;
        RangeArea.transform.localScale += new Vector3(10, 10, 0);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackTransform.position, _attackRange);
    }
}