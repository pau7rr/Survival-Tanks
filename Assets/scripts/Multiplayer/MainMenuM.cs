using Photon.Pun;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using Random=UnityEngine.Random;

public class MainMenuM : MonoBehaviourPunCallbacks
{

    [SerializeField] private GameObject findOpponentPanel = null;
    [SerializeField] private GameObject waitingStatusPanel = null;
    [SerializeField] private TextMeshProUGUI waitingStatusText = null;
    

    //public static int proba;
    public string[] maps = { "SampleScene", "Level2" };

    private bool isConnecting = false;
    public GameObject buscando;
    public GameObject esperando;
    public GameObject encontrada;
    private const string GameVersion = "0.1";
    private const int MaxPlayersPerRoom = 2;

    private void Awake() 
    {
      PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.LocalPlayer.NickName = TankStats.nombre;
        //PhotonNetwork.player
    }

    public void FindOpponent()
    {
        isConnecting = true;
        /*
        findOpponentPanel.SetActive(false);
        waitingStatusPanel.SetActive(true);
         waitingStatusText.text = "Searching...";*/
        buscando.SetActive(true);


        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRandomRoom();
        } 
        else
        {
            PhotonNetwork.GameVersion = GameVersion;
            PhotonNetwork.ConnectUsingSettings();
        }
        
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("ConnectedToMaster");

        if (isConnecting)
        {
            PhotonNetwork.JoinRandomRoom();
        }
        
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        waitingStatusPanel.SetActive(false);
        findOpponentPanel.SetActive(true);
        Debug.Log($"Disconnected due to: {cause}");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Nobody is waiting for opponents, creating new room");

        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = MaxPlayersPerRoom });
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Client succesfully joined a room");
        int playerCount = PhotonNetwork.CurrentRoom.PlayerCount;

        if (playerCount != MaxPlayersPerRoom)
        {
            buscando.SetActive(false);
            esperando.SetActive(true);
        }
        else
        {
            waitingStatusText.text = "Opponent found";
            Debug.Log("Matching is ready to begin");
            
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        if(PhotonNetwork.CurrentRoom.PlayerCount == MaxPlayersPerRoom)
        {
            PhotonNetwork.CurrentRoom.IsOpen = false;

            esperando.SetActive(false);
            encontrada.SetActive(true);
            //proba = 1;
            PhotonNetwork.LoadLevel("M2");
            
        }
    }

    public static void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public String randomMap(){
        int num = Random.Range(0, 2);
        return maps[0];
    }

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene("MainMenu");
    }



}
