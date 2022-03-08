using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class PlayerMovementPlayerMovement_multi : MonoBehaviourPun
{
    public PhotonView pv;

    float velocityX;
    float jump = 5f;
    Rigidbody2D rb;
    int maxJump = 1;
    int numJump = 0;
    // Start is called before the first frame update

    void Awake()
    {
        transform.parent = null;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        velocityX = 0f;
        if (Input.GetKey(KeyCode.D)){
            if (GetComponent<SpriteRenderer>().flipX == true){
                GetComponent<SpriteRenderer>().flipX = false;
                
            }
            pv.RPC("OnDirectionChange_RIGHT", RpcTarget.Others);
            GetComponent<Animator> ().SetBool ("Correr", true);
            velocityX = 7f;
            
        }

        if (Input.GetKey(KeyCode.A)){
            if (GetComponent<SpriteRenderer>().flipX == false){
                GetComponent<SpriteRenderer>().flipX = true;

            }
            pv.RPC("OnDirectionChange_LEFT", RpcTarget.Others);
            GetComponent<Animator> ().SetBool ("Correr", true);
            velocityX = -7f;
        }

        transform.Translate(velocityX*Time.deltaTime,0f,0f);

        if (velocityX == 0f){
            GetComponent<Animator> ().SetBool ("Correr", false);
        }

        if (Input.GetKeyDown(KeyCode.Space)){
            if (numJump < maxJump)
            {
               rb.AddForce(new Vector2(0f,jump),ForceMode2D.Impulse); 
               numJump++;
            } 
            
        }
    }

    [PunRPC]
    void OnDirectionChange_LEFT(){
        GetComponent<SpriteRenderer>().flipX = true;
    }
    [PunRPC]
    void OnDirectionChange_RIGHT(){
        GetComponent<SpriteRenderer>().flipX = false;
    }

    void OnCollisionEnter2D(Collision2D obj) {
        if (obj.collider.tag == "suelo"){
            numJump = 0;
            
        }
        if (obj.collider.tag == "jump"){

            rb.AddForce(new Vector2(0f,10f),ForceMode2D.Impulse); 
            numJump++;   
            
        }
        if (obj.collider.tag == "rip"){

            //transform.position = new Vector2(-14, 0); 
            

        }

        if (obj.collider.tag == "movePlataform"){
            numJump = 0;
            transform.parent = obj.transform;
        }

        if (obj.collider.tag == "End"){
            //Thread.Sleep(8000);
            //DisconnectPlayer();  
        }
        
    }

    

    void OnCollisionExit2D(Collision2D obj)
    {
        if (obj.collider.tag == "movePlataform"){
            
            transform.parent = null;
        }
    }

    


}
