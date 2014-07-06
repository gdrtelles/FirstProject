using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	// Use this for initialization
	private Transform spawnpoint;
	public  float moveSpeed = 4.0f;
	public  float xDistance = 26f;
	private float playerSize;
	private float enemySize;
	private Transform player;
	private Score highscore;
	public Sprite M_left;
	public Sprite M_right;


	void Awake()
	{
		// Setting up the reference.
		spawnpoint = GameObject.FindGameObjectWithTag("spawnPoint").transform;
		player = GameObject.FindGameObjectWithTag ("player").transform;
		highscore = GameObject.Find("Score").GetComponent<Score>();
	
	}

	void Start ()
	{
		rigidbody2D.velocity = new Vector2(transform.localScale.x *( moveSpeed * CheckDirection()), rigidbody2D.velocity.y);
		if (rigidbody2D.velocity.x < 0) 
		{
			gameObject.GetComponent<SpriteRenderer> ().sprite = M_left;
		} 
		else if (rigidbody2D.velocity.x > 0) 
		{
			gameObject.GetComponent<SpriteRenderer> ().sprite = M_right;
		}
	}
	
	void FixedUpdate ()
	{
		if (CheckXDistance())
				Destroy (this.gameObject);

		//playerSize = player.transform.localScale.magnitude;
		//enemySize = transform.localScale.magnitude;
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
			if (player.transform.localScale.magnitude > transform.localScale.magnitude)
			{
				player.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
				Destroy(this.gameObject);
				// Increase the score by 100 points
				highscore.score += 100;
			}
			else if(player.transform.localScale.magnitude < transform.localScale.magnitude)
			{
				Application.LoadLevel (0);
			}
		}	
	}

}