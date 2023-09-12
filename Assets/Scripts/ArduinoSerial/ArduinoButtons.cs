using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ArduinoButtons : MonoBehaviour
{
    public int Button1 ;
    public int Button2 ;
    public int Button3 ;
    public int Button4 ;

    void Awake()
    {
        Button1 = 0;
        Button2 = 0;
        Button3 = 0;
        Button4 = 0;
    }


    void OnSerialLine(string line) { 
        Button1 = (int) Char.GetNumericValue(line[0]);
        Button2 = (int) Char.GetNumericValue(line[1]);
        Button3 = (int) Char.GetNumericValue(line[2]);
        Button4 = (int) Char.GetNumericValue(line[3]);
	}
}
