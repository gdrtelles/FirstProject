using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {

	public  GameObject Enemy;
	public  GameObject Player;
	private Vector2 offset;
	private float distance = 24f;
	public  bool inACoroutine = false;
	public  float spawnTime = 3f;

	
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
				float xrandomizer = Mathf.Sign (Random.Range (-1.0f, 1.0f));//used for picking left or right side to spawn
				float yrandomizer = Random.Range (-5.0f, 5.0f);//used for random distance on the y
				float rs = Random.Range (2.0f, 3.0f);
				rs = (rs * xrandomizer) + Player.transform.localScale.magnitude;
				distance = distance * xrandomizer;
				offset = new Vector2 (transform.position.x - distance, transform.position.y - yrandomizer);
				Instantiate (Enemy, offset, transform.rotation);
				Enemy.transform.localScale = new Vector3 (rs,rs,rs);
			
	}
	
}
