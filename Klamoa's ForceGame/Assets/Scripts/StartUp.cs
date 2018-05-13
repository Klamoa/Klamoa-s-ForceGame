
using UnityEngine;

public class StartUp : MonoBehaviour {

	void Awake () {		
	#if UNITY_STANDALONE				
		//only for no FullscreenScreen.fullScreen = !Screen.fullScreen;
		Screen.SetResolution(1080, 1920, false);
	#endif

	#if UNITY_ANDROID			
		//only for no FullscreenScreen.fullScreen = !Screen.fullScreen;
		Screen.SetResolution(1080, 1920, true);
		Application.targetFrameRate = 30;
	#endif
	}

}
