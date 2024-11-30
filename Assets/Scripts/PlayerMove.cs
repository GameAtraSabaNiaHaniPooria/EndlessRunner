using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float movespeed = 5;
    public float LeftRightSpeed = 5;
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * movespeed, Space.World);
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (this.gameObject.transform.position.x > Environment.LeftSide)
            {
                 transform.Translate(Vector3.left * Time.deltaTime * LeftRightSpeed);
            }
           
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (this.gameObject.transform.position.x < Environment.RightSide)
            {
               transform.Translate(Vector3.left * Time.deltaTime * LeftRightSpeed * -1); 
            }
            
        }
    }
}