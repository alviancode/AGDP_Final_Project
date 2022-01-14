using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class TargetHealth : NetworkBehaviour
{
    [SyncVar]
    private float health = 100f;

    public float damageReduction = 0f;
    public bool respawnable;


    public void takeDamage(float amount) {
        health -= amount - damageReduction;

        if (health <= 0) {
            if (respawnable) {
                health = 100f;
                CmdRespawn(gameObject);
            } else {
                CmdDestroy(gameObject);
            }
        }
    }

    [Command(requiresAuthority=false)]
    public void CmdRespawn(GameObject gObject) {
        gObject.SetActive(false);
        Transform newPosition = NetworkManager.singleton.GetStartPosition();
        gObject.transform.position = newPosition.position;
        gObject.transform.rotation = newPosition.rotation;
        gObject.SetActive(true);
    }

    [Command(requiresAuthority=false)]
    public void CmdDestroy(GameObject gObject) {
        NetworkServer.Destroy(gObject);
    }

}
