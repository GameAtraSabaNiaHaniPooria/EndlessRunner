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
        
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }
    void Update()
    {
        coinCountDisplay.GetComponent<Text>().text = coinCount.ToString();
        coinTotal.GetComponent<Text>().text = coinCount.ToString(); 
        if (coinCount > highScore)
        {
            highScore = coinCount;

          
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }

        
        highScoreDisplay.GetComponent<Text>().text = highScore.ToString();
    }
}
