using UnityEngine;

public class BucketTrigger : MonoBehaviour
{
    public GameObject bucket; // Referință către găleată
    public float targetY = -10f; // Y final unde ajunge găleata
    public float speed = 2f; // Viteza de ridicare

    private bool isMoving = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isMoving)
        {
            isMoving = true;
            StartCoroutine(MoveBucketUp());
        }
    }

    private System.Collections.IEnumerator MoveBucketUp()
    {
        while (bucket.transform.position.y < targetY)
        {
            bucket.transform.position += Vector3.up * speed * Time.deltaTime;
            yield return null;
        }
        
        Destroy(gameObject); // Șterge triggerul după ce găleata a ajuns sus
    }
}
