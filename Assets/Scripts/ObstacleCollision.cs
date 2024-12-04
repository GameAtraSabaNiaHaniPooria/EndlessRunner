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
        StartCoroutine(EndGameSequence());
    }

    IEnumerator EndGameSequence()
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        thePlayer.GetComponent<PlayerMove>().enabled = false;
        charmodel.GetComponent<Animator>().Play("Stumble Backwards");
        yield return new WaitForSeconds(1);

        endscreen.SetActive(true);
        isGameOver = true;
       
        yield return new WaitForSeconds(1);
    }

 
    public void RestartGame()
    {
   
        CollectableControl.coinCount = 0;
        isGameOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
