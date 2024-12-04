using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleCollision : MonoBehaviour
{
   
    public GameObject thePlayer;
    public GameObject charmodel;
    
    
    public GameObject endscreen;
    public static bool isGameOver = false;

    void OnTriggerEnter(Collider other)
    {
        // Start the end game sequence when collision occurs
        StartCoroutine(EndGameSequence());
    }

    IEnumerator EndGameSequence()
    {
        // Disable collider and player movement
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        thePlayer.GetComponent<PlayerMove>().enabled = false;

        // Play the character's stumble animation
        charmodel.GetComponent<Animator>().Play("Stumble Backwards");

        // Wait for 1 second before showing the end screen
        yield return new WaitForSeconds(1);

        // Display the end screen and set game over state
        endscreen.SetActive(true);
        isGameOver = true;
       
        // Wait for another second before continuing
        yield return new WaitForSeconds(1);
    }

    // Restart the game by resetting variables and reloading the scene
    public void RestartGame()
    {
        CollectableControl.coinCount = 0; 
        isGameOver = false; // Reset game over state
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
}
