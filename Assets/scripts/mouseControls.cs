using UnityEngine;
using System.Collections;

public class mouseControls : MonoBehaviour {


	private Animator anim;
	private Animator anim2;
	private Animator anim3;
	private bool wasClicked;
	private SpriteRenderer activePower;
	private PlayerControls state;
	public GUISkin mySkin;
	public AudioClip speed;
	//public AudioClip invince;
	int enterAnim = Animator.StringToHash("entered");
	int exitAnim = Animator.StringToHash("exited");

	// Use this for initialization
	void Awake()
	{
		// Setting up the reference.
	
		anim = GameObject.Find ("invincibility").GetComponent<Animator> ();
		anim2 = GameObject.Find ("speedUp").GetComponent<Animator> ();
		anim3 = GameObject.Find ("2xPower").GetComponent<Animator> ();
		state = GameObject.Find("Player").GetComponent<PlayerControls>();
		activePower = gameObject.GetComponent<SpriteRenderer> ();

		
		
	}

	void Start () {
	
	}

	void OnGUI()
	{
		GUI.skin = mySkin;
		//GUI.color = Color.Lerp(Color.red, Color.green, (state.timeLeftI/ 15f));
		//GUI.Button(new Rect(Screen.width - 170, Screen.height - 180, (state.timeLeftI / 15f) * 188, 52), GUIContent.none, "ProgressBar");
		//GUI.color = Color.white;
		//GUILayout.BeginArea(new Rect(Screen.width - 70, Screen.height - 180, (state.timeLeftI / 15f) * 188, 52));
		//GUILayout.Button (new GUIContent ("ii", "Button"));
		GUI.Label(new Rect(Screen.width - 140, Screen.height - 520, (state.timeLeftI / 15f) * 50, 12), "");
		GUI.Label(new Rect(Screen.width - 245, Screen.height - 520, (state.timeLeftS / 20f) * 65, 12), "");
		GUI.Label (new Rect (Screen.width - 340, Screen.height - 520, (state.timeLeftX / 25f) * 65, 12), "");
		//GUILayout.EndArea();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseEnter()
	{
		if(activeCheck())
		{
			switch(gameObject.name)
			{
			case "invincibility":
				anim.SetTrigger(enterAnim);
				break;
			case "speedUp":
				anim2.SetTrigger(enterAnim);
				break;
			case "2xPower":
				anim3.SetTrigger(enterAnim);
				break;
			}
		}

	}
	void OnMouseOver()
	{
		if (wasClicked && activeCheck()) 
		{
			switch(gameObject.name)
			{
			case "invincibility":
				anim.SetTrigger(exitAnim);
		
				break;
			case "speedUp":
				anim2.SetTrigger(exitAnim);

				break;
			case "2xPower":
				anim3.SetTrigger(exitAnim);
			
				break;
			}
			powerChecker();
		}
	}

	void OnMouseExit()
	{
		if(activeCheck())
		{
			switch(gameObject.name)
			{
				case "invincibility":
					anim.SetTrigger(exitAnim);
					break;
				case "speedUp":
					anim2.SetTrigger(exitAnim);
					break;
				case "2xPower":
					anim3.SetTrigger(exitAnim);
					break;
			}
		}
	}

	void OnMouseDown()
	{
		wasClicked = true;
	}

	void OnMouseUp()
	{
		wasClicked = false;
	}

	bool activeCheck()
	{
		if (activePower.color == Color.white)
				return true;
		else
				return false;

	}

	void powerChecker()
	{
		if (gameObject.name == "invincibility") 
		{
			state.timeLeftI = 15f;
			state.powerActive = true;
			state.shiny1.Pause();
			state.shiny1.Clear();
			audio.Play();
			state.invincible.Play();
			activePower.color = Color.grey;
			state.backSound.audio.mute = true;
		}
		else if( gameObject.name  == "speedUp")
		{
			state.timeLeftS = 20f;
			state.speedActive = true;
			state.shiny2.Pause();
			state.shiny2.Clear();
			audio.Play();
			state.speed.Play();
			activePower.color = Color.grey;
			//state.backSound.audio.Pause ();
			state.backSound.audio.mute = true;

		}
		else if( gameObject.name  == "2xPower")
		{
			state.timeLeftX = 25f;
			state.dpointsActive = true;
			state.shiny3.Pause();
			state.shiny3.Clear();
			audio.Play();
			state.dpoints.Play();
			activePower.color = Color.grey;
			//state.backSound.audio.Pause ();
			state.backSound.audio.mute = true;
			
		}
	}
}
