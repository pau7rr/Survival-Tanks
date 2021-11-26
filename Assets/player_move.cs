using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class player_move : MonoBehaviour
{
    // variables

    public float movespeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    //public Animator animator;
    public Tilemap eventos;
    public GameObject camara;
    public LayerMask encuentros;
    public BoxCollider2D box;
    private void Start()
    {

        //if (hud2.carga == 0) { hud2.carga = 1; SceneManager.LoadScene(3); }
       // rb.constraints = (RigidbodyConstraints2D)RigidbodyConstraints.FreezeRotation;
        rb.freezeRotation = true;

    }
    // Update is called once per frame
    void Update()
    {

        //pillar imput
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //pasarlo al animador
       // animator.SetFloat("horizontal", movement.x);
       // animator.SetFloat("vertical", movement.y);
        //animator.SetFloat("speed", movement.sqrMagnitude);


    }


    void FixedUpdate()
    {
        //movement
        rb.MovePosition(rb.position + movement * movespeed * Time.deltaTime);
    }
}
