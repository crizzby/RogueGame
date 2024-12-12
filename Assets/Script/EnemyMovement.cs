using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Speed of the enemy movement
    public float speed = 2.0f;
    // Distance the enemy travels up and down
    public float height = 2.0f;

    // Initial position of the enemy
    private Vector2 initialPosition;

    void Start()
    {
        // Store the initial position
        initialPosition = transform.position;
    }

    void Update()
    {
        // Calculate new position based on sine wave
        Vector2 newPosition = initialPosition;
        newPosition.y += Mathf.Sin(Time.time * speed) * height;

        // Apply new position
        transform.position = newPosition;
    }
}
