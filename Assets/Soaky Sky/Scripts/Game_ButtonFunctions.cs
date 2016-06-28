using UnityEngine;
using System.Collections;

public class Game_ButtonFunctions : MonoBehaviour {

	public void Rate(){
		//Put your URL
		Application.OpenURL ("https://play.google.com/store/apps/details?id=com.ridhwan.bouncingrabbit"); 
	}

	public void Pause(){
		GameController.instance.Pause (); //Pause Game
	}

	public void Resume(){
		GameController.instance.Resume (); //Resume Game
	}

	public void Home(){
		Application.LoadLevel ("MainMenu"); //Load StartMenu Scene
		//Prevent clicking home during paused
		Time.timeScale = 1; //timeScale = 1  It's mean not paused.
	}

	public void Restart(){
		Application.LoadLevel (Application.loadedLevel); //Reload Scene
		//Prevent clicking home during paused
		Time.timeScale = 1; //timeScale = 1  It's mean not paused.

	}
}
