using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LockLevel : MonoBehaviour {

	public static int levels = 20; //number of levels
	
	private int worldIndex;   
	private int levelIndex;   
	public static bool reset;
	public Toggle toggleBtn;

	void  Start ()
	{
		if (reset) 
		{
			PlayerPrefs.DeleteAll (); //erase data on start
			LockLevels ();   //call function LockLevels
		}

		
	}

	public void resetButton(){
		reset = toggleBtn.isOn ;//Debug.Log("reset "+reset);
		if (toggleBtn.isOn) 
		{
			PlayerPrefs.DeleteAll (); //erase data on start
			LockLevels ();   //call function LockLevels
		}
	}

	
	//function to lock the levels
	void  LockLevels ()
	{
		//loop thorugh all the levels
		for (int j = 0; j < levels; j++)
		{
			levelIndex  = (j+1);
			//print ("level index : " + levelIndex);
			//create a PlayerPrefs of that particular level and world and set it's to 0, if no key of that name exists
			if(!PlayerPrefs.HasKey("level" +levelIndex.ToString()))
			{
				PlayerPrefs.SetInt("level"+levelIndex.ToString(),0);
			}
			
		}
	}
}