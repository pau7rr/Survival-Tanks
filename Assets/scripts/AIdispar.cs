using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIdsparo : MonoBehaviour
{
    public float tiempoentredisparos;
    public GameObject bala;
    public float start_tiempoentredisparos;
    public GameObject jugador;
    public float bulledspeed = 20f;
    public Transform spawnbala;
    // Start is called before the first frame update
    void Start()
    {
        tiempoentredisparos = start_tiempoentredisparos;
    }

    // Update is called once per frame
    void Update()
    {
        if (tiempoentredisparos <= 0) {
            GameObject balaspawned = Instantiate(bala, spawnbala.position, spawnbala.rotation);
            Rigidbody2D cuerpo = balaspawned.GetComponent<Rigidbody2D>();
            cuerpo.AddForce(spawnbala.up * bulledspeed, ForceMode2D.Impulse);
        } else {
            tiempoentredisparos -= Time.deltaTime;
        }
    }
}
