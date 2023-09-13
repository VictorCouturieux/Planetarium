using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class ArduinoButtons : MonoBehaviour
{
    public int Button1 ;
    public int Button2 ;
    public int Button3 ;
    public int Button4 ;
    private int PrevButton1 ;
    private int PrevButton2 ;
    private int PrevButton3 ;
    private int PrevButton4 ;

    [SerializeField] private UnityEvent Button1Pushed;
    [SerializeField] private UnityEvent Button2Pushed;
    [SerializeField] private UnityEvent Button3Pushed;
    [SerializeField] private UnityEvent Button4Pushed;

    void Awake()
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

        if (Button1 ==1 && PrevButton1==0 ){
            Button1Pushed.Invoke();
        }
        if (Button2 ==1 && PrevButton2==0 ){
            Button2Pushed.Invoke();
        }
        if (Button3 ==1 && PrevButton3==0 ){
            Button3Pushed.Invoke();
        }
        if (Button4 ==1 && PrevButton4==0 ){
            Button4Pushed.Invoke();
        }
	}
}
