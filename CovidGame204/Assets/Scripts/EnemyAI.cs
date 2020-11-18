using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    //We want to make the zombies simple and only be in two states
	public enum AIState { idle, chasing};
	public float distanceThreshold = 7f;
	public float setSpeed = 3f;
	public AIState aiState = AIState.idle;
    // Start is called before the first frame update
    UnityEngine.AI.NavMeshAgent nm;
    public Transform target;

    //Init the zombie and start the ccoroutine
    void Start()
    {
        nm = GetComponent<UnityEngine.AI.NavMeshAgent>();
        nm.speed = setSpeed;
        StartCoroutine(Think());
    }

    // Update is called once per frame
    void Update()
    {
    }

    //Coroutine for the zombie to update based on the players coordinates
    IEnumerator Think(){
    	while(true)
    	{
    		switch(aiState){
    			case AIState.idle:
    				float dist = Vector3.Distance(target.position,transform.position);
    				if(dist < distanceThreshold){
    					aiState = AIState.chasing;
    				}
    				nm.SetDestination(transform.position);
    				break;
    			case AIState.chasing:
    				dist = Vector3.Distance(target.position,transform.position);
    				if(dist > distanceThreshold){
    					aiState = AIState.idle;
    				}
    				nm.SetDestination(target.position);
    				break;
    			default:
    				break;
    		}
    		yield return new WaitForSeconds(1f);
    	}
    }
}
