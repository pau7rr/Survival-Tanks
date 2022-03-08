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
        PhotonNetwork.Instantiate(playerPrefab.name, new Vector2(UnityEngine.Random.Range(10.7f, 25.3f),0f), Quaternion.identity);
        
    }

    

    


    

    
}
