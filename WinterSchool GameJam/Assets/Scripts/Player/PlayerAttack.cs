using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    [Header("Attack Parameters")]
    [SerializeField] private float attackCooldown = 0.5f;
    [SerializeField] private float attackRange = 1f;
    [SerializeField] private int attackDamage = 10;

    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance = 0.5f;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask enemyLayer;

    private PlayerMovement playerMovement;
    private Animator anim;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();

        // Ensure boxCollider is assigned
        if (boxCollider == null)
            boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && cooldownTimer >= attackCooldown && playerMovement.canAttack())
        {
            Attack();
        }
    }

    private void Attack()
    {
        anim.SetTrigger("meleeAttack");
        cooldownTimer = 0;
        DamageEnemies();
    }

    private void DamageEnemies()
    {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(
            boxCollider.bounds.center + transform.right * attackRange * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * attackRange, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.zero, 0, enemyLayer);

        foreach (RaycastHit2D hit in hits)
        {
            EnemyHealth enemyHealth = hit.transform.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(attackDamage);
            }
        }
    }

    // Debugging attack range in Scene View
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(
            boxCollider.bounds.center + transform.right * attackRange * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * attackRange, boxCollider.bounds.size.y, boxCollider.bounds.size.z)
        );
    }
}
