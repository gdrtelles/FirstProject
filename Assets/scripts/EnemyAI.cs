using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	// Use this for initialization
	private Transform spawnpoint;
	public  GameObject deathEffect;
	public  float moveSpeed = 4.0f;
	public  float xDistance = 26f;
	private float playerSize;
	private float enemySize;
	private Transform player;
	private Score highscore;
	private PlayerControls state;
	//private MainMenu scene;
	public Sprite M_left;
	public Sprite M_right;
	public Sprite cute_Amino;
	//public AudioClip bubble1;
	private Animator anim;
	//public ParticleSystem deathEffect;


	//Animator anim;
	int smileAnim = Animator.StringToHash("smile");


	void Awake()
	{
		// Setting up the reference.
		spawnpoint = GameObject.FindGameObjectWithTag("spawnPoint").transform;
		player = GameObject.FindGameObjectWithTag ("player").transform;
		highscore = GameObject.Find("Score").GetComponent<Score>();
		state = GameObject.Find("Player").GetComponent<PlayerControls>();
		anim = GameObject.Find ("smile").GetComponent<Animator> ();
		//deathEffect = GameObject.FindGameObjectWithTag ("peffect").particleSystem;

	
	
	}



	void Start ()
	{
	
		//anim = smile.GetComponent<Animator>();
		levelSetup ();
	}

	void FixedUpdate ()
	{
		if (CheckXDistance())
				Destroy (this.gameObject);
		if (state.powerActive) 
		{
			rigidbody2D.mass = 0f;
		}
		else
		{
			rigidbody2D.mass = 30f;
		}

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
			if (player.transform.localScale.magnitude + 0.3f >= transform.localScale.magnitude)
			{
				deathEffect.particleSystem.startSize = (transform.localScale.magnitude)*0.05f;
				Instantiate(deathEffect, transform.position, transform.rotation);

				
				//state.deathEffect.transform.position = transform.position;

				player.transform.localScale += new Vector3(0.025f, 0.025f, 0.025f);
				//state.deathEffect.Play();
				Destroy(this.gameObject);
				state.bubblePopeffect();
				// Increase the score by 100 points
				highscore.score += 100;
				if(state.dpointsActive) highscore.score += 100;
				anim.SetTrigger(smileAnim);

			
			}
			else if((player.transform.localScale.magnitude < transform.localScale.magnitude) && !state.powerActive)
			{
				updateHighScore();
				GameObject menuObject = GameObject.FindGameObjectWithTag("Menu");
				MainMenu menu = menuObject.GetComponent<MainMenu>();
				menu.EndGame();
			
			}
		
		}	
	}

	void levelSetup()
	{
		if (Application.loadedLevelName == "ice_Level") 
		{
			rigidbody2D.velocity = new Vector2 (transform.localScale.x * (moveSpeed * CheckDirection ()), rigidbody2D.velocity.y);
			Destroy(gameObject.collider2D);
			rigidbody2D.mass = 0;

			  
			if (rigidbody2D.velocity.x < 0) 
			{
				gameObject.GetComponent<SpriteRenderer> ().sprite = M_left;
				gameObject.AddComponent<PolygonCollider2D>();
			}
			else if (rigidbody2D.velocity.x > 0) 
			{
				gameObject.GetComponent<SpriteRenderer> ().sprite = M_right;
				gameObject.AddComponent<PolygonCollider2D>();
			}
		}
		else if(Application.loadedLevelName == "cell_Level")
		{
			//rigidbody2D.velocity = new Vector2 (transform.localScale.x * (moveSpeed * CheckDirection ()), rigidbody2D.velocity.y);
			moveSpeed = 12.0f;
			rigidbody2D.velocity = new Vector2 ((spawnpoint.transform.position.x - transform.position.x)/moveSpeed, (spawnpoint.transform.position.y - transform.position.y)/moveSpeed);
			gameObject.GetComponent<SpriteRenderer> ().sprite = cute_Amino;
		}
	}

	void updateHighScore()
	{

		if (Application.loadedLevelName == "ice_Level") 
		{
			if (highscore.score > PlayerPrefs.GetInt("ice Score"))
				PlayerPrefs.SetInt("ice Score", highscore.score);
	
		}
		else if(Application.loadedLevelName == "cell_Level")
		{
			if (highscore.score > PlayerPrefs.GetInt("cell Score"))
				PlayerPrefs.SetInt("cell Score", highscore.score);
		}
	}

}