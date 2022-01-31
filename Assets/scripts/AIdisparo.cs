using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIdisparo : MonoBehaviour
{
    public float tiempoentredisparos ;
    public GameObject bala;
    public float start_tiempoentredisparos ;
    public GameObject jugador;
    public float bulledspeed = 20f;
    public Transform spawnbala;
    public Transform spawnbala2;
    public bool disparodoble;
    // Start is called before the first frame update
    void Start()
    {
        tiempoentredisparos = start_tiempoentredisparos;
        jugador = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per fra
    void Update()
    {
        if (tiempoentredisparos <= 0)
        {
            if (!disparodoble) {
                GameObject balaspawned = Instantiate(bala, spawnbala.position, spawnbala.rotation);
                Rigidbody2D cuerpo = balaspawned.GetComponent<Rigidbody2D>();
                cuerpo.AddForce(spawnbala.up * bulledspeed, ForceMode2D.Impulse);
            } else {
                GameObject balaspawned = Instantiate(bala, spawnbala.position, spawnbala.rotation);
                Rigidbody2D cuerpo = balaspawned.GetComponent<Rigidbody2D>();
                cuerpo.AddForce(spawnbala.up * bulledspeed, ForceMode2D.Impulse);
                //bala 2

                GameObject balaspawned2 = Instantiate(bala, spawnbala2.position, spawnbala2.rotation);
                Rigidbody2D cuerpo2 = balaspawned2.GetComponent<Rigidbody2D>();
                cuerpo2.AddForce(spawnbala2.up * bulledspeed, ForceMode2D.Impulse);

            }
            
            tiempoentredisparos = start_tiempoentredisparos;
        }
        else
        {
            tiempoentredisparos -= Time.deltaTime;
        }
    }
}
