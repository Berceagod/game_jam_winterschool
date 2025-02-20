using UnityEngine;

public class ChaseControl : MonoBehaviour
{
    public FlyingEnemy[] enemyArray;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Foreach corect: specificăm un nume pentru fiecare element din array
            foreach (FlyingEnemy enemy in enemyArray)
            {
                enemy.ActivateChase(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach (FlyingEnemy enemy in enemyArray)
            {
                enemy.ActivateChase(false);
            }
        }
    }

    void Start()
    {
        // Se apelează o singură dată, la început
    }

    void Update()
    {
        // Se apelează la fiecare frame
    }
}
