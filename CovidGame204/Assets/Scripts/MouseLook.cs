using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This scripit is not used currently but might be helpful to implement in the future 
//Ideally helps the player have real limited look movement but there are some errors
public class MouseLook : MonoBehaviour
{
	public float mouseSensitivity = 100f;
	public Transform playerBody;

	float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
