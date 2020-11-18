using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerBall : MonoBehaviour
{

    public GameObject door;
    public AudioClip triggerSound;
    AudioSource audioSource;

    void Start()
    {
        door.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

   void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Goal")
        {
            
            door.SetActive(true);
            Debug.Log("GOALL");
            if (triggerSound != null){
                audioSource.PlayOneShot(triggerSound, 0.7F);
            }
            
        }
    }
    
    
}
