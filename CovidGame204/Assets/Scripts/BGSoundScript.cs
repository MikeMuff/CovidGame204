using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSoundScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Play Globally
    private static BGSoundScript instance = null;
    public static BGSoundScript Instance{
    	get { return instance; }
    }
    void Awake()
    {
        if(instance != null && instance != this){
        	Destroy(this.gameObject);
        }
        else{
        	DontDestroyOnLoad(this.gameObject);
        }
    }
}
