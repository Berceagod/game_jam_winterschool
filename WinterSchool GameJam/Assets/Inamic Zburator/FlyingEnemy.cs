using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    [Header("Attack Parameters")]
    [SerializeField] private float attackCooldown = 1f;  // Time between attacks
    [SerializeField] private float attackRange = 2f;     // Distance for attack trigger
    [SerializeField] private int damage = 10;            // Damage dealt on attack


    [Header("Movement Parameters")]
    [SerializeField] private float chaseSpeed = 3f;      // Speed while chasing player

    [Header("Collider Parameters")]
    [SerializeField] private BoxCollider2D boxCollider;   // BoxCollider for detecting player
    [SerializeField] private float colliderDistance = 1f; // Distance to check for player

    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;       // The layer of the player

    private Animator anim;                                // Animator for attack animation
    private Transform player;                             // Reference to player
    private Health playerHealth;                          // Reference to player's health
    private float cooldownTimer = Mathf.Infinity;        // Timer for attack cooldown
    public Transform startingPoint;

    private bool chase = false;                           // To activate chase when player is in range


    private void Awake()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (chase == true)
        {
            Chase();
           
        }

        else
        {
            ReturnStart();
        }
            
        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                anim.SetTrigger("meleeAttack");
            }
            ActivateChase(true);
        }

    }

    // Detect if the player is within range of the ghost
    private bool PlayerInSight()
    {
        // Perform a boxcast to detect if the player is within range
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * colliderDistance,
            new Vector2(boxCollider.bounds.size.x * colliderDistance, boxCollider.bounds.size.y),
            0, Vector2.left, 0, playerLayer);

        if (hit.collider != null)
        {
            playerHealth = hit.transform.GetComponent<Health>(); // Get player's health if hit
        }

        return hit.collider != null;
    }

    // Move the ghost enemy towards the player
    private void Chase()
    {

        transform.position = Vector2.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime);
        anim.SetBool("moving", true);
    }

    // Deal damage to the player if within attack range
    private void DamagePlayer()
    {
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);  // Apply damage to the player
        }
    }

    // Optionally visualize the detection range with Gizmos for debugging
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * colliderDistance, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    // Call this method to activate chase mode
    public void ActivateChase(bool activate)
    {
        chase = activate;
    }
    private void ReturnStart()
    {
        transform.position = Vector2.MoveTowards(transform.position, startingPoint.position, chaseSpeed * Time.deltaTime);
    }
}
