using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class RobotShooterOld : NetworkBehaviour
{

    //GameObject player = GameObject.Find("RobotMovement");
    public GameObject mover;

    void Start() {
        mover = GameObject.FindGameObjectWithTag("RobotMovement");
    }


    [ClientCallback]
    void Update()
    {
        position();
    }

    void position()
    {
        // Follow Robot Position
        Transform moverTransform = mover.transform;
        Vector3 position = moverTransform.position;
        float rotation = moverTransform.eulerAngles.y;
        Debug.Log(rotation);

        transform.position = position;
        transform.rotation = Quaternion.Euler(0, rotation, 0);
    }

}
