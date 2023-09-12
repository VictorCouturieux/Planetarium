using UnityEngine;

public class SerialCommunicationArduino : MonoBehaviour
{
	void OnSerialLine(string line) { 
		Debug.Log ("Got a line: " + line); 
	}
}
