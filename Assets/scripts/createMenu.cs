using UnityEngine;
using System.Collections;

public class createMenu : MonoBehaviour {
	public Object menuPrefab;

	

	void Start(){
		GameObject menu = GameObject.FindGameObjectWithTag("Menu");
		if(menu == null){
			GameObject newMenu = (GameObject)Instantiate(menuPrefab, new Vector3(0, 0, 0), Quaternion.identity);
			newMenu.name = "Menu";

		}
	}
}