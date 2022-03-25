using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MBala : MonoBehaviour
{
    float dmg = TankStats.strengh;
    public Rigidbody2D rigid;
    private int ronda;
    public PhotonView pv;
    [PunRPC]
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!pv.IsMine) { return; }
        //this.pv.RPC("DestroyObject", RpcTarget.AllBuffered);
        
        PhotonView target = collision.gameObject.GetComponent<PhotonView>();
        if (target.tag.Equals("Player"))
        {
            if (!target.IsMine) {
                //  collision.gameObject.GetComponent<MvidaPlayer>().bajarvida(dmg);
                target.RPC("bajarvida", RpcTarget.AllBuffered, dmg);
                Debug.LogWarning("quto vida");
            }
            
        }
        /*
         if (collision.gameObject.tag.Equals("Player"))
         {
             collision.gameObject.GetComponent<vidaPlayer>().vida -= dmg;
         }*/
      
        Deestroy();
       
    }

    // Start is called before the first frame update
    void Start()
    {

    }
    [PunRPC]
    private void Deestroy()
    {
        PhotonNetwork.Destroy(gameObject);
            Destroy(this.gameObject);
    }

    [PunRPC]
    private void DestroyBalasotro()
    {
        if (!pv.IsMine) {
            Debug.LogWarning("balareventada");
            PhotonNetwork.Destroy(gameObject);
            Destroy(this.gameObject);
        }
      
    }

    // Update is called once per frame
    void Update()
    {

    }
}
