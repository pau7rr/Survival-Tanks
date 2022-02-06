using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Rondas : MonoBehaviour
{
    //SPAWNS
    public Transform spawnpoint;
    public Transform spawnpoint1;
    public Transform spawnpoint2;
    //VARIABLES
    private int ronda = 1;
    private int spawns = 0;
    private int maxSpawns = 0;
    private int maxenemigos = 3;
    private GameObject[] enemigos;
    public TextMeshProUGUI textoRondas;
    public TextMeshProUGUI textoEnemigo;
    //ENEMIGOS
    public GameObject Boss;
    public GameObject enemigo1;
    public GameObject enemigo2;
    public GameObject enemigo3;
    //PLAYER
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        textoRondas.text = "Ronda: " + ronda;
        Instantiate(enemigo1, spawnpoint1.position, spawnpoint1.rotation);
         Instantiate(enemigo1, spawnpoint2.position, spawnpoint2.rotation);
        Instantiate(enemigo1, spawnpoint.position, spawnpoint.rotation);
        player =GameObject.FindGameObjectWithTag("Player"); 
    }

    // Update is called once per frame
    void Update()
    {
        textoRondas.text = "Ronda: " + ronda;
        enemigos = GameObject.FindGameObjectsWithTag("Enemigo");
        textoEnemigo.text = "Enemigos: " + enemigos.Length;
        if (enemigos.Length == 0) {
            Debug.LogWarning(maxSpawns);
            if (spawns == maxSpawns) { passarRonda(); } else { Spawn(); }
           
        }
    }

    void passarRonda() {
        player.GetComponent<vidaPlayer>().vida += 25;
        if (player.GetComponent<vidaPlayer>().vida >= 100) { player.GetComponent<vidaPlayer>().vida = 100; }
        ronda = ronda + 1;
        textoRondas.text = "Round" + ronda;
        spawns = 0;
        Debug.LogWarning("passo de ronda");
        if (ronda < 4) {
            Instantiate(enemigo1, spawnpoint1.position, spawnpoint1.rotation);
            Instantiate(enemigo1, spawnpoint2.position, spawnpoint2.rotation);
            Instantiate(enemigo1, spawnpoint.position, spawnpoint.rotation);
            
        }
        if (ronda == 3) { maxSpawns += 1; }
        if (ronda == 4)
        {
            Instantiate(enemigo2, spawnpoint1.position, spawnpoint1.rotation);
            Instantiate(enemigo1, spawnpoint2.position, spawnpoint2.rotation);
            Instantiate(enemigo2, spawnpoint.position, spawnpoint.rotation);
        }




        if (ronda <= 9 && ronda > 6)
        {

            Instantiate(enemigo2, spawnpoint1.position, spawnpoint1.rotation);
            Instantiate(enemigo2, spawnpoint2.position, spawnpoint2.rotation);
            Instantiate(enemigo3, spawnpoint.position, spawnpoint.rotation);

        }

        if (ronda > 11)
        {

            Instantiate(enemigo2, spawnpoint1.position, spawnpoint1.rotation);
            Instantiate(enemigo2, spawnpoint2.position, spawnpoint2.rotation);
            Instantiate(enemigo3, spawnpoint.position, spawnpoint.rotation);

        }
        //Boss
        if (ronda == 5)
        {
            Instantiate(Boss, spawnpoint1.position, spawnpoint1.rotation);

        }


        if (ronda == 10)
        {
            Instantiate(Boss, spawnpoint1.position, spawnpoint1.rotation);

        }


        if (ronda == 15)
        {
            Instantiate(Boss, spawnpoint1.position, spawnpoint1.rotation);

        }
        if (ronda == 20)
        {
            Instantiate(Boss, spawnpoint1.position, spawnpoint1.rotation);
            Instantiate(Boss, spawnpoint2.position, spawnpoint2.rotation);
        }


    }

    void Spawn()
    {
        spawns += 1;
        Debug.LogWarning("spawn");
        if (ronda < 4)
        {
            Instantiate(enemigo1, spawnpoint1.position, spawnpoint1.rotation);
            Instantiate(enemigo1, spawnpoint2.position, spawnpoint2.rotation);
            Instantiate(enemigo1, spawnpoint.position, spawnpoint.rotation);
        }

        if (ronda == 4)
        {
            Instantiate(enemigo2, spawnpoint1.position, spawnpoint1.rotation);
            Instantiate(enemigo1, spawnpoint2.position, spawnpoint2.rotation);
            Instantiate(enemigo2, spawnpoint.position, spawnpoint.rotation);
        }

        if (ronda >= 6)
        {
            Instantiate(enemigo2, spawnpoint1.position, spawnpoint1.rotation);
            Instantiate(enemigo2, spawnpoint2.position, spawnpoint2.rotation);
            Instantiate(enemigo3, spawnpoint.position, spawnpoint.rotation);
        }

    }

}
