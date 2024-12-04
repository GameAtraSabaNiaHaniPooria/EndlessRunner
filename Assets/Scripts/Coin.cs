using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public int rotatespeed = 2;  

    void Update()
    {
        // Rotate the object around the Y-axis by the specified speed in world space
        transform.Rotate(0, rotatespeed, 0, Space.World);
    }
}
