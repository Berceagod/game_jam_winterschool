using System.Collections;
using UnityEngine;

public class ZoomAndDropTrigger : MonoBehaviour
{
    public Camera mainCamera;  // Camera de joc
    public Transform bucket;   // Găleata (sprite-ul)
    public float targetZoom = 7f;  // Zoom-ul dorit
    public float zoomSpeed = 1f;  // Viteza de zoom
    public float bucketStartY = 5f;  // Poziția inițială Y a găleții
    public float bucketEndY = 0f;  // Poziția finală Y a găleții
    public float dropSpeed = 2f;  // Viteza de coborâre a găleții
    private bool triggered = false;  // Asigură că se activează doar o dată

    void Start()
    {
        if (bucket != null)
        {
            Vector3 pos = bucket.position;
            pos.y = bucketStartY;
            bucket.position = pos; // Setăm găleata la poziția inițială
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!triggered && other.CompareTag("Player")) // Asigură că doar playerul declanșează trigger-ul
        {
            triggered = true;
            StartCoroutine(ZoomOutAndDrop());
        }
    }

    IEnumerator ZoomOutAndDrop()
    {
        // Zoom Out Camera
        float initialZoom = mainCamera.orthographicSize;
        float elapsedTime = 0f;

        while (mainCamera.orthographicSize < targetZoom)
        {
            elapsedTime += Time.deltaTime * zoomSpeed;
            mainCamera.orthographicSize = Mathf.Lerp(initialZoom, targetZoom, elapsedTime);
            yield return null;
        }

        // Coborârea găleții
        while (bucket.position.y > bucketEndY)
        {
            bucket.position -= new Vector3(0, dropSpeed * Time.deltaTime, 0);
            yield return null;
        }

        // După ce găleata a ajuns jos, distrugem trigger-ul
        Destroy(gameObject);

        // O variantă dacă vrei să revii la zoom inițial după eveniment
        // yield return new WaitForSeconds(2); // Pauză înainte de revenire
        // elapsedTime = 0f;
        // while (mainCamera.orthographicSize > initialZoom)
        // {
        //     elapsedTime += Time.deltaTime * zoomSpeed;
        //     mainCamera.orthographicSize = Mathf.Lerp(targetZoom, initialZoom, elapsedTime);
        //     yield return null;
        // }
    }
}
