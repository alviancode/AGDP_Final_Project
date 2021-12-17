using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System.Linq;

public class roleManager : MonoBehaviour
{
    public GameObject robot;
    public GameObject shooter;
    public int characterType;


    private void Awake()
    {
        if(characterType == 1){
            gameObject.GetComponent<NetworkManager>().spawnPrefabs.Add(robot);
        }
        else if (characterType == 2){
            gameObject.GetComponent<NetworkManager>().spawnPrefabs.Add(shooter);
        }
        
    }
}
