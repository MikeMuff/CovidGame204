using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    //Rotating the syringes
    void Update()
    {
        transform.Rotate(new Vector3(15,30,45) * Time.deltaTime);

    }
}