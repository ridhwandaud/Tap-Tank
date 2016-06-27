
using UnityEngine;
using System.Collections;

public class LevelSelection : MonoBehaviour {
	
	private int worldIndex;   
	private int levelIndex;   
	
	void  Start ()
	{
		CheckLockedLevels(); 
	}

	//function to check for the levels locked
	void  CheckLockedLevels ()
	{
		//loop through the levels of a particular world
		for(int j = 0; j < LockLevel.levels; j++)
		{
			levelIndex = (j+1);
			if((PlayerPrefs.GetInt("level"+levelIndex.ToString()))==1)
			{
				GameObject.Find("LockedLevel"+(j+1)).active = false;
				Debug.Log ("Unlocked");
			}
		}
	}

	public void LevelSelect(int level)
	{
		PlayerPrefs.SetInt ("CurrentLevel",level);
		Application.LoadLevel ("Game");
	}
}
