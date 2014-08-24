using UnityEngine;
using System.Collections;

public class mouseControls : MonoBehaviour {


	private Animator anim;
	private bool wasClicked;
	private SpriteRenderer activePower;
	private PlayerControls state;
	int enterAnim = Animator.StringToHash("entered");
	int exitAnim = Animator.StringToHash("exited");

	// Use this for initialization
	void Awake()
	{
		// Setting up the reference.
	
		anim = GameObject.Find ("invincibility").GetComponent<Animator> ();
		state = GameObject.Find("Player").GetComponent<PlayerControls>();
		activePower = gameObject.GetComponent<SpriteRenderer> ();

		
		
	}

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseEnter()
	{
		if(activeCheck())
			anim.SetTrigger(enterAnim);
	

	}
	void OnMouseOver()
	{
		if (wasClicked && activeCheck()) 
		{
			anim.SetTrigger(exitAnim);
			powerChecker();
		}
	}

	void OnMouseExit()
	{
		if(activeCheck())
			anim.SetTrigger(exitAnim);
	
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
			state.invincible.Play();
			activePower.color = Color.grey;
		}
	}
}
