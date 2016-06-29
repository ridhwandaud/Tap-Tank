using UnityEngine;
using System.Collections;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;

public class AppodealManager : MonoBehaviour {

	#if UNITY_EDITOR && !UNITY_ANDROID && !UNITY_IPHONE
	string appKey = "";
	#elif UNITY_ANDROID
	string appKey = "a5e37ea1c6d56a7f08288a79589561efae060c8064aaa8bb";
	#elif UNITY_IPHONE
	string appKey = "722fb56678445f72fe2ec58b2fa436688b920835405d3ca6";
	#else
	string appKey = "";
	#endif

	public static AppodealManager instance = null; 

	void Awake () 
	{
		Appodeal.initialize (appKey, Appodeal.INTERSTITIAL | Appodeal.BANNER);
		BannerAds ();
//		//Check if there is already an instance of SoundManager
//		if (instance == null) {
//			//if not, set it to this.
//			instance = this;
//			Appodeal.initialize (appKey, Appodeal.INTERSTITIAL | Appodeal.BANNER);
//			BannerAds ();
//		}
//		//If instance already exists:
//		else if (instance != this) {
//			//Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
//			Destroy (gameObject);
//		}
//
//		//Set AppodealManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
//		DontDestroyOnLoad (gameObject);
		
	}

	public void BannerAds()
	{
		Debug.Log("BannerAds is showing");
		Appodeal.show (Appodeal.BANNER_BOTTOM);
	}

	public void InterstitialAds()
	{
		Appodeal.show (Appodeal.INTERSTITIAL);
	}
}