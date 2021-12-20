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
            GameObject balaspawned = Instantiate(bala, spawnbala.position, spawnbala.rotation);
            Rigidbody2D cuerpo = balaspawned.GetComponent<Rigidbody2D>();
            cuerpo.AddForce(spawnbala.up * bulledspeed, ForceMode2D.Impulse);
            tiempoentredisparos = start_tiempoentredisparos;
        }
        else
        {
            tiempoentredisparos -= Time.deltaTime;
        }
    }
}
