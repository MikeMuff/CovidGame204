using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class PlayerData
{
    // Start is called before the first frame update
    public float time1;
    public float time2;
    //public string currentScene;
    public float[] position;
    

    public PlayerData (PlayerController player){
    	time1 = player.time1;
    	time2 = player.time2;
    	//currentScene = player.currentScene;
    	Debug.Log("the current scene");
    	//Debug.Log(currentScene);
    	position = new float[3];
    	position[0] = player.transform.position.x;
    	position[1] = player.transform.position.y;
    	position[2] = player.transform.position.z;
    }

}
