using System;
using UnityEngine;

public class SerialCommunicationCarpet : MonoBehaviour
{
    void OnSerialValues(string [] values) {
        String line = "";
        foreach (string val in values) {
            line = line + val;
        }
        Debug.Log ("Got a line: " + line); 
    }
}
