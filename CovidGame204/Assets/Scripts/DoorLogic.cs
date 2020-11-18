using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorLogic : MonoBehaviour
{
	private IEnumerator coroutine;

	private bool drawGUI = false;
	private bool doorIsClosed = true;

	public Transform theDoor;

    // Update is called once per frame checking for the collision and the key E
    void Update()
    {

    	if(drawGUI && Input.GetKeyDown(KeyCode.E)){
    		changeDoorState();
    	}
    }

    void OnTriggerEnter(Collider other) 
    {
        //Displays if player is in collision
        if (other.gameObject.CompareTag ("Player")){
        	drawGUI = true;
        }
    }

    //Make sure we do not show the GUI after the player leaves the box collider area
    void OnTriggerExit(Collider other) {
    	if (other.gameObject.CompareTag ("Player")){
        	drawGUI = false;
        }
    }


    void OnGUI(){
    	if(drawGUI){
    		GUI.Box(new Rect(Screen.width*0.5f-51,10, 102, 22), "Press E to door");
    	}
    }

    //State for the door and animation
  	void changeDoorState(){
  		Debug.Log("We got in Here");
    	if(doorIsClosed){
    		theDoor.GetComponent<Animation>().CrossFade("Open");
    		theDoor.GetComponent<AudioSource>().Play();
    		doorIsClosed = false;
    		coroutine = test(3.0f);

            //Coroutine to make the door automatically close behind them
    		StartCoroutine(coroutine);
    		doorIsClosed = true;

    	}
    }

    //Closing the door after 3 seconds
    IEnumerator test(float numSeconds){
    	yield return new WaitForSeconds(numSeconds);
    	theDoor.GetComponent<Animation>().CrossFade("Close");
    	theDoor.GetComponent<AudioSource>().Play();
    }
}
