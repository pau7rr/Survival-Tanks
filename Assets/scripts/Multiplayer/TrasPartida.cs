using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrasPartida : MonoBehaviour
{
    public TextMeshProUGUI texto;
    private bool revancha;
    MStats m = new MStats();
    // Start is called before the first frame update
    void Start()
    {
        if (MStats.derrotas == 3) { texto.text = "Derrota..."; } else { texto.text = "Victoria!"; }
        m.Reseteo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Salir() {
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    void Revancha() {
        if (PhotonNetwork.PlayerListOthers.Length > 0) { 
        
        } 
    }
}
