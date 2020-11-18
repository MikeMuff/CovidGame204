using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Text.RegularExpressions;

//The main script for the UI canvas and the playercontroller so everythhing is centered
//Around the player such as tasks, winning, and syringe sound
public class PlayerControllerLvl1 : MonoBehaviour
{
    

    //UI Canvas objects
    public Text FirstPuzzle;
    public Text SecondPuzzle;
    public Text timerText;
    public Text ThirdPuzzle;
    public Text FourthPuzzle;
    public Text finalTimeText;



    //Display only if the player has succeeded in winning the level
    public GameObject winTextObject;

    //Time counter and numerical objects needed for winning parameters
    public float timeRemaining = 60;
    private float syringeCounter = 0f;
    private float totalLevers = 0f;
    private float totalCures = 0f;
    public float time1 = 0;
    public float time2;
    //public string currentScene;

    //start time that we will capture at the end 
    void Start()
    {
        //if (SceneManager.GetActiveScene().name == "level_two"){
            time2 = 0;
        //}
        //else{
           //currentScene = SceneManager.GetActiveScene().name;
       //     Debug.Log(currentScene);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        //We have our countdown time and timer counting up for totaltime
        //if (SceneManager.GetActiveScene().name == "level_two"){
        time2 += Time.deltaTime;
        timeRemaining -= Time.deltaTime;
        timerText.text = "Time Left: " + timeRemaining.ToString("0");
        
        //reload the scene if the player dies
        if(timeRemaining <= 0){
            SceneManager.LoadScene(3);
            }
        //}
    }

    /*public void SavePlayer(){
        Debug.Log("We have pressed Save!");
        //currentScene = SceneManager.GetActiveScene().name;
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer(){
        Debug.Log("Attempting to load");

        PlayerData data = SaveSystem.LoadPlayer();
        //SceneManager.LoadScene(data.currentScene);
        time1 = data.time1;
        time2 = data.time2;
        //currentScene = data.currentScene;
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];

        transform.position = position;

    }*/
    //All of the colliders that give you extra time and update the UI Canvas
    void OnTriggerEnter(Collider other) 
	{
		// ..and if the GameObject you intersect has the tag 'Pick Up' assigned to it..
		if (other.gameObject.CompareTag ("P1Finish"))
			{
                
				other.gameObject.SetActive (false);
				Debug.Log("We passed Puzzle 1");
                timeRemaining += 20f;
                FirstPuzzle.color = new Color(0,255,0,255);
                

                }
			
        if (other.gameObject.CompareTag ("P2Finish")){
            timeRemaining += 20f;
            SecondPuzzle.text = "Second Floor";
            SecondPuzzle.color = new Color(0,255,0,255);
            other.gameObject.SetActive (false);
            //winLavaJump = true;
        }
          if (other.gameObject.CompareTag ("P3Finish")){
            ThirdPuzzle.text = "Third Floor";
            ThirdPuzzle.color = new Color(0,255,0,255);
            timeRemaining += 20f;
            //winLever = true;
            
        }
        if (other.gameObject.CompareTag ("P4Finish")){
            FourthPuzzle.text = "Fourth Floor";
            FourthPuzzle.color = new Color(0,255,0,255);
            timeRemaining += 20f;
        }
        
        
}

        //When you get to the end we want to check if all tasks have been completed
 
    

    //If all parameters have been met then you win and can go back to the menu
  




}