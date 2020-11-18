using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
	//[SerializeField] private Transform player;
	//[SerializeField] private Transform respawnPoint;
	    
	void OnTriggerEnter(Collider other){
    	if (other.gameObject.CompareTag ("Zombie") || other.gameObject.CompareTag ("LavaFloor")){
            //player.transform.position = respawnPoint.transform.position;

            string index = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(index);
	   }
    }

}
