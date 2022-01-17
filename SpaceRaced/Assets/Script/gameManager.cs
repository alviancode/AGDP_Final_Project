using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;

public class gameManager : NetworkBehaviour
{
    [SerializeField] private GameObject harvesterBotPrefab = default;

    float currentTime;
    public int startMinutes;
    public int numberOfBots;
    //public Text currentTimeText;


    // Update is called once per frame
    void Update()
    {
        if(isServer) {
            //Debug.Log(NetworkServer.connections.Count);
            if(NetworkServer.connections.Count == 2) {
                    currentTime -= Time.deltaTime;
            }
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        Debug.Log(time.Minutes.ToString() + ":" + time.Seconds.ToString());
    }


    public override void OnStartServer() {
        currentTime = startMinutes * 60;
        SPawnHarvester();
    }


    //[Command(requiresAuthority=false)]
    public void SPawnHarvester() {
        for (int i = 0; i < numberOfBots; i++) {
            GameObject harvesterInstance = Instantiate(harvesterBotPrefab);
            Transform newPosition = NetworkManager.singleton.GetStartPosition();
            harvesterInstance.transform.position = newPosition.position;
            NetworkServer.Spawn(harvesterInstance);
        }
    }

}
