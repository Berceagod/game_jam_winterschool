using UnityEngine;

public class RemoveCollision : MonoBehaviour
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
        Collider2D collider2D = obj.GetComponent<Collider2D>(); // Get any 2D collider

        if (collider2D != null)
        {
            Destroy(obj); // Removes the collider completely
        }
    }
}
