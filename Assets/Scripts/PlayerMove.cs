using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
   
    public float movespeed = 10;
    
    public float LeftRightSpeed = 10;

    void Update()
    {
        // Move the player forward continuously
        transform.Translate(Vector3.forward * Time.deltaTime * movespeed, Space.World);

        // Move left if 'A' or left arrow is pressed and player is within bounds
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (this.gameObject.transform.position.x > Environment.LeftSide)
            {
                 transform.Translate(Vector3.left * Time.deltaTime * LeftRightSpeed);
            }
        }

        // Move right if 'D' or right arrow is pressed and player is within bounds
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (this.gameObject.transform.position.x < Environment.RightSide)
            {
               transform.Translate(Vector3.left * Time.deltaTime * LeftRightSpeed * -1); 
            }
        }
    }
}
