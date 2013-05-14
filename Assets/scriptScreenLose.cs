using UnityEngine;
using System.Collections;

public class scriptScreenLose : MonoBehaviour {
	void OnGUI () 
	{
		GUI.Label(new Rect(10, 10, 100, 40), "YOU LOSE!!");
		
		if(GUI.Button(new Rect(10, 60, 100, 50), "Restart Game"))
		{
			Application.LoadLevel("sceneLevel1");
		}
		if(GUI.Button(new Rect(10, 130, 100, 50), "Exit Game"))
		{
			Application.Quit();
		}
	}
}
