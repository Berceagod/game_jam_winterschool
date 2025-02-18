using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float aheadDistance = 2f;
    [SerializeField] private float cameraSpeed = 5f;
    private float lookAhead;
    private float currentVelocity = 0f;
    [SerializeField] private float smoothTime = 0.2f; // Adjust this for smoothness

    private void Update()
    {
        float targetLookAhead = aheadDistance * player.localScale.x;
        lookAhead = Mathf.SmoothDamp(lookAhead, targetLookAhead, ref currentVelocity, smoothTime);

        transform.position = new Vector3(player.position.x + lookAhead, transform.position.y, transform.position.z);
    }
}
