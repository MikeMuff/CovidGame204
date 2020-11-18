using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;
public class LeverScript : MonoBehaviour
{
    // Start is called before the first frame update
   	private IEnumerator coroutine;

    //GUI showing the player to interact
	private bool drawGUI = false;

	//Door is closed
	private bool leverIsOff = true;
	public Transform theLever;

    //Light that will be changed
	public Light lt;

    //updating text on the UI Canvas
	public Text timerText;
	public Text leverText;


	private float leverCounter = 0f;
    private float totalLevers = 0f;

    //Sound for the generator
	public AudioSource generatorSound;

    //Frame by frame checking if the key R is pressed
    void Update()
    {

    	if(drawGUI && Input.GetKeyDown(KeyCode.R)){
    		changeLeverState();
    	}
    }

    //If player is close enough the invisble box collider
    void OnTriggerEnter(Collider other) 
        {
        if (other.gameObject.CompareTag ("Player")){
        	drawGUI = true;
        }
    }

    //Hide the GUI if they leave the area
    void OnTriggerExit(Collider other) {
    	if (other.gameObject.CompareTag ("Player")){
        	drawGUI = false;
        }
    }

    void OnGUI(){
    	if(drawGUI){
    		GUI.Box(new Rect(Screen.width*0.5f-51,10, 200, 22), "Press R for Lever");
    	}
    }

    //Changing the lever state and all of the functionality that comes with it
  	void changeLeverState(){
  		//Debug.Log("We got in Here");
    	if(leverIsOff){
    		Debug.Log("Lever turnedOn");
    		theLever.GetComponent<Animation>().Play("LeverOn");
    		theLever.GetComponent<AudioSource>().Play();
    		coroutine = test(1.0f);
    		StartCoroutine(coroutine);
    		//yield return new WaitForSeconds(3f);
    		string lever = leverText.text;
    		string resultString = Regex.Match(lever, @"\d+").Value;
			totalLevers = float.Parse(resultString);
    		leverCounter += totalLevers;
    		leverCounter +=1;
            leverText.text = "Levers Triggered: " + leverCounter.ToString() + "/3";
            if(leverCounter >= 3){
                generatorSound.Play();
                leverText.color = new Color(0,255,0,255);
    		}
    	}
	}

    //Our Coroutine for changing the lights
    IEnumerator test(float numSeconds){
    	//Debug.Log("We are yielding!");
    	yield return new WaitForSeconds(numSeconds);
    	if(leverIsOff){
    		lt.color = Color.green;
    		leverIsOff = false;
    	}
    }
}
