using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
	private int sceneToContinue;

	//Button for starting the game
	public void PlayGame(){
		SceneManager.LoadScene(3);
	}

	public void ContinueGame(){
		sceneToContinue = PlayerPrefs.GetInt("SavedScene");
		if(sceneToContinue != 0){
			SceneManager.LoadScene(sceneToContinue);
		}
		else{
			return;
		}
	}
	//Button that will quit the game completely
	public void QuitGame(){
		    #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
	}
}
