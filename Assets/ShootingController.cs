using UnityEngine;

public class ShootingController : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private Transform attackTransform;
    [SerializeField] private GameObject projectilePrefab;
    private GameObject currentTarget;
    //private Player player;

    [Header("Options")]
    [SerializeField] private float attackRange = 10f;
    [SerializeField] private float attackInterval = 1f;
    [SerializeField] private float projectileSpeed = 10f;
    private float lastAttackTime;
    private float speedAttack;

    private void Start()
    {
        /*player = FindObjectOfType<Player>();
        speedAttack = player.SpeedAttack;*/
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
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(attackTransform.position, attackRange);
        foreach (Collider2D hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Enemy") && hitCollider.GetComponent<Enemy>().IsAlive())
            {
                return hitCollider.gameObject;
            }
        }
        return null;
    }

    void Attack(GameObject target)
    {
        if (Time.time - lastAttackTime > attackInterval)
        {
            // Вычисляем направление к цели
            Vector3 targetDirection = target.transform.position - attackTransform.position;
            targetDirection.Normalize();

            // Создаем пулю и запускаем ее в сторону цели
            GameObject projectile = Instantiate(projectilePrefab, attackTransform.position, Quaternion.identity);
            Rigidbody2D projectileRigidbody = projectile.GetComponent<Rigidbody2D>();
            projectileRigidbody.velocity = targetDirection * projectileSpeed;

            lastAttackTime = Time.time;
        }
    }

    public void SetAttackInterval()
    {
        attackInterval -= speedAttack;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackTransform.position, attackRange);
    }
}