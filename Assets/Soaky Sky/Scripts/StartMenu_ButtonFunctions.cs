using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu_ButtonFunctions : MonoBehaviour {

	public Slider startButton;

	void Start(){
		startButton.onValueChanged.AddListener(delegate{ValueChangeCheck();});
	}

	void ValueChangeCheck(){
		if(startButton.value == 1){
			Play();
		}
	}
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
		SceneManager.LoadScene ("LevelSelection"); //Load Game Scene
	}

	
}