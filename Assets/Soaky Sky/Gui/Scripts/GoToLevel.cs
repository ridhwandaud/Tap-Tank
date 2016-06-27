using UnityEngine;
using System.Collections;

public class GoToLevel : MonoBehaviour {

	public void GotoThisLevel(int level)
	{
		Application.LoadLevel (level);
	}
}
