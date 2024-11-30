using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject charmodel;
    public GameObject liveCoins;
    public GameObject endscreen;

    void OnTriggerEnter(Collider other)
    {
       
            StartCoroutine(EndGameSequence()); 
    }

    IEnumerator EndGameSequence()
    {
       
        this.gameObject.GetComponent<BoxCollider>().enabled = false;

        
        thePlayer.GetComponent<PlayerMove>().enabled = false;

      
        charmodel.GetComponent<Animator>().Play("Stumble Backwards");

       
        yield return new WaitForSeconds(5);

      
        liveCoins.SetActive(false);
        endscreen.SetActive(true);

       
        yield return new WaitForSeconds(5);
    }
}
