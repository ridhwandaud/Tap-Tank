using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class current_level : MonoBehaviour {

	public Text current_lvl;
	int curLVL;
	// Use this for initialization
	void Start () {
		curLVL = PlayerPrefs.GetInt("CurrentLevel");
		current_lvl.text = curLVL.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
