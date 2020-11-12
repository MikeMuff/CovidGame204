using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;

public class CurableScript : MonoBehaviour
{
	private bool drawGUI = false;
	private bool notCured = true;

	private float totalCures = 0f;
	private float cureCounter = 0f;

	public Text curedText;

	public MeshRenderer zombieMaterial;
	public Material new_material;
    void Update()
    {

    	if(drawGUI && Input.GetKeyDown(KeyCode.C)){
    		changeZombieState();
    	}
    }

    void OnTriggerEnter(Collider other) 
        {
    //A way of going through the "tape"
        if (other.gameObject.CompareTag ("Player")){
        	drawGUI = true;
        }
    }

    void OnTriggerExit(Collider other) {
    	if (other.gameObject.CompareTag ("Player")){
        	drawGUI = false;
        }
    }

    void OnGUI(){
    	if(drawGUI){
    		GUI.Box(new Rect(Screen.width*0.5f-51,10, 200, 22), "Press C to Cure");
    	}
    }

    void changeZombieState(){
    	if(notCured){
    		zombieMaterial.material = new_material;
    		notCured = false;
    		string cure = curedText.text;
    		string resultString = Regex.Match(cure, @"\d+").Value;
			totalCures = float.Parse(resultString);
    		cureCounter += totalCures;
    		cureCounter +=1;
            curedText.text = "Zombies Cured: " + cureCounter.ToString() + "/3";
            if(cureCounter >= 3){
                curedText.color = new Color(0,255,0,255);
    		}

    	}
    }



}
