using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSpawner : MonoBehaviourPunCallbacks
{

    [SerializeField] private GameObject playerPrefab = null;
    [SerializeField] private Transform[] spawnPoint;
    public PhotonView pv;
    private static int contadorSpawns = 0;
    private static bool primerspawn = true;

    // Start is called before the first frame update
    void Start()
    {
        int numberOFPlayers = PhotonNetwork.CountOfPlayers;
        //MStats ms = new MStats();
        if (primerspawn) {
            if (numberOFPlayers == 1) { PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint[0].position, Quaternion.identity); contadorSpawns = 2; }
            if (numberOFPlayers == 2)
            {
                PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint[1].position, Quaternion.identity); contadorSpawns = 3;
            }
        } else {
            if (numberOFPlayers == 1) { PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint[contadorSpawns].position, Quaternion.identity); pv.RPC("sumarSpawn", RpcTarget.Others); }
            if (numberOFPlayers == 2)
            {
                PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint[contadorSpawns].position, Quaternion.identity); pv.RPC("sumarSpawn", RpcTarget.Others);
            }
        }

        primerspawn = false;

        /*
        if (numberOFPlayers == 1) { PhotonNetwork.Instantiate(playerPrefab.name, new Vector2(UnityEngine.Random.Range(10.7f, 25.3f), 0f), Quaternion.identity); }
        if (numberOFPlayers == 2) { PhotonNetwork.Instantiate(playerPrefab.name, new Vector2(UnityEngine.Random.Range(-10.7f, -25.3f), 0f), Quaternion.identity); }
        if (!ms.getSpawn()) { PhotonNetwork.Instantiate(playerPrefab.name, new Vector2(UnityEngine.Random.Range(10.7f, 25.3f), 0f), Quaternion.identity); ms.setSpawn(true); } else
        {
            PhotonNetwork.Instantiate(playerPrefab.name, new Vector2(UnityEngine.Random.Range(-10.7f, -25.3f), 0f), Quaternion.identity);
        }*/
       
    }

    [PunRPC]
    private void sumarSpawn()
    {
        contadorSpawns += 2;
        Debug.LogWarning(contadorSpawns) ;

    }








}
