using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
    [Header("EnemyHealth")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;
    private EnemyPatrol enemyPatrol;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
        enemyPatrol = GetComponent<EnemyPatrol>();

    }

    private void Update()
    {
        anim.SetBool("die", dead);
    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

      
        if(currentHealth <= 0)
        {
            if (!dead)
            {
                dead = true;
                anim.SetTrigger("died");
                GetComponent<SpiderEnemy>().enabled = false;
                if (enemyPatrol != null) enemyPatrol.OnDisable();

                Destroy(gameObject, 1f);
            }
        }
    }
}
