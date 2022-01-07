using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;


public class RobotShooting : NetworkBehaviour
{
    /// <summary>
    /// Move the player charactercontroller based on horizontal and vertical axis input
    /// </summary>

    GameObject mover;

    //now the camera so we can move it up and down
    Transform cameraTransform;
    float pitch = 0f;
    [Range(1f,90f)]
    public float maxPitch = 85f;
    [Range(-1f, -90f)]
    public float minPitch = -85f;
    [Range(0.5f, 5f)]
    public float mouseSensitivity = 2f;

    Transform canvasCrosshair;

    private void Start()
    {
        mover = GameObject.FindGameObjectWithTag("RobotMovement");
        cameraTransform = GetComponentInChildren<Camera>().transform;
        canvasCrosshair = GetComponentInChildren<Canvas>().transform;

        if (!hasAuthority) {
            cameraTransform.GetComponent<Camera>().enabled = false;
            cameraTransform.GetComponent<AudioListener>().enabled = false;
            canvasCrosshair.GetComponent<Canvas> ().enabled = false;
        }
    }

    [ClientCallback]
    void Update()
    {
        if (hasAuthority) {
            Look();
            Position();
        }
    }

    void Look()
    {
        //get the mouse inpuit axis values
        float xInput = Input.GetAxis("Mouse X") * mouseSensitivity;
        float yInput = Input.GetAxis("Mouse Y") * mouseSensitivity;
        //turn the whole object based on the x input
        transform.Rotate(0, xInput, 0);
        //now add on y input to pitch, and clamp it
        pitch -= yInput;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);
        //create the local rotation value for the camera and set it
        Quaternion rot = Quaternion.Euler(pitch, 0, 0);
        cameraTransform.localRotation = rot;
    }

    void Position()
    {
        // Follow Robot Position
        Transform moverTransform = mover.transform;
        Vector3 position = moverTransform.position;
        //float rotation = moverTransform.eulerAngles.y;
        //Debug.Log(rotation);

        transform.position = position;
        //transform.rotation = Quaternion.Euler(0, rotation, 0);
    }

}
