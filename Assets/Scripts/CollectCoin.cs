using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    // When the player collides with the coin, increase the coin count and deactivate the coin
    void OnTriggerEnter(Collider other)
    {
        CollectableControl.coinCount += 1; // Increment the coin count
        this.gameObject.SetActive(false);  // Deactivate the coin object
    }
}
