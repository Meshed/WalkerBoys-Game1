using UnityEngine;
using System.Collections;

public class scriptPlayer : MonoBehaviour
{
	public string tagName;
	public float rayDistance = 0f;
	public int score = 0;
	public float gameTimeRemaining = 20f;
	public float loadWaitTime = 3.0f;
	public int numberOfPointsToWin = 5;
	
	// Use this for initialization
	void Start ()
	{
		InvokeRepeating("CountDown", 1, 1);
	}

	// Update is called once per frame
	void Update ()
	{
		// use the mouse button to select on GameObjects in the scene
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast (ray, out hit, rayDistance)) {
				if (hit.transform.tag == tagName)
				{
					//Vector3 position = new Vector3(Random.Range(-6, 6), Random.Range(-4, 4), 0);
					//hit.transform.position = position;
					
					scriptEnemy enemyScript = hit.transform.GetComponent<scriptEnemy>();
					enemyScript.numberOfClicks -= 1;
					
					if(enemyScript.numberOfClicks == 0)
					{
						score += enemyScript.enemyPoint;
					}
				}
				else
				{
					print("This is not an enemy");
				}
			}
		}
	}
		
	void CountDown()
	{
		if(--gameTimeRemaining == 0)
		{
			CancelInvoke("CountDown");
			if(score >= numberOfPointsToWin)
			{
				Application.LoadLevel("sceneScreenWin");
			}
			else
			{
				Application.LoadLevel("sceneScreenLose");
			}
		}
	}
	
	void OnGUI()
	{
		GUI.Label(new Rect(10, 10, 100, 20), "Score: " + score);
		GUI.Label(new Rect(10, 25, 100, 35), "Time: " + gameTimeRemaining);
	}
}