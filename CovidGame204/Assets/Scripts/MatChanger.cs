using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatChanger : MonoBehaviour
{
    public Material Material1;
    //in the editor this is what you would set as the object you wan't to change
    public GameObject Object;
    public GameObject door;

    void Start()
    {
        door.SetActive(false);
    }


    void OnTriggerEnter(Collider other)
    {
        
        Object.GetComponent<MeshRenderer>().material = Material1;
        door.SetActive(true);
    }


}