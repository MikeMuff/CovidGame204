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

    //A simple way for the music to play globally across all scenes
    void Awake() 
    {
        if (instance != null && instance != this) 
        {
            if(instance.GetComponent<AudioSource>().clip != GetComponent<AudioSource>().clip)
            {
                instance.GetComponent<AudioSource>().clip = GetComponent<AudioSource>().clip;
                instance.GetComponent<AudioSource>().volume = GetComponent<AudioSource>().volume;
                instance.GetComponent<AudioSource>().Play();
            }

            Destroy(this.gameObject);
            return;
        } 
        instance = this;
        GetComponent<AudioSource>().Play ();
        DontDestroyOnLoad(this.gameObject);
    }
}
