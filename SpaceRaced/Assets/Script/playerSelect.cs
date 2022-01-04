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
        }
    }

    [Command(requiresAuthority=false)]
    public void CmdSelect(int characterIndex, NetworkConnectionToClient sender = null) {
        if (characterIndex == 1) {
            GameObject characterInstance = Instantiate(robotMovementPrefab);
            NetworkServer.Spawn(characterInstance, sender);
            Debug.Log("Char1");
        }
        if (characterIndex == 2) {
            GameObject characterInstance = Instantiate(robotShooterPrefab);
            NetworkServer.Spawn(characterInstance, sender);
            Debug.Log("Char2");
        }
        if (characterIndex == 3) {
            GameObject characterInstance = Instantiate(freeRoamerPrefab);
            NetworkServer.Spawn(characterInstance, sender);
            Debug.Log("Char3");
        }
        if (characterIndex == 4) {
            GameObject characterInstance = Instantiate(blueFactionPrefab1);
            NetworkServer.Spawn(characterInstance, sender);
            Debug.Log("Char4");
        }
        if (characterIndex == 5) {
            GameObject characterInstance = Instantiate(blueFactionPrefab2);
            NetworkServer.Spawn(characterInstance, sender);
            Debug.Log("Char5");
        }
        if (characterIndex == 6) {
            GameObject characterInstance = Instantiate(blueFactionPrefab3);
            NetworkServer.Spawn(characterInstance, sender);
            Debug.Log("Char6");
        }
    }
}
