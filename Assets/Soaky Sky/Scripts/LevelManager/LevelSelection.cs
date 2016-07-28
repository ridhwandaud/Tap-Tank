
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
	GameObject groupParent;
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
		//for first 12 level
		if(curLVL<=12){//Debug.Log("CurrentLevel <= 12");
			groupParent = GameObject.FindGameObjectWithTag("Group").transform.GetChild(0).gameObject;  //gameobject "Container"
			Debug.Log("groupParent name "+groupParent.name);
		}
		//kalau cur = 13
		if(curLVL>12 && curLVL<=24){//Debug.Log("CurrentLevel > 12 && curLVL <= 24");
			groupParent = GameObject.FindGameObjectWithTag("Group").transform.GetChild(1).gameObject;  //gameobject "Container"
			Debug.Log("groupParent name "+groupParent.name);
		}
		
		
		//for(int k=0;k<groupParent.transform.childCount;k++){
			
			//GameObject groupChild = groupParent.transform.GetChild(k).gameObject;  // gameobject "group level"
			//GameObject groupLvl = GameObject.FindGameObjectWithTag("Group"+k);
			/*
			for(int i=0;i< groupParent.transform.childCount;i++){				

				GameObject level = groupParent.transform.GetChild(i).gameObject;  //gameobject "level"
				//Debug.Log("LVL name "+level.name);
				if( i < curLVL){
					//remove lock (IS NOT LOCKED)
					level.transform.GetChild(1).gameObject.SetActive(false);
					//Debug.Log("remove lock i "+i);
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
			}*/
		//}
		
	}

	//function to check for the levels locked
	void  CheckLockedLevels ()
	{
		//first level always open (1)
		GameObject.Find("lock1").SetActive(false); 
		
		//Debug.Log("Levels "+LockLevel.levels);
		//loop through the levels of a particular world
		for(int j = 0; j < LockLevel.levels; j++)
		{
			

			levelIndex = (j+1);
			//LEVEL IS UNLOCK
			
			if((PlayerPrefs.GetInt("level"+levelIndex.ToString()))==1)
			{
				//Debug.Log("j+1 "+(j+1));
				//GameObject.Find("LockedLevel"+(j+1)).active = false;
				GameObject.Find("lock"+(j+1)).SetActive(false);   
				//numberLvl[j].SetActive(true);
				//Debug.Log ("Unlocked level "+(j+1));
				
				//GameObject.Find("lock"+(j+1)).transform.parent.gameObject.GetComponentInParent<Button>().interactable = true;
//				Debug.Log("grand parent of lock interactable is "+GameObject.Find("lock"+(j+1)).GetComponentInParent<GameObject>().GetComponentInParent<Button>().interactable);
			}else{
				//dont check first level (solution for (1))
				if(j!=0){
								
					GameObject.Find("lock"+(j+1)).transform.parent.parent.GetChild(0).gameObject.SetActive(false);
					//Debug.Log("Object name "+GameObject.Find("lock"+(j+1)).transform.parent.parent.gameObject.name);
					GameObject.Find("Level"+(j+1)).GetComponent<Button>().interactable = false;
					ColorBlock cb = GameObject.Find("Level"+(j+1)).GetComponent<Button>().colors;
					cb.colorMultiplier = 5;
					GameObject.Find("Level"+(j+1)).GetComponent<Button>().colors = cb; 
				}
			}
		}
		curLVL = PlayerPrefs.GetInt("level");
		//curLVL = PlayerPrefs.GetInt("CurrentLevel");
		//Debug.Log("LVL SKANG "+curLVL);
	}

	public void LevelSelect(int level)
	{
		PlayerPrefs.SetInt ("CurrentLevel",level);
		//Debug.Log("Current Level="+level);
		//Application.LoadLevel ("Game");
		SceneManager.LoadScene("Game");
	}
}
