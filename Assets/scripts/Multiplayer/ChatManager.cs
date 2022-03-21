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
        
        texto.text = TankStats.nombre + ": " +mensj;
        Debug.LogWarning("setea text");
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
