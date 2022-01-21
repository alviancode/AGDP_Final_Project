using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;
using System;

public class gameManager : NetworkBehaviour
{
    [SerializeField] private GameObject harvesterBotPrefab = default;

    [SyncVar]
    float currentTime;
    int numberOfBotsLeft;


    public int startMinutes;
    public int numberOfBots;
    public int numberOfPlayer;

    public GameObject redWin;
    public GameObject blueWin;

    GameObject disableUI;





    // Update is called once per frame
    void Update()
    {
        disableUI =  GameObject.FindWithTag("disableUI");
        if(isServer) {
            if(NetworkServer.connections.Count >= numberOfPlayer) {
                    currentTime -= Time.deltaTime;
            }
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        Debug.Log(time.Minutes.ToString() + ":" + time.Seconds.ToString());

        numberOfBotsLeft = GameObject.FindGameObjectsWithTag("Harvester Bot").Length;
        
        if(currentTime <= 0 && numberOfBotsLeft > 0) {
            Debug.Log("BlueTeamWin");
            blueWin.SetActive(true);
            disableUI.SetActive(false);
        }

        if(currentTime > 0 && numberOfBotsLeft <= 0) {
            Debug.Log("RedTeamWin");
            redWin.SetActive(true);
            disableUI.SetActive(false);
        }
    }


    public override void OnStartServer() {
        currentTime = startMinutes * 60;
        SpawnHarvester();
    }


    public void SpawnHarvester() {
        for (int i = 0; i < numberOfBots; i++) {
            GameObject harvesterInstance = Instantiate(harvesterBotPrefab);
            Transform newPosition = NetworkManager.singleton.GetStartPosition();
            harvesterInstance.transform.position = newPosition.position;
            NetworkServer.Spawn(harvesterInstance);
        }
    }

}
