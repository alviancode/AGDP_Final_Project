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
        CmdSelect(selectedCharacterIndex);
        Debug.Log(selectedCharacterIndex);
    }

    [Command(requiresAuthority = false)]
    public void CmdSelect(int characterIndex, NetworkConnectionToClient sender = null) {
        if (selectedCharacterIndex == 1) {
            GameObject characterInstance = Instantiate(robotMovementPrefab);
            NetworkServer.Spawn(characterInstance, sender);
            characterSelectDisplay.SetActive(false);
        }
        else if (selectedCharacterIndex == 2) {
            GameObject characterInstance = Instantiate(robotShooterPrefab);
            NetworkServer.Spawn(characterInstance, sender);
            characterSelectDisplay.SetActive(false);
        }
        else if (selectedCharacterIndex == 3) {
            GameObject characterInstance = Instantiate(freeRoamerPrefab);
            NetworkServer.Spawn(characterInstance, sender);
            characterSelectDisplay.SetActive(false);
        }
        else if (selectedCharacterIndex == 4) {
            GameObject characterInstance = Instantiate(blueFactionPrefab1);
            NetworkServer.Spawn(characterInstance, sender);
            characterSelectDisplay.SetActive(false);
        }
        else if (selectedCharacterIndex == 5) {
            GameObject characterInstance = Instantiate(blueFactionPrefab2);
            NetworkServer.Spawn(characterInstance, sender);
            characterSelectDisplay.SetActive(false);
        }
        else if (selectedCharacterIndex == 6) {
            GameObject characterInstance = Instantiate(blueFactionPrefab3);
            NetworkServer.Spawn(characterInstance, sender);
            characterSelectDisplay.SetActive(false);
        }
    }
}
