using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	public static bool GameIsPaused = false;
	public GameObject pauseMenuUI;

    private int currentSceneIndex;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Each frame check if the player has pressed Q to pause the game 
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q)){
        	if(GameIsPaused){
        		Resume();
                Cursor.lockState = CursorLockMode.Locked;
        	}
        	else{
        		Pause();
                Cursor.lockState = CursorLockMode.None;
        	}
        }
    }

    //If the player wants to resume where they paused at
    public void Resume(){
    	pauseMenuUI.SetActive(false);
    	Time.timeScale = 1f;
    	GameIsPaused = false;
    }

    //To pause the game and display the pause menu
    void Pause(){
    	pauseMenuUI.SetActive(true);
    	Time.timeScale = 0f;
    	GameIsPaused = true;
    }

    //Button for loading the menu back up
    public void LoadMenu(){
        Time.timeScale = 1f;
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("SavedScene", currentSceneIndex);
        SceneManager.LoadScene(2);
    }

    //This button funcitoinality will quit the game completely 
    public void QuitGame(){
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
    }
}
