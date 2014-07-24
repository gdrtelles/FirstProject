using UnityEngine;
using System.Collections;

public class GameStarter : MonoBehaviour {

	bool triggered = false;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if(!triggered){
			GameObject menuObject = GameObject.FindGameObjectWithTag("Menu");
			MainMenu menu = null;
			if(menuObject != null)
				menu = menuObject.GetComponent<MainMenu>();

			triggered = true;
	
		}
	}
}