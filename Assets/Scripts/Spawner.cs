using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.Messaging;
using MLAPI.Spawning;

public class Spawner : NetworkBehaviour
{
    public GameObject obstacle;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float timeBetweenSpawn;
    private float spawnTime;

    void Update()
    {
        if(Time.time > spawnTime)
        {
            Spawn();

            spawnTime = Time.time + timeBetweenSpawn;
        }
    }

    void Spawn()
    {
        SpawnServerRpc();
    }

    [ServerRpc]
    void SpawnServerRpc()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        GameObject spawnerGei = Instantiate(obstacle, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
        spawnerGei.GetComponent<NetworkObject>().Spawn();
        ulong itemNetId = spawnerGei.GetComponent<NetworkObject>().NetworkObjectId;
        SpawnClientRpc(itemNetId);
    }

    [ClientRpc]
    void SpawnClientRpc(ulong itemNetId)
    {
        NetworkObject netGei = NetworkSpawnManager.SpawnedObjects[itemNetId];
    }
}
