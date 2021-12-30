using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System.Linq;

public class roleManager : NetworkBehaviour
{
    public GameObject moverPrefab;
    public GameObject shooterPrefab;
    public int characterTypez;

    
    [Command]
    void CmdChooser(int characterType)
    {
        if(characterType == 1){
            var mover = NetworkManager.Instantiate(moverPrefab);
            NetworkServer.Spawn(mover);
        }
        else if (characterType == 2){
            var shooter = NetworkManager.Instantiate(shooterPrefab);
            NetworkServer.Spawn(shooter);
        }
    }

    
    void OnClientConnect(){
        CmdChooser(characterTypez);
    }
}
