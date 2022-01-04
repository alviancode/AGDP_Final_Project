using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class RobotShooter : NetworkBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public GameObject currentTarget;

    public Camera fpsCam;

    //GameObject player = GameObject.Find("RobotMovement");
    public GameObject mover;

    void Start() {
        mover = GameObject.FindGameObjectWithTag("RobotMovement");
    }

    // Update is called once per frame
    void Update()
    {
        Transform moverTransform = mover.transform;
        Vector3 position = moverTransform.position;
        //float rotation = moverTransform.eulerAngles.y;
        Debug.Log(position);

        transform.position = position;
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
        }
    }
}
