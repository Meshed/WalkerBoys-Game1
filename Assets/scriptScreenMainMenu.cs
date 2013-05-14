using UnityEngine;
using System.Collections;

public class scriptScreenMainMenu : MonoBehaviour {
	void OnGUI () 
	{
		if(GUI.Button(new Rect(10, 10, 90, 50), "Start Game"))
		{
			Application.LoadLevel("sceneLevel1");
		}
		if(GUI.Button(new Rect(10, 70, 90, 50), "Exit Game"))
		{
			Application.Quit();
		}
	}
}
