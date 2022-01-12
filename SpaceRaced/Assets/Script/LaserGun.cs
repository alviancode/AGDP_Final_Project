using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class LaserGun : NetworkBehaviour
{

    public Transform laserTransform;
    public LineRenderer line;

    public float damage = 10f;
    public float range = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasAuthority){
            return;
        }

        if(Input.GetMouseButtonDown(0)) {
            CmdShoot();
        }
    }

    [Command]
    void CmdShoot() {
        Ray ray = new Ray(laserTransform.transform.position, laserTransform.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, range)) {
            var player = hit.collider.gameObject.GetComponent<LaserGun>();
            //Debug.Log(hit.collider.gameObject.tag);
            //Debug.Log(hit.transform.name);
            //Debug.Log(hit.collider.GetComponent<Collider>().gameObject);

            if(player) {
                //StartCoroutine(Respawn(hit.collider.gameObject));
                CmdRespawn(hit.collider.gameObject);
            }

            RpcDrawLaser(laserTransform.position, hit.point);
        } else{
            RpcDrawLaser(laserTransform.position, laserTransform.position + laserTransform.forward * 100f);
        }
    }


    [Command(requiresAuthority=false)]
    public void CmdRespawn(GameObject gObject){
        NetworkConnection playerConn = gObject.GetComponent<NetworkIdentity>().connectionToClient;
        NetworkServer.Destroy(gObject);

        GameObject newPlayer = Instantiate(gObject);
        NetworkServer.Spawn(newPlayer);

        NetworkServer.ReplacePlayerForConnection(playerConn, newPlayer);
        NetworkServer.Destroy(gObject);
    }


/*
    [Server]
    IEnumerator Respawn(GameObject gObject) {
        NetworkServer.UnSpawn(gObject);
        Transform newPosition = NetworkManager.singleton.GetStartPosition();
        //gObject.transform.position = newPosition.position;
        //gObject.transform.rotation = newPosition.rotation;
        yield return new WaitForSeconds(1f);
        NetworkServer.Spawn(gObject);
    }*/


    [ClientRpc]
    void RpcDrawLaser(Vector3 start, Vector3 end) {
        StartCoroutine(LaserFlash(start, end));
    }

    IEnumerator LaserFlash(Vector3 start, Vector3 end) {
        line.SetPosition(0, start);
        line.SetPosition(1, end);
        yield return new WaitForSeconds(0.3f);
        line.SetPosition(0, Vector3.zero);
        line.SetPosition(1, Vector3.zero);

    }

}
