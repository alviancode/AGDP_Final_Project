using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class TargetHealth : NetworkBehaviour
{
    [SyncVar]
    private float health = 100f;

    public float damageReduction = 0f;
    public bool respawnable;
    public Image healthBar;

    void Update() {
        float scaleX = health / 100;

        healthBar.rectTransform.localScale = new Vector3(scaleX, 1, 1);
    }


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
        gObject.SetActive(true);
    }

    [Command(requiresAuthority=false)]
    public void CmdDestroy(GameObject gObject) {
        NetworkServer.Destroy(gObject);
    }

}
