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
    public GameObject tank;
    public Vector3 offset = new Vector3(0, 0, 1);
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
        //Debug.Log(movement.x);
        Debug.Log(movement.y);
        if (Input.GetKeyDown("left")) { tank.transform.eulerAngles =Vector3.forward * 90; }
        if (Input.GetKeyDown("right")) { tank.transform.eulerAngles = Vector3.forward * - 90; }
        if (Input.GetKeyDown("up")) { tank.transform.eulerAngles = Vector3.forward; }
        if (Input.GetKeyDown("down")) { tank.transform.eulerAngles = Vector3.forward * -180; }

    }


    void FixedUpdate()
    {
        //movement
        rb.MovePosition(rb.position + movement * movespeed * Time.deltaTime);
       
    }
}
