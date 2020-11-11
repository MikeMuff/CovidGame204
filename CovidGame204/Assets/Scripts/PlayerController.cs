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
    public float timeRemaining = 60;
    private float syringeCounter = 0f;
    private float totalLevers = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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

                }
			}
        if (other.gameObject.CompareTag ("Lava")){
            timeRemaining += 15f;
            lavaJump.text = "Lava Crossed: Yes";
            lavaJump.color = new Color(0,255,0,255);
            other.gameObject.SetActive (false);
        }
        if (other.gameObject.CompareTag ("Lever")){
            string lever = leverText.text;
            string resultString = Regex.Match(lever, @"\d+").Value;
            Debug.Log("We in levers");
            totalLevers = float.Parse(resultString);
            Debug.Log(totalLevers);
            if(totalLevers >= 2){
                timeRemaining += 15f;
            }
        }
    }
}