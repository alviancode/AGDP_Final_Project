using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class playerSelect : NetworkBehaviour {
    [SerializeField] private GameObject characterSelectDisplay = default;

    [SerializeField] private GameObject robotMovementPrefab = default;
    [SerializeField] private GameObject robotShooterPrefab = default;
    [SerializeField] private GameObject freeRoamerPrefab = default;
    [SerializeField] private GameObject blueFactionPrefab1 = default;
    [SerializeField] private GameObject blueFactionPrefab2 = default;
    [SerializeField] private GameObject blueFactionPrefab3 = default;


    private int selectedCharacterIndex = 0;

    public void robotMover() {
        selectedCharacterIndex = 1;
    }

    public void robotShooter() {
        selectedCharacterIndex = 2;
    }

    public void freeRoamer() {
        selectedCharacterIndex = 3;
    }

    public void blueFaction1() {
        selectedCharacterIndex = 4;
    }

    public void blueFaction2() {
        selectedCharacterIndex = 5;
    }

    public void blueFaction3() {
        selectedCharacterIndex = 6;
    }


    public override void OnStartClient() {
        characterSelectDisplay.SetActive(true);
    }

    public void select() {
        if(selectedCharacterIndex >= 1 && selectedCharacterIndex <= 6) {
            CmdSelect(selectedCharacterIndex);
            Debug.Log("Cool Index Bro: " + selectedCharacterIndex);
            characterSelectDisplay.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }
    }


    [Command(requiresAuthority=false)]
    public void CmdSelect(int characterIndex, NetworkConnectionToClient sender = null) {
        
        if (characterIndex == 1) {
            GameObject characterInstance = Instantiate(robotMovementPrefab);
            Transform newPosition = NetworkManager.singleton.GetStartPosition();
            characterInstance.transform.position = newPosition.position;
            NetworkServer.Spawn(characterInstance, sender);
        }
        if (characterIndex == 2) {
            GameObject characterInstance = Instantiate(robotShooterPrefab);
            Transform newPosition = NetworkManager.singleton.GetStartPosition();
            characterInstance.transform.position = newPosition.position;
            NetworkServer.Spawn(characterInstance, sender);
        }
        if (characterIndex == 3) {
            GameObject characterInstance = Instantiate(freeRoamerPrefab);
            Transform newPosition = NetworkManager.singleton.GetStartPosition();
            characterInstance.transform.position = newPosition.position;
            NetworkServer.Spawn(characterInstance, sender);
        }
        if (characterIndex == 4) {
            GameObject characterInstance = Instantiate(blueFactionPrefab1);
            Transform newPosition = NetworkManager.singleton.GetStartPosition();
            characterInstance.transform.position = newPosition.position;
            NetworkServer.Spawn(characterInstance, sender);
        }
        if (characterIndex == 5) {
            GameObject characterInstance = Instantiate(blueFactionPrefab2);
            Transform newPosition = NetworkManager.singleton.GetStartPosition();
            characterInstance.transform.position = newPosition.position;
            NetworkServer.Spawn(characterInstance, sender);
        }
        if (characterIndex == 6) {
            GameObject characterInstance = Instantiate(blueFactionPrefab3);
            Transform newPosition = NetworkManager.singleton.GetStartPosition();
            characterInstance.transform.position = newPosition.position;
            NetworkServer.Spawn(characterInstance, sender);
        }
    }
}
