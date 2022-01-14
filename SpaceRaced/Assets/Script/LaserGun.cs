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
            if (hit.collider.gameObject.layer == 7) {
                var playerHealth = hit.collider.gameObject.GetComponent<TargetHealth>();
                if(playerHealth) {
                    playerHealth.takeDamage(10f);
                }
            }

            RpcDrawLaser(laserTransform.position, hit.point);
        } else{
            RpcDrawLaser(laserTransform.position, laserTransform.position + laserTransform.forward * 100f);
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
