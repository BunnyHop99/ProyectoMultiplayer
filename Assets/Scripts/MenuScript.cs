using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.Spawning;
using MLAPI.Transports.UNET;
using UnityEngine.UI;
using System;

public class MenuScript : MonoBehaviour
{
    public GameObject menuPanel;
    public InputField inputField;

    private void Start()
    {
        NetworkManager.Singleton.ConnectionApprovalCallback += ApprovalCheck;
    }

    private void ApprovalCheck(byte[] connectionData, ulong clientID, NetworkManager.ConnectionApprovedDelegate callback)
    {
        bool approve = false;

        string password = System.Text.Encoding.ASCII.GetString(connectionData);
        if (password == "mygame")
        {
            approve = true;
        }

        Debug.Log("Approving a connection");

        ulong? prefabHash = NetworkSpawnManager.GetPrefabHashFromGenerator("Player2");
        callback(true, prefabHash, approve, randomShit(), Quaternion.identity);
    }

    public void Host()
    {
        NetworkManager.Singleton.StartHost(randomShit2(), Quaternion.identity);
        menuPanel.SetActive(false);
    }

    public void Join()
    {
        if(inputField.text.Length <=0 )
        {
            NetworkManager.Singleton.GetComponent<UNetTransport>().ConnectAddress = "127.0.0.1";
        }
        else
        {
            NetworkManager.Singleton.GetComponent<UNetTransport>().ConnectAddress = inputField.text;
        }

        NetworkManager.Singleton.NetworkConfig.ConnectionData = System.Text.Encoding.ASCII.GetBytes("mygame");
        NetworkManager.Singleton.StartClient();
        menuPanel.SetActive(false);
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
