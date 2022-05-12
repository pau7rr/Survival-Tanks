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
    public Transform camt;

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

            //bosque
            if (contadorSpawns == 2 || contadorSpawns == 3) { camt.position = new Vector3(-46, 4, -40); }
            //bosque2
            if (contadorSpawns == 4 || contadorSpawns == 5) { camt.position = new Vector3(33, -10, -40); }
            //mazz
            if (contadorSpawns == 6 || contadorSpawns == 7) { camt.position = new Vector3(31, 4, -40); }

            if (contadorSpawns == 8 || contadorSpawns == 9) { camt.position = new Vector3(-3, 4, -40); }


            if (numberOFPlayers == 1) { PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint[contadorSpawns].position, Quaternion.identity); pv.RPC("sumarSpawn", RpcTarget.Others); }
            if (numberOFPlayers == 2)
            {
                PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint[contadorSpawns].position, Quaternion.identity); pv.RPC("sumarSpawn", RpcTarget.Others);
            }
        }

        primerspawn = false;
       

    }

    [PunRPC]
    private void sumarSpawn()
    {
        contadorSpawns += 2;
        Debug.LogWarning(contadorSpawns) ;

    }








}
