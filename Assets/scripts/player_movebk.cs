using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class player_movebk : MonoBehaviour
{

    //
   // public Track trackLeft;
 //   public Track trackRight;

    public string keyMoveForward;
    public string keyMoveReverse;
    public string keyRotateRight;
    public string keyRotateLeft;

    bool moveForward = false;
    bool moveReverse = false;
    float moveSpeed = 0f;
    float moveSpeedReverse = 0f;
    float moveAcceleration = 0.1f;
    float moveDeceleration = 0.20f;
    float moveSpeedMax = 2.5f;

    bool rotateRight = false;
    bool rotateLeft = false;
    float rotateSpeedRight = 0f;
    float rotateSpeedLeft = 0f;
    float rotateAcceleration = 4f;
    float rotateDeceleration = 10f;
    float rotateSpeedMax = 130f;


    // variables
    public AudioSource disparo;
    public float movespeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    //public Animator animator;
    public Transform spawnbala;
    public GameObject bala;
    public float bulledspeed = 20f;
    public BoxCollider2D box;
    public GameObject tank;
    public Vector3 offset = new Vector3(0, 0, 1);
    //disparo
    public float start_tiempoentredisparos;
    public float tiempoentredisparos;
    private void Start()
    {
        tiempoentredisparos = start_tiempoentredisparos;
        rb.freezeRotation = true;

    }
    // Update is called once per frame
    void Update()
    {

        //pillar imput
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        //Debug.Log(movement.x);
        //diagonal arriba
        if (movement.y == 1 && movement.x == -1) { tank.transform.eulerAngles = Vector3.forward * 50; }
        if (movement.y == 1 && movement.x == 1) { tank.transform.eulerAngles = Vector3.forward * -50; }
        //diagonal abajo
        if (movement.y == -1 && movement.x == -1) { tank.transform.eulerAngles = Vector3.forward * 125; }
        if (movement.y == -1 && movement.x == 1) { tank.transform.eulerAngles = Vector3.forward * -125; }
        //abajo y arriba
        if (movement.y == 1 && movement.x == 0) { tank.transform.eulerAngles = Vector3.forward; }
        if (movement.y == -1 && movement.x == 0) { tank.transform.eulerAngles = Vector3.forward * -180; }
        //izquierda y derecha
        if (movement.y == 0 && movement.x == 1) { tank.transform.eulerAngles = Vector3.forward * -90; }
        if (movement.y == 0 && movement.x == -1) { tank.transform.eulerAngles = Vector3.forward * 90; }


        if (tiempoentredisparos <= 0)
        {
            if (Input.GetKeyDown("space")) { disparar(); }
            
        }
        else
        {
            tiempoentredisparos -= Time.deltaTime;
        }
    }

    void disparar() {
        disparo.Play();
       GameObject balaspawned =  Instantiate(bala, spawnbala.position, spawnbala.rotation);
        Rigidbody2D cuerpo = balaspawned.GetComponent<Rigidbody2D>();
        cuerpo.AddForce(spawnbala.up * bulledspeed, ForceMode2D.Impulse);
        tiempoentredisparos = start_tiempoentredisparos;
    }
    void FixedUpdate()
    {
        //movement
        rb.MovePosition(rb.position + movement * movespeed * Time.deltaTime);
       
    }
}
