using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoBoss : MonoBehaviour
{
    public float tiempoentredisparos;
    public GameObject bala;
    public float start_tiempoentredisparos;
    public GameObject jugador;
    public float bulledspeed = 20f;
    public Transform spawnbala;
    public Transform spawnbala2;
    public Transform spawnbala3;
    public Transform spawnbala4;
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

            GameObject balaspawned2 = Instantiate(bala, spawnbala2.position, spawnbala.rotation);
            Rigidbody2D cuerpo2 = balaspawned2.GetComponent<Rigidbody2D>();
            cuerpo2.AddForce(spawnbala.up * bulledspeed, ForceMode2D.Impulse);

            GameObject balaspawned3 = Instantiate(bala, spawnbala3.position, spawnbala.rotation);
            Rigidbody2D cuerpo3 = balaspawned3.GetComponent<Rigidbody2D>();
            cuerpo3.AddForce(spawnbala.up * bulledspeed, ForceMode2D.Impulse);
            tiempoentredisparos = start_tiempoentredisparos;
        }
        else
        {
            tiempoentredisparos -= Time.deltaTime;
        }
    }
}
