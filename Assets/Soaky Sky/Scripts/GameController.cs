using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	private int score = 0; //For count score
	public Canvas gameoverGUI; //For show GUI of gameover
	public Canvas ingameGUI;  //For show GUI when play (pause button ,scoreText)
	public Canvas pauseGUI; //For show GUI when pause
	public static GameController instance; //Instance

	public int currentLevel;
	public GameObject[] levels;

	//Ads
	public int i;
	public int adsShow;
	public string gameId; // Set this value from the inspector.
	public bool enableTestMode = true;
	public bool adsShowing = true;

	void Awake(){
		instance = this;
		CheckCurrentLevel ();
		CheckPlayTime ();
	}

	void CheckCurrentLevel (){

		if (PlayerPrefs.HasKey ("CurrentLevel") == false) {
			PlayerPrefs.SetInt("CurrentLevel",1);
			currentLevel=PlayerPrefs.GetInt ("CurrentLevel");
		}

		currentLevel = PlayerPrefs.GetInt ("CurrentLevel");
		Instantiate (levels [currentLevel]);
	}

	public void NextLevel()
	{
		currentLevel++;
		PlayerPrefs.SetInt ("CurrentLevel", currentLevel);
		PlayerPrefs.SetInt ("level"+currentLevel, 1);
		Application.LoadLevel ("Game");
	}
		
	void CheckPlayTime()
	{
		if (PlayerPrefs.HasKey ("PlayTime") == false) {
			PlayerPrefs.SetInt("PlayTime",1);
			i=1;
		}

		i = PlayerPrefs.GetInt ("PlayTime");

		i++;

		PlayerPrefs.SetInt("PlayTime",i);

	}

	public void Pause(){
		Time.timeScale = 0; //Change timeScale to 0
		pauseGUI.gameObject.SetActive (true); //Show pauseGUI
	}

	public void Resume(){
		Time.timeScale = 1; //Change timeScale to 1
		pauseGUI.gameObject.SetActive (false); //Hide pauseGUI
	}
}