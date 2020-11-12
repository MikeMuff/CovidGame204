using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Text.RegularExpressions;

public class PlayerController : MonoBehaviour
{
    public AudioClip coinSound;
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

    public GameObject winTextObject;

    public float timeRemaining = 60;
    private float syringeCounter = 0f;
    private float totalLevers = 0f;
    private float totalCures = 0f;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timeRemaining -= Time.deltaTime;
        timerText.text = "Time Left: " + timeRemaining.ToString("0");
        if(timeRemaining <= 0){
            SceneManager.LoadScene(2);
        }
    }

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
        if (other.gameObject.CompareTag ("Portal")){
            checkWin();
        }
    }

    void checkWin(){
        if(winSyringe && winCure && winLever && winLavaJump){
                winTextObject.SetActive(true);
                finalTimeText.text = "Total Time: " + time.ToString("0");
                finalTimeText.enabled = true;
                Time.timeScale = 0f;
            }
    }




}