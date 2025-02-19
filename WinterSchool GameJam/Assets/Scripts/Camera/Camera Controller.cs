using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float aheadDistanceRight = 2f;
    [SerializeField] private float aheadDistanceUp = 1f;
    [SerializeField] private float cameraSpeed = 5f;
    private float lookAheadX;
    private float lookAheadY;

    private float velocityX = 0f;
    private float velocityY = 0f;

    [SerializeField] private float smoothTime = 0.2f; // Adjust for smoothness

    private void Update()
    {
        // Calculate target offsets based on player's scale
        float targetLookAheadX = aheadDistanceRight * Mathf.Sign(player.localScale.x);
        float targetLookAheadY = aheadDistanceUp * Mathf.Sign(player.localScale.y);

        // Smoothly transition the look-ahead values
        lookAheadX = Mathf.SmoothDamp(lookAheadX, targetLookAheadX, ref velocityX, smoothTime);
        lookAheadY = Mathf.SmoothDamp(lookAheadY, targetLookAheadY, ref velocityY, smoothTime);

        // Update camera position while preserving the z-axis
        transform.position = new Vector3(
            player.position.x + lookAheadX,
            player.position.y + lookAheadY ,
            transform.position.z
        );
    }
}
