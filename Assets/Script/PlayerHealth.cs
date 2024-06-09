using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    // Public variables to set maximum health and reference the health text UI
    public int maxHealth = 3;
    public TextMeshProUGUI healthText;

    // Private variables to manage current health and invincibility state
    private int currentHealth;
    private bool isInvincible = false;
    private float invincibilityDuration = 1.0f;
    private float invincibilityTimer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    // Update is called once per frame
    void Update()
    {
        // Handle invincibility timer
        if (isInvincible)
        {
            invincibilityTimer -= Time.deltaTime;
            if (invincibilityTimer <= 0)
            {
                isInvincible = false;
            }
        }
    }

    // Method to apply damage to the player
    public void TakeDamage(int damageAmount)
    {
        if (isInvincible)
        {
            Debug.Log("Player is invincible and cannot take damage.");
            return;
        }

        currentHealth -= damageAmount;
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Debug.Log("Player Died");
            GameOver();
        }
        else
        {
            Debug.Log("Player took damage, current health: " + currentHealth);
        }

        // Apply invincibility after taking damage
        isInvincible = true;
        invincibilityTimer = invincibilityDuration;
    }

    // Method to heal the player
    public void Heal(int healAmount)
    {
        currentHealth = Mathf.Min(currentHealth + healAmount, maxHealth);
        UpdateHealthUI();
    }

    // Method to update the health UI
    private void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth;
        }
        else
        {
            Debug.LogError("Health Text is not assigned!");
        }
    }

    // Method to handle game over
    private void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
