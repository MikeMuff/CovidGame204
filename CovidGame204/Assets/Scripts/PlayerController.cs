using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Text.RegularExpressions;

//The main script for the UI canvas and the playercontroller so everythhing is centered
//Around the player such as tasks, winning, and syringe sound
public class PlayerController : MonoBehaviour
{
    //Syringe Sound
    public AudioClip coinSound;

    //UI Canvas objects
    public Text syringeText;
    public Text lavaJump;
    public Text timerText;
    public Text leverText;
    public Text curedText;
    public Text finalTimeText;

    //Winning parameters if all are true then you win
    private bool winSyringe = false;
    private bool winLavaJump = false;
    private bool winLever = false;
    private bool winCure = false;

    //Display only if the player has succeeded in winning the level
    public GameObject winTextObject;

    //Time counter and numerical objects needed for winning parameters
    public float timeRemaining = 60;
    private float syringeCounter = 0f;
    private float totalLevers = 0f;
    private float totalCures = 0f;
    public float time1 = 0;
    public float time2;
    private bool timestop = false;
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
        if(timeRemaining <= 0 && timestop == false){
            SceneManager.LoadScene(2);
            }
        if(timestop == true){
            if(Input.GetKeyDown(KeyCode.M)){
                    //Time.timeScale = 0f;
                    SceneManager.LoadScene(2);
            }
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
		if (other.gameObject.CompareTag ("PickUp"))
			{
                AudioSource.PlayClipAtPoint(coinSound, other.transform.position);
                syringeCounter +=1;
                syringeText.text = "Syringes Collected: " + syringeCounter.ToString() + "/4";
				other.gameObject.SetActive (false);
				Debug.Log("We Grabbed a Syringe");
                if(syringeCounter == 4){
                    timeRemaining += 15f;
                    syringeText.color = new Color(0,255,0,255);
                    winSyringe = true;

                }
			}
        if (other.gameObject.CompareTag ("Lava")){
            timeRemaining += 15f;
            lavaJump.text = "Lava Crossed: Yes";
            lavaJump.color = new Color(0,255,0,255);
            other.gameObject.SetActive (false);
            winLavaJump = true;
        }
        if (other.gameObject.CompareTag ("Lever")){
            string lever = leverText.text;
            string resultString = Regex.Match(lever, @"\d+").Value;
            totalLevers = float.Parse(resultString);
            if(totalLevers >= 2){
                timeRemaining += 15f;
                winLever = true;
            }
        }
        if (other.gameObject.CompareTag ("Cure")){
            string cure = curedText.text;
            string resultString = Regex.Match(cure, @"\d+").Value;
            totalCures = float.Parse(resultString);
            if(totalCures >= 2){
                timeRemaining += 15f;
                winCure = true;
            }
        }

        //When you get to the end we want to check if all tasks have been completed
        if (other.gameObject.CompareTag ("Portal")){
            checkWin();
        }
    }

    //If all parameters have been met then you win and can go back to the menu
    void checkWin(){
        if(winSyringe && winCure && winLever && winLavaJump){
                timestop = true;
                winTextObject.SetActive(true);
                finalTimeText.text = "Total Time: " + time2.ToString("0");
                finalTimeText.enabled = true;
                Cursor.lockState = CursorLockMode.None;
            }
    }




}