using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public delegate void ButtonPushedDelegate();
    public static event ButtonPushedDelegate Button1Pushed;
    public static event ButtonPushedDelegate Button2Pushed;
    public static event ButtonPushedDelegate Button3Pushed;
    public static event ButtonPushedDelegate Button4Pushed;

    public int Button1 ;
    public int Button2 ;
    public int Button3 ;
    public int Button4 ;
    private int PrevButton1 ;
    private int PrevButton2 ;
    private int PrevButton3 ;
    private int PrevButton4 ;

    void Start()
    {
        Button1 = 0;
        Button2 = 0;
        Button3 = 0;
        Button4 = 0;
        PrevButton1 = 0;
        PrevButton2 = 0;
        PrevButton3 = 0;
        PrevButton4 = 0;
    }

    void OnSerialLine(string line) {
        PrevButton1 = Button1 ;
        PrevButton2 = Button2;
        PrevButton3 = Button3;
        PrevButton4 = Button4;
        Button1 = (int) Char.GetNumericValue(line[0]);
        Button2 = (int) Char.GetNumericValue(line[1]);
        Button3 = (int) Char.GetNumericValue(line[2]);
        Button4 = (int) Char.GetNumericValue(line[3]);

        HandleButtonChanges();
	}

    void HandleButtonChanges()
    {
        if (Button1 ==1 && PrevButton1==0 ){
            Debug.Log("Button 1 has been pushed!");
            Button1Pushed?.Invoke();
        }
        if (Button2 ==1 && PrevButton2==0 ){
            Debug.Log("Button 2 has been pushed!");
            Button2Pushed?.Invoke();
        }
        if (Button3 ==1 && PrevButton3==0 ){
            Debug.Log("Button 3 has been pushed!");
            Button3Pushed?.Invoke();
        }
        if (Button4 ==1 && PrevButton4==0 ){
            Debug.Log("Button 4 has been pushed!");
            Button4Pushed?.Invoke();
        }
    }
}