using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	// Use this for initialization
	private Transform spawnpoint;
	public  float moveSpeed = 4.0f;
	public  float xDistance = 8f;
	private float playerSize;
	private float enemySize;
	private Transform player;


	void Awake()
	{
		// Setting up the reference.
		spawnpoint = GameObject.FindGameObjectWithTag("spawnPoint").transform;
		player = GameObject.FindGameObjectWithTag ("player").transform;
	
	}

	void Start ()
	{
		rigidbody2D.velocity = new Vector2(transform.localScale.x *( moveSpeed * CheckDirection()), rigidbody2D.velocity.y);
	}
	
	void FixedUpdate ()
	{
		if (CheckXDistance())
				Destroy (this.gameObject);

		playerSize = player.transform.localScale.magnitude;
		enemySize = transform.localScale.magnitude;
	}


	float CheckDirection()
	{
		return Mathf.Sign(spawnpoint.position.x - transform.position.x );
	}

	bool CheckXDistance()
	{
		return Mathf.Abs(transform.position.x - spawnpoint.position.x) > xDistance;
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		
		
		if (col.gameObject.tag == "player") 
		{
			if (playerSize > enemySize)
			{
				player.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
				Destroy(this.gameObject);
			}
		}	
	}

}