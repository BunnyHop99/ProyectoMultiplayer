using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.Spawning;
using MLAPI.Transports.UNET;
using System;

public class MenuScript : MonoBehaviour
{
    public GameObject menuPanel;

    public string ipAddress = "127.0.0.1";

    UNetTransport transport;

    public void Host()
    {
        menuPanel.SetActive(false);
        NetworkManager.Singleton.ConnectionApprovalCallback += ApprovalCheck;
        NetworkManager.Singleton.StartHost(randomShit2(),Quaternion.identity);
    }


    private void ApprovalCheck(byte[] connectionData, ulong clientID, NetworkManager.ConnectionApprovedDelegate callback)
    {
        Debug.Log("Approving a connection");

        ulong? prefabHash = NetworkSpawnManager.GetPrefabHashFromGenerator("Player2");
        callback(true, prefabHash, true, randomShit(), Quaternion.identity);
    }

    public void Join()
    {
        transport = NetworkManager.Singleton.GetComponent<UNetTransport>();
        transport.ConnectAddress = ipAddress;
        menuPanel.SetActive(false);
        NetworkManager.Singleton.StartClient();
    }

    public void IPAddressChanged(string newAddress)
    {
        this.ipAddress = newAddress;
    }

    Vector3 randomShit()
    {
        float x = -22;
        float y = 11;
        return new Vector3(x, y, 0);
    }

    Vector3 randomShit2()
    {
        float x = -22;
        float y = -11;
        return new Vector3(x, y, 0);
    }
}
