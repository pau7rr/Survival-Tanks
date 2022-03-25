using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChatManager : MonoBehaviour
{
    public PhotonView pv;
    public GameObject chat;
    public TextMeshProUGUI texto;
    private InputField inputj;
    private bool desactivar;
    private int contadormensj = 0;
    IEnumerator Remove() {
        yield return new WaitForSeconds(4f);
       // chat.SetActive(false);
        desactivar = false;
    }

   /* private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
        if (stream.IsWriting) {
            stream.SendNext(chat.active);
        }
        else if (stream.IsReading)
        {
            chat.SetActive((bool)stream.ReceiveNext());
        }
    }*/

    private void Awake()
    {
        inputj = GameObject.Find("InputField").GetComponent<InputField>();
       // chat = GameObject.Find("chat");
        texto = GameObject.Find("chattext").GetComponent<TextMeshProUGUI>();
    }
    [PunRPC]
    private void Sendmessage(string mensj) {
        contadormensj += 1;
        if (pv.IsMine)
        {
            if (contadormensj % 3 == 0) { texto.text = PhotonNetwork.LocalPlayer.NickName + ": " + mensj; } else { texto.text = texto.text + "\n"+ PhotonNetwork.LocalPlayer.NickName + ": " + mensj; }
                
            Debug.LogWarning("setea text mio");
        }
        else {
            string nombre = "";
            foreach (var p in PhotonNetwork.PlayerListOthers)
            {
                nombre = p.NickName;
            }
            if (contadormensj % 3 == 0) { texto.text = nombre + ": " + mensj; } else { texto.text = texto.text + "\n" + nombre + ": " + mensj; }
            //texto.text = nombre + ": " + mensj;
            Debug.LogWarning("setea text otro" + nombre );
        }


        // texto.text = PhotonNetwork.LocalPlayer.NickName + ": " + mensj;
        StartCoroutine(Remove());
    }

    // Update is called once per frame
    void Update()
    {
        if (pv.IsMine) {
           if (inputj.isFocused) {
                if (inputj.text != "" && inputj.text.Length > 0 && Input.GetKeyDown(KeyCode.LeftControl)) {
                    pv.RPC("Sendmessage", RpcTarget.AllBuffered, inputj.text);
                Debug.LogWarning("Mandar");
                   // chat.SetActive(true);
                    inputj.text = "";
                    desactivar = true;
                }
            }
        }
    }
}
