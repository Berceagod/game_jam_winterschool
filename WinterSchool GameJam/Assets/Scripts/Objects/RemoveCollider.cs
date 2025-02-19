using UnityEngine;

public class RemoveCollision: MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            RemoveCollider(collision.gameObject);
        }
    }
    private void RemoveCollider(GameObject obj)
    {
        Collider2D collider2D = obj.GetComponent<BoxCollider2D>();
        if (collider2D != null)
        {
            Destroy(collider2D); // Removes 2D collider
            return;
        }
    }
    }
