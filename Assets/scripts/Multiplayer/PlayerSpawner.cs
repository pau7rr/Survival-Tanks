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
    

    // Start is called before the first frame update
    void Start()
    {
        //MStats ms = new MStats();
        int numberOFPlayers = PhotonNetwork.CountOfPlayers;
        if (numberOFPlayers == 1) { PhotonNetwork.Instantiate(playerPrefab.name, new Vector2(UnityEngine.Random.Range(10.7f, 25.3f), 0f), Quaternion.identity); }
        if (numberOFPlayers == 2) { PhotonNetwork.Instantiate(playerPrefab.name, new Vector2(UnityEngine.Random.Range(-10.7f, -25.3f), 0f), Quaternion.identity); }
       /* if (!ms.getSpawn()) { PhotonNetwork.Instantiate(playerPrefab.name, new Vector2(UnityEngine.Random.Range(10.7f, 25.3f), 0f), Quaternion.identity); ms.setSpawn(true); } else
        {
            PhotonNetwork.Instantiate(playerPrefab.name, new Vector2(UnityEngine.Random.Range(-10.7f, -25.3f), 0f), Quaternion.identity);
        }*/
        
        
    }

    

    


    

    
}
