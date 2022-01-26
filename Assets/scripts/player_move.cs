using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class player_move : MonoBehaviour
{

    

    public Track trackLeft;
    public Track trackRight;

    public string keyMoveForward;
    public string keyMoveReverse;
    public string keyRotateRight;
    public string keyRotateLeft;

    bool moveForward = false;
    bool moveReverse = false;
    float moveSpeed = 1f;
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
    public Animator animator;
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
       // movement.x = Input.GetAxisRaw("Horizontal");
        //movement.y = Input.GetAxisRaw("Vertical");
        //Debug.Log(movement.x);
        //diagonal arriba
        rotateLeft = (Input.GetKeyDown(keyRotateLeft)) ? true : rotateLeft;
        rotateLeft = (Input.GetKeyUp(keyRotateLeft)) ? false : rotateLeft;
        if (rotateLeft)
        {
            rotateSpeedLeft = (rotateSpeedLeft < rotateSpeedMax) ? rotateSpeedLeft + rotateAcceleration : rotateSpeedMax;
        }
        else
        {
            rotateSpeedLeft = (rotateSpeedLeft > 0) ? rotateSpeedLeft - rotateDeceleration : 0;
        }
        transform.Rotate(0f, 0f, rotateSpeedLeft * Time.deltaTime);

        rotateRight = (Input.GetKeyDown(keyRotateRight)) ? true : rotateRight;
        rotateRight = (Input.GetKeyUp(keyRotateRight)) ? false : rotateRight;
        if (rotateRight)
        {
            rotateSpeedRight = (rotateSpeedRight < rotateSpeedMax) ? rotateSpeedRight + rotateAcceleration : rotateSpeedMax;
        }
        else
        {
            rotateSpeedRight = (rotateSpeedRight > 0) ? rotateSpeedRight - rotateDeceleration : 0;
        }
        transform.Rotate(0f, 0f, rotateSpeedRight * Time.deltaTime * -1f);

        moveForward = (Input.GetKeyDown(keyMoveForward)) ? true : moveForward;
        moveForward = (Input.GetKeyUp(keyMoveForward)) ? false : moveForward;
        if (moveForward)
        {
            moveSpeed = (moveSpeed < moveSpeedMax) ? moveSpeed + moveAcceleration : moveSpeedMax;
        }
        else
        {
            moveSpeed = (moveSpeed > 0) ? moveSpeed - moveDeceleration : 0;
        }
        transform.Translate(0f, moveSpeed * Time.deltaTime, 0f);

        moveReverse = (Input.GetKeyDown(keyMoveReverse)) ? true : moveReverse;
        moveReverse = (Input.GetKeyUp(keyMoveReverse)) ? false : moveReverse;
        if (moveReverse)
        {
            moveSpeedReverse = (moveSpeedReverse < moveSpeedMax) ? moveSpeedReverse + moveAcceleration : moveSpeedMax;
        }
        else
        {
            moveSpeedReverse = (moveSpeedReverse > 0) ? moveSpeedReverse - moveDeceleration : 0;
        }
        transform.Translate(0f, moveSpeedReverse * Time.deltaTime * -1f, 0f);

        if (moveForward | moveReverse | rotateRight | rotateLeft)
        {
            trackStart();
        }
        else
        {
            trackStop();
        }

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
       // rb.MovePosition(rb.position + movement * movespeed * Time.deltaTime);
       
    }

    void trackStart()
    {
       // trackLeft.animator.SetBool("isMoving", true);
       // trackRight.animator.SetBool("isMoving", true);
    }

    void trackStop()
    {
       // trackLeft.animator.SetBool("isMoving", false);
       // trackRight.animator.SetBool("isMoving", false);
    }
}
