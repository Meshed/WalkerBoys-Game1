using UnityEngine;
using System.Collections;

public class scriptScreenWin : MonoBehaviour {
	void OnGUI () 
	{
		GUI.Label(new Rect(10, 10, 100, 40), "YOU WIN!!");
		
		if(GUI.Button(new Rect(10, 60, 90, 50), "Start Game"))
		{
			Application.LoadLevel("sceneLevel1");
		}
		if(GUI.Button(new Rect(10, 130, 90, 50), "Exit Game"))
		{
			Application.Quit();
		}
	}
}
