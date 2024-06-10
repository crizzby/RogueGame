using UnityEngine;

// This class defines the behavior of a projectile in the game.
public class Projectile : MonoBehaviour
{
    // The amount of damage the projectile will deal to the player.
    public int damageAmount = 1;

    public float lifeTime = 3f;

    void Start()
    {
        Debug.Log("Projectile started with lifetime: " + lifeTime);
        Destroy(gameObject, lifeTime);
    }

    // This method is called when the projectile collides with another object.
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the object the projectile collided with has the tag "Player".
        if (collision.gameObject.CompareTag("Player"))
        {
            // Destroy the projectile when it hits the player.
            Destroy(gameObject);

            // Get the PlayerHealth component from the collided object.
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

            // If the PlayerHealth component is found on the collided object,
            // deal damage to the player by calling the TakeDamage method.
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }
}
