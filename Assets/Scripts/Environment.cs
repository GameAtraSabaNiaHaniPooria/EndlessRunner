using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    // Defines the static left boundary of the environment
    public static float LeftSide = -14.5f; 
    // Defines the static right boundary of the environment
    public static float RightSide = 14.5f;
    
    // Holds the current left boundary value
    public float internalLeft;
    // Holds the current right boundary value
    public float internalRight;

    void Update()
    {
        // Assign static boundary values to internal variables each frame
        internalLeft = LeftSide;
        internalRight = RightSide;
    }
}
