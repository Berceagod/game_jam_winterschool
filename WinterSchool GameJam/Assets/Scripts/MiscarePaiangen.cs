using UnityEngine;

public class PatrolMovement : MonoBehaviour
{
    public float speed = 8f; // Patrol speed
    public float minX = 0f; // Left patrol limit
    public float maxX = 10f; // Right patrol limit

    private bool movingRight = true; // Track movement direction

    void Update()
    {
        // Move object in the current direction
        float move = (movingRight ? speed : -speed) * Time.deltaTime;
        transform.position += new Vector3(move, 0, 0);

        // Check if we reached the patrol limits
        if (transform.position.x >= maxX)
        {
            movingRight = false; // Change direction to left
        }
        else if (transform.position.x <= minX)
        {
            movingRight = true; // Change direction to right
        }
    }
}
