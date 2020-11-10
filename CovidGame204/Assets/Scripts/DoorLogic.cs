using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorLogic : MonoBehaviour
{
	private IEnumerator coroutine;

	private bool drawGUI = false;
	private bool doorIsClosed = true;

	public Transform theDoor;

    // Update is called once per frame
    void Update()
    {

    	if(drawGUI && Input.GetKeyDown(KeyCode.E)){
    		changeDoorState();
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
    		GUI.Box(new Rect(Screen.width*0.5f-51,10, 102, 22), "Press E to door");
    	}
    }

  	void changeDoorState(){
  		Debug.Log("We got in Here");
    	if(doorIsClosed){
    		theDoor.GetComponent<Animation>().CrossFade("Open");
    		theDoor.GetComponent<AudioSource>().Play();
    		doorIsClosed = false;
    		//yield return new WaitForSeconds(3f);
    		coroutine = test(3.0f);
    		StartCoroutine(coroutine);
    		//test();
    		doorIsClosed = true;

    	}
    }

    IEnumerator test(float numSeconds){
    	Debug.Log("We are yielding!");
    	yield return new WaitForSeconds(numSeconds);
    	theDoor.GetComponent<Animation>().CrossFade("Close");
    	theDoor.GetComponent<AudioSource>().Play();
    }
}
