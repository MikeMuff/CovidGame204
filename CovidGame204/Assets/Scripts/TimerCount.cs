using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimerCount : MonoBehaviour
{
	public Text scoreText;

	public float timeRemaining = 60;
    // Update is called once per frame
    void Update()
    {
    	timeRemaining -= Time.deltaTime;
        scoreText.text = "Time Left: " + timeRemaining.ToString("0");
    }
}
