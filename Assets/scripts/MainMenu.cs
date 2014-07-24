using UnityEngine;
using System;
using System.Collections;
//using System.Collections.Generic;

public class MainMenu : MonoBehaviour {
	public GUISkin mySkin;
	
	public enum gameScenes {none, cellMode, iceMode};
	public gameScenes gameScene = gameScenes.none;

	private Score highscore;


	public enum menuState {mainMenu, optionsMenu, credits, pauseMenu, pauseOptions, game, score, blank};
	public menuState currentState = menuState.mainMenu;

	
	string lastTooltip = "";

	float endTime;
	bool showTutorial = true;

	
	void Start(){


		DontDestroyOnLoad(gameObject);
		highscore = GameObject.Find("Score").GetComponent<Score>();

	
	}
	
	void Update(){

		
		if(Input.GetKeyDown(KeyCode.Escape)){
			print ("hey its working");
			if(currentState == menuState.game){
				Time.timeScale = 0;
				currentState = menuState.pauseMenu;
				print ("hey its working");
			}
			else if(currentState == menuState.pauseMenu || currentState == menuState.pauseOptions){
				Time.timeScale = 1;
				currentState = menuState.game;
			}
		}
		

	}
	
	// Ends play of the current game.
	public void EndGame(){
		// Pause the game and show the scoreboard.
		Time.timeScale = 0;
		currentState = menuState.score;


	}
	
	void OnGUI(){

		GUI.skin = mySkin;
	
		
		//float tempTime = 0;
		switch(currentState){
		case menuState.mainMenu:

			GUILayout.BeginArea(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 50, 200, 150));
			GUILayout.BeginVertical();
			if(GUILayout.Button(new GUIContent("Cell Level","Button"))){

				Application.LoadLevel("cell_Level");
				gameScene = gameScenes.cellMode;
				currentState = menuState.game;
				Time.timeScale = 1;
			}
			//if(GUILayout.Button(new GUIContent("Ice Level", "Button"))){

				//Application.LoadLevel("ice_Level");
				//gameScene = gameScenes.iceMode;
				//currentState = menuState.game;
				//Time.timeScale = 1;
		//	}
			if(GUILayout.Button(new GUIContent("Credits", "Button"))){	
				currentState = menuState.credits;
			}
			GUILayout.EndVertical();
			GUILayout.EndArea();
			break;
		case menuState.credits:
			GUILayout.BeginArea(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 100, 200, 400));
			GUILayout.BeginVertical();
			GUILayout.Box ("Ruben Telles");
			GUILayout.Box ("Jun Bae");
			GUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();
			if(GUILayout.Button(new GUIContent("Return", "Button"), GUILayout.Width(100))){
				currentState = menuState.mainMenu;
				//soundSelect.Play();
			}
			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();
			GUILayout.EndVertical();
			GUILayout.EndArea();
			break;
			// During Gameplay Menu
		case menuState.game:
			// Menu button that accesses the pause menu.
			GUILayout.BeginArea(new Rect(Screen.width - 70, Screen.height - 580, 52, 52));
			if(GUILayout.Button(new GUIContent("ii", "Button"))){
				Time.timeScale = 0;
				currentState = menuState.pauseMenu;
			}
			GUILayout.EndArea();
			
		
			if(gameScene == gameScenes.cellMode){
				GUILayout.BeginArea(new Rect(Screen.width / 2 - 50, 0, 100, 100));
				GUILayout.BeginVertical();
				GUILayout.EndVertical();
				GUILayout.EndArea();
			}

			if(gameScene == gameScenes.iceMode){
				GUILayout.BeginArea(new Rect(Screen.width / 2 - 50, 0, 100, 100));
				GUILayout.BeginVertical();
				GUILayout.EndVertical();
				GUILayout.EndArea();
			}
			break;
			
		case menuState.pauseMenu:
			if(gameScene == gameScenes.cellMode){
				GUILayout.BeginArea(new Rect(Screen.width / 2 - 50, 0, 100, 100));
				GUILayout.BeginVertical();
				GUILayout.EndVertical();
				GUILayout.EndArea();	
			}

			if(gameScene == gameScenes.iceMode){
				GUILayout.BeginArea(new Rect(Screen.width / 2 - 50, 0, 100, 100));
				GUILayout.BeginVertical();
				GUILayout.EndVertical();
				GUILayout.EndArea();	
			}
			GUI.Box(new Rect(Screen.width / 2 - 125, Screen.height / 2 - 135, 250, 260), "");
			GUILayout.BeginArea(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 200));
			GUILayout.BeginVertical();	
			//GUILayout.Box("Paused");
			if(GUILayout.Button(new GUIContent("Resume", "Button"))){
				Time.timeScale = 1;
				currentState = menuState.game;
			}
			if(GUILayout.Button(new GUIContent("Options", "Button"))){
				currentState = menuState.pauseOptions;
			}
			if(GUILayout.Button(new GUIContent("Main Menu", "Button"))){
				Time.timeScale = 1;
				Application.LoadLevel("MainMenu");
				gameScene = gameScenes.none;
				currentState = menuState.mainMenu;
			}
			GUILayout.EndVertical();
			GUILayout.EndArea();
			break;
		case menuState.pauseOptions:
			GUILayout.BeginArea(new Rect(Screen.width / 2 - 100, Screen.height - 200, 200, 400));
			GUILayout.BeginVertical();
			GUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();
			GUILayout.Box("Options", GUILayout.Width(100));
			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();
			GUILayout.Box("Global Volume: " + string.Format("{0:0.00}", AudioListener.volume));
			AudioListener.volume = GUILayout.HorizontalSlider(AudioListener.volume, 0.0f, 1.0f);
			GUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();
			if(GUILayout.Button(new GUIContent("Go Back", "Button"))){
				currentState = menuState.pauseMenu;
				//soundSelect.Play();
			}
			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();
			GUILayout.EndVertical();
			GUILayout.EndArea();
			break;
		case menuState.score:
			GUILayout.BeginArea(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 150, 300, 200));
			GUILayout.BeginVertical();
			GUILayout.Box("Game Over");
			if(gameScene == gameScenes.cellMode)
			{
				GUILayout.Box("HighScore: " + PlayerPrefs.GetInt("cell Score"));
				if(GUILayout.Button(new GUIContent("Replay", "Button")))
				{
					Application.LoadLevel("cell_Level");
					gameScene = gameScenes.cellMode;
					currentState = menuState.game;
					Time.timeScale = 1;
				}
			}
			else if(gameScene == gameScenes.iceMode)
			{
				GUILayout.Box("HighScore: " + PlayerPrefs.GetInt("ice Score"));
				if(GUILayout.Button(new GUIContent("Replay", "Button")))
				{
					Application.LoadLevel("ice_Level");
					gameScene = gameScenes.iceMode;
					currentState = menuState.game;
					Time.timeScale = 1;
				}
			
			}

			if(GUILayout.Button(new GUIContent("Main Menu", "Button"))){
				Application.LoadLevel("MainMenu");
				gameScene = gameScenes.none;
				currentState = menuState.mainMenu;
			
			}
			GUILayout.EndVertical();
			GUILayout.EndArea();
			break;
		}
		
		if(Event.current.type == EventType.Repaint && GUI.tooltip != lastTooltip) {
			if (lastTooltip != "")
				SendMessage(lastTooltip + "OnMouseOut", SendMessageOptions.DontRequireReceiver);
			
			if (GUI.tooltip != "")
				SendMessage(GUI.tooltip + "OnMouseOver", SendMessageOptions.DontRequireReceiver);
			
			lastTooltip = GUI.tooltip;
		}
		GUI.skin = null;
	}
	
	void ButtonOnMouseOver(){
	}


}

