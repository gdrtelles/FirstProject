using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {
			

	private float moveForce = 365f;			// Amount of force added to move the player left and right.
	private float maxSpeed = 5f;				// The fastest the player can travel in the x axis.
	public bool powerActive = false;
	public bool speedActive = false;
	public bool dpointsActive = false;
	public bool invincActive = false;
	public float timeLeftI = 0.0f;
	public float timeLeftS = 0.0f;
	public float timeLeftX = 0.0f;
	public ParticleSystem invincible, bubble, speed;
	public ParticleSystem dpoints;
	public ParticleSystem shiny1, shiny2, shiny3;
	public bool OnorOff = true;
	private SpriteRenderer invinc;
	private SpriteRenderer speedPower;
	private SpriteRenderer xpower;
	private AudioSource speedSound;
	private AudioSource dxSound;
	private AudioSource invinceSound;
	public AudioSource backSound;

	public AudioClip bubble1;
	public AudioClip bubble2;
	public AudioClip bubble3;




	void Awake()
	{

		invincible = GameObject.Find("Invincible").GetComponent<ParticleSystem>();
		bubble = GameObject.Find("circlething").GetComponent<ParticleSystem>();
		speed = GameObject.Find("speed").GetComponent<ParticleSystem>();
		dpoints = GameObject.Find ("2x").GetComponent<ParticleSystem> ();
		invinc = GameObject.Find ("invincibility").GetComponent<SpriteRenderer> ();
		speedPower = GameObject.Find ("speedUp").GetComponent<SpriteRenderer> ();
		xpower = GameObject.Find ("2xPower").GetComponent<SpriteRenderer> ();
		speedSound = GameObject.Find ("speedUp").GetComponent<AudioSource> ();
		dxSound = GameObject.Find ("2xPower").GetComponent<AudioSource> ();
		invinceSound = GameObject.Find ("invincibility").GetComponent<AudioSource> ();
		backSound = GameObject.Find ("cellSong").GetComponent<AudioSource> ();
		shiny1 = GameObject.Find ("shiny1").GetComponent<ParticleSystem> ();
		shiny2 = GameObject.Find ("shiny2").GetComponent<ParticleSystem> ();
		shiny3 = GameObject.Find ("shiny3").GetComponent<ParticleSystem> ();


	

	


		//invinc.enabled = false;
		invinc.color = Color.grey;
		speedPower.color = Color.grey;
		xpower.color = Color.grey;
		invincible.Pause ();
		speed.Pause ();
		dpoints.Pause ();
		shiny1.Pause ();
		shiny2.Pause ();
		shiny3.Pause ();


	}


	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "powerUp") 
		{
			invincible.startSize = (transform.localScale.magnitude)*0.25f;
			bubble.startSize = (transform.localScale.magnitude)*0.8f;
			speed.transform.localScale = (transform.localScale)*0.25f;
		
		
			int choice = Random.Range(1,10);
			if(choice < 3)
			{
				invinc.color = Color.white;
				shiny1.Play ();

				//powerActive = true;
				//timeLeftI = 15.0f;
				//invincible.Play ();
			}
			else if (choice > 7)
			{
				speedPower.color = Color.white;
				shiny2.Play();
				//speedActive = true;
				//timeLeftS = 20.0f;
				//speed.Play ();
			}
			else
			{
				xpower.color = Color.white;
				shiny3.Play();
			}
		}
	//	else if(col.gameObject.tag == "enemy") 
		//{


		//}
	}


	
	void Update()
	{
		timeLeftI -= Time.deltaTime;
		timeLeftS -= Time.deltaTime;
		timeLeftX -= Time.deltaTime;
		
		if(timeLeftI < 0)
		{
			invincible.Pause ();
			invincible.Clear();
			invinceSound.audio.Pause();
			powerActive = false;
			timeLeftI = 0f;


		}
		if(timeLeftS < 0)
		{
			speed.Pause ();
			speed.Clear();
			speedSound.audio.Pause();
			speedActive = false;
			timeLeftS = 0f;

		
		}
		if(timeLeftX < 0)
		{
			dpoints.Pause();
			dpoints.Clear();
			dxSound.audio.Pause();
			dpointsActive = false;
			timeLeftX = 0f;
		

		}
	}
	
	void FixedUpdate() {

		if(!speedActive && !powerActive && !dpointsActive)
			backSound.audio.mute = false;
	

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

	public void bubblePopeffect()
	{
		int choice = Random.Range(1,3);
		if( choice == 1)
			audio.PlayOneShot(bubble1);
		else if ( choice == 2)
			audio.PlayOneShot(bubble2);
		else if ( choice == 3)
			audio.PlayOneShot(bubble3);

	}




}
