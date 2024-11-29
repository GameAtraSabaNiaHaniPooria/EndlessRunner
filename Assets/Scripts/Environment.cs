using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    public static float LeftSide = -3.5f;
    public static float RightSide = 3.5f;
    public float internalLeft;
    public float internalRight;

    void Update()
    {
        internalLeft = LeftSide;
        internalRight = RightSide;
    }
}