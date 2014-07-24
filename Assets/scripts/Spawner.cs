using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {

	public  GameObject Enemy1; //amino
	public  GameObject Enemy2; //mammoth
	public  GameObject Player;
	private Vector2 offset;
	private float distance = 24f;
	public  bool inACoroutine = false;
	public  float spawnTime = 3f;

	void Start()
	{
		Enemy1.transform.localScale = new Vector3 (1.0f,1.0f,1.0f);
		Enemy2.transform.localScale = new Vector3 (1.0f,1.0f,1.0f);
	}
	void Update ()
	{
		if(!inACoroutine){
			StartCoroutine("SpawnEnemies");
		}

	}
	

	IEnumerator SpawnEnemies(){
		inACoroutine = true;
		yield return new WaitForSeconds(spawnTime);
	
		spawnEnemy();

		inACoroutine = false;
	}

	private void spawnEnemy()
	{
		if (Application.loadedLevelName == "ice_Level") 
		{
			float xrandomizer = Mathf.Sign (Random.Range (-1.0f, 1.0f));//used for picking left or right side to spawn
			float yrandomizer = Random.Range (-5.0f, 5.0f);//used for random distance on the y
			float rs = Random.Range (1.5f, 2.5f);
			rs = (rs * xrandomizer) + Player.transform.localScale.magnitude;
			distance = distance * xrandomizer;
			offset = new Vector2 (transform.position.x - distance, transform.position.y - yrandomizer);
			Instantiate (Enemy2, offset, transform.rotation);
			Enemy2.transform.localScale = new Vector3 (rs,rs,rs);
		}
		else if(Application.loadedLevelName == "cell_Level")
		{

			float randomDegrees = Random.Range (0f, 360f);
			float x_onCircle = 15 * Mathf.Cos(randomDegrees * Mathf.PI/180);
			float y_onCircle = 15 * Mathf.Sin(randomDegrees * Mathf.PI/180);
			float rs = Random.Range (1.0f, 2.0f);
			float xrandomizer = Mathf.Sign (Random.Range (-1.0f, 1.0f));
			if(Player.transform.localScale.magnitude < 3.8f)
			{
				rs = (rs * xrandomizer) + Player.transform.localScale.magnitude;
			}
			else
			{
				rs = (rs * xrandomizer) + 3.8f;
			}

			offset = new Vector2(transform.position.x + x_onCircle,transform.position.y + y_onCircle);
			Instantiate(Enemy1, offset, transform.rotation);
			Enemy1.transform.localScale = new Vector3 (rs,rs,rs);
		
		

		}
				
			
	}
	
}
