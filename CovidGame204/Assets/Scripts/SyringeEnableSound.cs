using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyringeEnableSound : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        
    }

        void OnTriggerEnter(Collider other) 
    {
        //A way of going through the "tape"
        if (other.gameObject.CompareTag ("Player")){
        	//drawGUI = true;
        }
    }
}
