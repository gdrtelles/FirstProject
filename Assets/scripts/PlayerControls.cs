using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {
			

	private float moveForce = 365f;			// Amount of force added to move the player left and right.
	private float maxSpeed = 5f;				// The fastest the player can travel in the x axis.
	public bool powerActive = false;
	public bool speedActive = false;
	public bool invincActive = false;
	public float timeLeftI = 0.0f;
	public float timeLeftS = 0.0f;
	public ParticleSystem invincible, bubble;
	public ParticleSystem speed;
	public bool OnorOff = false;
	private SpriteRenderer invinc;


	void Awake()
	{

		invincible = GameObject.Find("Invincible").GetComponent<ParticleSystem>();
		bubble = GameObject.Find("Bubble").GetComponent<ParticleSystem>();
		speed = GameObject.Find("speed").GetComponent<ParticleSystem>();
		invinc = GameObject.Find ("invincibility").GetComponent<SpriteRenderer> ();

		//invinc.enabled = false;
		invinc.color = Color.grey;
		invincible.Pause ();
		//bubble.Pause ();
		speed.Pause ();


	}


	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "powerUp") 
		{
			invincible.startSize = (transform.localScale.magnitude)*0.25f;
			bubble.startSize = (transform.localScale.magnitude)*0.8f;
			speed.transform.localScale = (transform.localScale)*0.25f;
		
		
			int choice = Random.Range(1,10);
			if(choice <= 5)
			{
				invinc.color = Color.white;

				//powerActive = true;
				//timeLeftI = 15.0f;
				//invincible.Play ();
			}
			else if (choice > 5)
			{
				speedActive = true;
				timeLeftS = 20.0f;
				speed.Play ();
			}
			
		}
	}


	
	void Update()
	{
		timeLeftI -= Time.deltaTime;
		timeLeftS -= Time.deltaTime;
		if(timeLeftI < 0)
		{
			invincible.Pause ();
			invincible.Clear();
			powerActive = false;

		}
		if(timeLeftS < 0)
		{
			speed.Pause ();
			speed.Clear();
			speedActive = false;
		
		}
	}
	
	void FixedUpdate() {


			if (Input.GetKeyDown (KeyCode.Space)) 
			{
				OnorOff = !OnorOff;
			} 
			//else if (Input.GetKeyDown (KeyCode.Space) && line.enabled == true) 
			//{
				//line.enabled = false;
			//}
			
			if (speedActive) 
			{
				moveForce = 7000f;
				maxSpeed = 10f;
				rigidbody2D.drag = 10f;
				
			}
			else 
			{
				moveForce = 365f;
				maxSpeed = 5f;
				rigidbody2D.drag = 1.5f;
				
			}
			float moveleft = Input.GetAxis("left");
			float moveright = Input.GetAxis("right");
			float moveup = Input.GetAxis("up");
			float movedown = Input.GetAxis("down");
			
			
			rigidbody2D.AddForce(-Vector2.right * moveleft * moveForce);
			rigidbody2D.AddForce(Vector2.right * moveright * moveForce);
			
			// If the player's horizontal velocity is greater than the maxSpeed...
			if(Mathf.Abs(rigidbody2D.velocity.x) > maxSpeed)
				// ... set the player's velocity to the maxSpeed in the x axis.
				rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);


			
			
			rigidbody2D.AddForce(Vector2.up * moveup * moveForce);
			rigidbody2D.AddForce(-Vector2.up * movedown * moveForce);
			
			// If the player's horizontal velocity is greater than the maxSpeed...
			if(Mathf.Abs(rigidbody2D.velocity.y) > maxSpeed)
				// ... set the player's velocity to the maxSpeed in the x axis.
				rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, Mathf.Sign(rigidbody2D.velocity.y) * maxSpeed);
			
			
	}



}
