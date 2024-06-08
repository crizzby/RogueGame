using UnityEngine;

// This class controls an enemy shooter that fires projectiles at the player at regular intervals.
public class EnemyShooter : MonoBehaviour
{
    // Prefab of the projectile to be instantiated when shooting
    public GameObject projectilePrefab;

    // Reference to the player's transform to determine where to shoot
    public Transform player;

    // Speed at which the projectile will travel
    public float projectileSpeed = 5f;

    // Time interval between each shot
    public float shootInterval = 2f;

    // Timer to keep track of when to shoot next
    private float shootTimer;

    // Initialize the shootTimer to the shootInterval at the start
    void Start()
    {
        shootTimer = shootInterval;
    }

    // Update is called once per frame
    void Update()
    {
        // Decrease the shootTimer by the time that has passed since the last frame
        shootTimer -= Time.deltaTime;

        // Check if the timer has reached zero or less
        if (shootTimer <= 0f)
        {
            // Shoot a projectile at the player
            ShootAtPlayer();

            // Reset the shootTimer to the shootInterval
            shootTimer = shootInterval;
        }
    }

    // Method to shoot a projectile at the player
    void ShootAtPlayer()
    {
        // Calculate the direction from the enemy to the player and normalize it
        Vector2 direction = (player.position - transform.position).normalized;

        // Instantiate a new projectile at the enemy's position with no rotation
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        // Set the velocity of the projectile's Rigidbody2D component to make it move towards the player
        projectile.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;
    }
}
