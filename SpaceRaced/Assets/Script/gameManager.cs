using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;

public class gameManager : NetworkBehaviour
{
    float currentTime;
    public int startMinutes;
    //public Text currentTimeText;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startMinutes * 60;
    }

    // Update is called once per frame
    void Update()
    {
        if(isServer) {
            //Debug.Log(NetworkServer.connections.Count);
            if(NetworkServer.connections.Count == 2) {
                    currentTime -= Time.deltaTime;
                    TimeSpan time = TimeSpan.FromSeconds(currentTime);
                    Debug.Log(time.Minutes.ToString() + ":" + time.Seconds.ToString());
            }
        }
        
    }
}
