using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Game_ButtonFunctions : MonoBehaviour {

	public AppodealManager ads;

	public void Rate(){
		//Put your URL
		Application.OpenURL ("https://play.google.com/store/apps/details?id=com.catgeargames.soakysky"); 
	}

	public void Pause(){
		GameController.instance.Pause (); //Pause Game
	}

	public void Resume(){
		GameController.instance.Resume (); //Resume Game
	}

	public void Home(){
		SceneManager.LoadScene("MainMenu");//Load StartMenu Scene
		//Application.LoadLevel ("MainMenu"); //Load StartMenu Scene
		//Prevent clicking home during paused
		ads.InterstitialAds();
		Time.timeScale = 1; //timeScale = 1  It's mean not paused.
	}

	public void Restart(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //reload scene
		//Application.LoadLevel (Application.loadedLevel); //Reload Scene
		//Prevent clicking home during paused
		Time.timeScale = 1; //timeScale = 1  It's mean not paused.

	}
}
