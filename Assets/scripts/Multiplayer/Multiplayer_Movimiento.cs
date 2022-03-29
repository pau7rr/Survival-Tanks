using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class Multiplayer_Movimiento : MonoBehaviour
{

    public PhotonView pv;

    public Track trackLeft;
    public Track trackRight;

    public string keyMoveForward;
    public string keyMoveReverse;
    public string keyRotateRight;
    public string keyRotateLeft;
    //public AimTurret aimTurret;
    bool moveForward = false;
    bool moveReverse = false;
    float moveSpeed = TankStats.speed + 1;
    float moveSpeedReverse = 3f;
    float moveAcceleration = 4f;
    float moveDeceleration = 0.10f;
    float moveSpeedMax = TankStats.speed + 1;

    bool rotateRight = false;
    bool rotateLeft = false;
    float rotateSpeedRight = 0f;
    float rotateSpeedLeft = 0f;
    float rotateAcceleration = 6f;
    float rotateDeceleration = 10f;
    float rotateSpeedMax = 130f;
    //contador de balas y bombas
    private GameObject[] balas;
    public int bombas = 3;
    // variables
    public AudioSource disparo;
    //public float movespeed = 5f;
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
    //EFECTOS
    public GameObject bombaT;
    public TextMeshProUGUI textoBombas;
    //STATS
    TankStats ts = new TankStats();
    public GameObject canvas;
    //CAMERA
    public CinemachineVirtualCamera cam;
    //chat
    private InputField inputj;
    void Start()
    {
        inputj = GameObject.Find("InputField").GetComponent<InputField>();
        tiempoentredisparos = start_tiempoentredisparos;
        rb.freezeRotation = true;
        canvas.GetComponent<Canvas>().worldCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        cam = GameObject.Find("CMvcam1").GetComponent<CinemachineVirtualCamera>();
        if (pv.IsMine)
        {
            cam.Follow = this.transform;
            Debug.LogWarning(GameObject.Find("CMvcam1").GetComponent<CinemachineVirtualCamera>());
            
        }
       
    }


    // Update is called once per frame
    void Update()
    {
        //bombas
         // textoBombas.text = "Bombas: " + bombas;
        if (!pv.IsMine) { return; }
        if (bombas >= 1 && !inputj.isFocused) { if (Input.GetKeyDown(KeyCode.E)) { Debug.LogWarning("e pressed"); fuckbalas(); } }
        if (!inputj.isFocused)
        {
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
                //if (Input.GetKeyDown("space")) { disparar(); }
                if (Input.GetKeyDown(KeyCode.Mouse0)) { disparar(); }

            }
            else
            {
                tiempoentredisparos -= Time.deltaTime;
            }
            //HandleTurretMovement(pointerPosition)
        }
    }

    void disparar()
    {
        if (!pv.IsMine) { return; }
        disparo.Play();
        ts.sumardisparo();
        GameObject balaspawned = PhotonNetwork.Instantiate(bala.name, spawnbala.position, spawnbala.rotation);
        Rigidbody2D cuerpo = balaspawned.GetComponent<Rigidbody2D>();
        cuerpo.AddForce(spawnbala.up * bulledspeed, ForceMode2D.Impulse);
        tiempoentredisparos = start_tiempoentredisparos;
    }


    void trackStart()
    {

        trackLeft.animator.SetBool("isMoving", true);
        trackRight.animator.SetBool("isMoving", true);
    }


    void trackStop()
    {
        trackLeft.animator.SetBool("isMoving", false);
        trackRight.animator.SetBool("isMoving", false);
    }


    void fuckbalas()
    {
        if (!pv.IsMine) { return; }
        Debug.LogWarning("bomba");
        bombas -= 1;
        GameObject bomba = PhotonNetwork.Instantiate(bombaT.name, this.transform.position, bombaT.transform.rotation);
        balas = GameObject.FindGameObjectsWithTag("bala");
        foreach (var item in balas)
        {

            Debug.LogWarning("bombasfde");
           item.GetComponent<PhotonView>().RPC("DestroyBalasotro", RpcTarget.AllBuffered);
        }

    }
}