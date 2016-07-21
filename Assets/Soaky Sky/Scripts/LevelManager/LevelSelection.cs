
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class LevelSelection : MonoBehaviour {
	
	private int worldIndex;   
	private int levelIndex; 
	private Image[] numberLvl= new Image[LockLevel.levels*2];  
	private Image[] numberImg = new Image[40];

	private int curLVL = 1;
	void Awake(){

		
		
		/*List <LevelContainerList> levelList = new List<LevelContainerList>(); 
		for (int i = 0; i < LockLevel.levels*2; i+=2)
		{			
			numberImg = GameObject.Find("numberContainer"+(i+1)).GetComponentsInChildren<Image>();
			Debug.Log("numberImg length "+numberImg.Length);	

			levelList.Add(new LevelContainerList(numberImg[i],numberImg[i+1]));	
			Debug.Log("levelList count "+levelList.Count);
			//Debug.Log("ok "+i+" "+(i+1));
			//Debug.Log("Now numberLvl "+i+" "+GameObject.Find("numberContainer"+(i+1)).activeSelf);
		}
		*/
		//GameObject.Find("numberContainer"+(j+1)).SetActive(true);
	}

	void  Start ()
	{
		CheckLockedLevels();
		//lock levels
		GameObject groupParent = GameObject.FindGameObjectWithTag("Group");
		for(int i=0;i< groupParent.transform.childCount;i++){
			GameObject level = groupParent.transform.GetChild(i).gameObject;
			Debug.Log("CURRENT LVL"+curLVL);
			if( i < curLVL){
				//remove lock (IS NOT LOCKED)
				level.transform.GetChild(1).gameObject.SetActive(false);
			}
			else
			{
				//remove number(IS LOCK)
				if(i!=0){
					level.transform.GetChild(0).gameObject.SetActive(false);
					level.GetComponent<Button>().interactable = false;
					ColorBlock cb = level.GetComponent<Button>().colors;
					cb.colorMultiplier = 5;
					level.GetComponent<Button>().colors = cb;
				}
					
			}
		}
	}

	//function to check for the levels locked
	void  CheckLockedLevels ()
	{Debug.Log("Levels "+LockLevel.levels);
		//loop through the levels of a particular world
		for(int j = 0; j < LockLevel.levels; j++)
		{
			levelIndex = (j+1);
			if((PlayerPrefs.GetInt("level"+levelIndex.ToString()))==1)
			{
				//GameObject.Find("LockedLevel"+(j+1)).active = false;
				GameObject.Find("lock"+(j+1)).SetActive(false);
				//numberLvl[j].SetActive(true);
				Debug.Log ("Unlocked level "+(j+1));
				
				//GameObject.Find("lock"+(j+1)).transform.parent.gameObject.GetComponentInParent<Button>().interactable = true;
//				Debug.Log("grand parent of lock interactable is "+GameObject.Find("lock"+(j+1)).GetComponentInParent<GameObject>().GetComponentInParent<Button>().interactable);
			}
		}
		curLVL = PlayerPrefs.GetInt("CurrentLevel");
		Debug.Log("LVL SKANG "+curLVL);
	}

	public void LevelSelect(int level)
	{
		PlayerPrefs.SetInt ("CurrentLevel",level);
		//Debug.Log("Current Level="+level);
		//Application.LoadLevel ("Game");
		SceneManager.LoadScene("Game");
	}
}
