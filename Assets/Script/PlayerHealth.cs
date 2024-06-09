using UnityEngine;
using UnityEngine.UI;

// This class handles the player's health and life count.
public class PlayerHealth : MonoBehaviour
{
    // The maximum number of lives the player can have.
    public int maxLives = 3;
    // The current number of lives the player has.
    private int currentLives;
    //References to the UI Text element that displays the health
    public Text healthText;

    //Start is called before the first frame update
    void start()
    {
        //Initialize the currentLives to the maximum lives at the start of the game.
        currentLives = maxLives;
        UpdateHealthUI();
    }

    //Method to apply damage to the player
    public void TakeDamage(int damageAmount)
    {
        //Reduce the current lives by the damage amount
        currentLives -= damageAmount;

        if (currentLives <= 0)
        {
            Debug.Log("Player Died");
            GamerOver();
        }
    
    }

    private void UpdateHealthUI()
    {
        healthText.text = "Health: " + currentLives;
    }

    private void GamerOver()
    {
        //Restart the current scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

    void update()
    {
        //Position the health text at the top left corner of the camera's viewpoint
        Vector3 viewportPoint = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, Camera.main.nearClipPlane));
        healthText.transform.position = viewportPoint; 
    }
}