using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	private int score = 0; //For count score
	public Canvas gameoverGUI; //For show GUI of gameover
	public Canvas ingameGUI;  //For show GUI when play (pause button ,scoreText)
	public Canvas pauseGUI; //For show GUI when pause

	public Canvas lvlBrk; // for short break between level
	public static GameController instance; //Instance

	public int currentLevel;
	public GameObject[] levels;

	//Ads
	public int playTime;
	public int adsShow;
	public string gameId; // Set this value from the inspector.
	public bool enableTestMode = true;
	public bool adsShowing = true;
	public AppodealManager ads;

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

		if (currentLevel < levels.Length) {
			Instantiate (levels [currentLevel]);
		} else {
			SceneManager.LoadScene("LevelSelection");
			//Application.LoadLevel ("LevelSelection");
		}
	}

	public void NextLevel()
	{
		currentLevel++;
		PlayerPrefs.SetInt ("CurrentLevel", currentLevel);

		if (currentLevel < levels.Length) {
			PlayerPrefs.SetInt ("level"+currentLevel, 1);
		} else {
			SceneManager.LoadScene("LevelSelection");
			//Application.LoadLevel ("LevelSelection");
		}

		if (playTime > 3) {
			ads.InterstitialAds ();
			PlayerPrefs.SetInt("PlayTime",1);
		}

		SceneManager.LoadScene("Game");
		//Application.LoadLevel ("Game");
	}
		
	void CheckPlayTime()
	{
		if (PlayerPrefs.HasKey ("PlayTime") == false) {
			PlayerPrefs.SetInt("PlayTime",1);
					playTime=1;
		}

		playTime = PlayerPrefs.GetInt ("PlayTime");
		playTime++;
		PlayerPrefs.SetInt("PlayTime",playTime);

	}

	public void Pause(){
		Time.timeScale = 0; //Change timeScale to 0
		pauseGUI.gameObject.SetActive (true); //Show pauseGUI
	}

	public void Resume(){
		Time.timeScale = 1; //Change timeScale to 1
		pauseGUI.gameObject.SetActive (false); //Hide pauseGUI
	}

	public IEnumerator LevelBreak(){
        lvlBrk.gameObject.SetActive(true);
        Debug.Log("Show level break");
        yield return new WaitForSeconds(1.5f);
        lvlBrk.gameObject.SetActive(false);
        Debug.Log("Hide level break");
        NextLevel();
    }
}