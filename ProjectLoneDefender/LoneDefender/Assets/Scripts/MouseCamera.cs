using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCamera : MonoBehaviour
{

    public float mouseSensitivity = 100f;

    public Transform PlayerBody; //Reference to player body to rotate entire character body when moving camera up, down, side to side//

    float xRotation = 0f; //To look up and down we need to be able to roate in the X axis//

    // Start is called before the first frame update
    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked; //Locks the mouse cursor to the game screen
    }

    // Update is called once per frame
    void Update()
    {
        float MouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime; //Camera movement on the x axis mutipled by mouse senstivity and time 
        float MouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime; //Camera movement on the y axis mutipled by mouse senstivity and time 

        xRotation -= MouseY; // decreases x roation every frame bases on mouse Y

        xRotation = Mathf.Clamp(xRotation, -90, 90); //Clamps camera to avoid over rotating the character

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0); //Keeping track of X rotation to control clamping
        PlayerBody.Rotate(Vector3.up * MouseX); // Rotates body side to sde with the camera

    }
}
