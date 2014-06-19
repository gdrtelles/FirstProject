using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {
	public GameObject Enemy;
	public Transform spawnPoint;
	private Vector2 offset;
	public float distance = 10;
	
	void Update ()
	{
		//spawnEnemy();
		
	}

	
	// spawns an enemy 
	private void spawnEnemy()
	{
		float randomizer = Mathf.Sign(Random.Range(-1.0f,1.0f));
		distance = distance * randomizer;
		offset = new Vector2 (spawnPoint.position.x - distance , transform.position.y);
		Instantiate(Enemy, offset, transform.rotation);
	}
	
	
}
