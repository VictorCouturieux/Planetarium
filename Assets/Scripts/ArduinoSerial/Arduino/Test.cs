using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Test : MonoBehaviour
{
    void OnEnable()
    {
        Buttons.Button1Pushed += Test1;
    }

    void OnDisable()
    {
        Buttons.Button1Pushed -= Test1;
    }

    void Test1()
    {
        // Display your game over UI message or perform any other game over actions.
        Debug.Log("Je lance le son 1");
    }
}


