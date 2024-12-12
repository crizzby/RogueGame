using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectilePrefab; // Reference to the projectile prefab

    // Update is called once per frame
    void Update()
    {
        // Check if the left mouse button is pressed 
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0.0f; // Ensure the z-coordinate is 0.0f

            Vector2 direction = (mousePosition - (Vector3)transform.position).normalized;

            GameObject newProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

            Rigidbody2D rb = newProjectile.GetComponent<Rigidbody2D>();
            rb.velocity = direction * 10f; // Adjust the speed as needed
        }
    }
}
