using UnityEngine;

// This class handles the player's health and life count.
public class PlayerHealth : MonoBehaviour
{
    // The maximum number of lives the player can have.
    public int maxLives = 3;
    

    // The current number of lives the player has.
    private int currentLives;

    //Start is called before the first frame update
    void start()
    {
        //Initialize the currentLives to the maximum lives at the start of the game.
        currentLives = maxLives;
    }

    //Method to apply damage to the player
    public void TakeDamage(int damageAmount)
    {
        //Reduce the current lives by the damage amount
        currentLives -= damageAmount;

        //Log the current number of Lives to the console for debugging purposes.
        Debug.Log("Player Lives: " + currentLives);

        //Check if thr player's death scenario
        Debug.Log("Player Died");

    
    }
}