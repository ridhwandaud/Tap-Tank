using UnityEngine;
using System.Collections;

public class StartMenu_ButtonFunctions : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		//If touch back on mobile
		if (Input.GetKeyDown (KeyCode.Escape)) { 
			Application.Quit (); //Quit 
		}
	}

	public void Rate(){
		//Put your URL
		Application.OpenURL ("https://play.google.com/store/apps/details?id=com.catgeargames.soakysky"); 
	}

	public void Play(){
		Application.LoadLevel ("LevelSelection"); //Load Game Scene
	}
}