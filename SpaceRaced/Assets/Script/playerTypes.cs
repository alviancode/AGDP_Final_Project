using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTypes : MonoBehaviour
{
    public GameObject robot;
    public GameObject shooter;
    public int characterType;



    void Start()
    {
        if (characterType == 1){
            robot.SetActive(true);
            shooter.SetActive(false);
        }
        else if (characterType == 2){
            robot.SetActive(false);
            shooter.SetActive(true);
        }
        
    }



    // Update is called once per frame
    void Update()
    {

    }
}
