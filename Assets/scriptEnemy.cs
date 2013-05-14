using UnityEngine;
using System.Collections;

public class scriptEnemy : MonoBehaviour {
	public Color[] shapeColor;
	public int numberOfClicks = 2;
	public float respawnWaitTime = 2.0f;
	public Transform explosion;
	public int enemyPoint = 1;
	
	private int storeClicks = 0;
	
	void Start()
	{
		storeClicks = numberOfClicks;
		Vector3 startPosition = new Vector3(Random.Range(-6, 6), Random.Range(-4, 4), 0);
		transform.position = startPosition;
		ChangeGameObjectMaterialToRandomColor();
	}
	
	void Update () 
	{
		if (numberOfClicks <= 0) 
		{
			if(explosion)
			{
				Transform temp = (Transform)Instantiate(explosion, transform.position, transform.rotation);
				Destroy(temp.gameObject, temp.particleSystem.duration + temp.particleSystem.startLifetime);
			}
			
			Vector3 position = new Vector3(Random.Range(-6, 6), Random.Range(-4, 4), 0);
			StartCoroutine(HideGameObjectForSetTime());
			transform.position = position;			
			numberOfClicks = storeClicks;
		}
	}
	
	IEnumerator HideGameObjectForSetTime()
	{
		renderer.enabled = false;
		ChangeGameObjectMaterialToRandomColor();
		yield return new WaitForSeconds(respawnWaitTime);
		renderer.enabled = true;
	}
	
	void ChangeGameObjectMaterialToRandomColor()
	{
		if(shapeColor.Length > 0)
		{
			int newColor = Random.Range(0, shapeColor.Length);
			renderer.material.color = shapeColor[newColor];
		}
	}
}
