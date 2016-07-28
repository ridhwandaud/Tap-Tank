using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelSelection_ButtonFunctions : MonoBehaviour {

	void Update () {
		//If touch back on mobile
		if (Input.GetKeyDown (KeyCode.Escape)) { 
			Home(); //Home 
		}
	}

	public void Home(){
		SceneManager.LoadScene("MainMenu");
		//Application.LoadLevel ("MainMenu"); //Load StartMenu Scene
		//Prevent clicking home during paused
		Time.timeScale = 1; //timeScale = 1  It's mean not paused.
	}
}
