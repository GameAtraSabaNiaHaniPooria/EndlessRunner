using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableControl : MonoBehaviour
{
    public static int coinCount;  
    public GameObject coinTotal; 
    public GameObject coinCountDisplay; 
    public static int highScore; 
    public GameObject highScoreDisplay;

    void Start()
    {
        // Load the high score from PlayerPrefs, default is 0 if not set
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    void Update()
    {
        // Update UI elements to display current coin count
        coinCountDisplay.GetComponent<Text>().text = coinCount.ToString();
        coinTotal.GetComponent<Text>().text = coinCount.ToString();

        // If the current coin count exceeds the high score, update it
        if (coinCount > highScore)
        {
            highScore = coinCount;  

            // Save the new high score in PlayerPrefs
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save(); 
        }

        // Update the UI element to display the current high score
        highScoreDisplay.GetComponent<Text>().text = highScore.ToString();
    }
}
