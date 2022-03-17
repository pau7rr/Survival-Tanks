using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Rondas : MonoBehaviour
{
    //SPAWNS
    public Transform spawnpoint1;
    public Transform spawnpoint2;
    public Transform spawnpoint3;
    public Transform spawnpoint4;
    public Transform spawnpoint5;
    //VARIABLES
    private int ronda = 1;
    private int spawns = 0;
    private int maxSpawns = 0;
    private int maxenemigos = 3;
    private GameObject[] enemigos;
    public TextMeshProUGUI textoRondas;
    public TextMeshProUGUI textoEnemigo;
    public List<Transform> spawnsList = new List<Transform>();
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
        textoRondas.text = "Ronda:" + ronda;
       Instantiate(enemigo1, spawnpoint1.position, spawnpoint1.rotation);
        Instantiate(enemigo1, spawnpoint2.position, spawnpoint2.rotation);
         Instantiate(enemigo1, spawnpoint3.position, spawnpoint1.rotation);
        //ESPERAR 1SEC TRAS RESPAWNEAR
        player =GameObject.FindGameObjectWithTag("Player");
        inicioLista();
    }
    public int getrondas() {
        return ronda;
    }
    // Update is called once per frame
    void Update()
    {
        textoRondas.text = "Ronda: " + ronda;
        enemigos = GameObject.FindGameObjectsWithTag("Enemigo");
        textoEnemigo.text = "Enemigos: " + enemigos.Length;
        if (enemigos.Length == 0) {
           // reiniciolista();
            if (spawns == maxSpawns) { passarRonda();} else { Spawn(); }
           
        }
    }

    void passarRonda() {
        player.GetComponent<vidaPlayer>().vida += 25;
        if (player.GetComponent<vidaPlayer>().vida >= TankStats.maxhealth) { player.GetComponent<vidaPlayer>().vida = TankStats.maxhealth; }
        ronda = ronda + 1;
        //cada dos rondas dar una bomba
         player.GetComponent<player_move>().bombas += 1; 
            textoRondas.text = "Round" + ronda;
        spawns = 0;
        Debug.LogWarning("passo de ronda");
        if (ronda < 4) {
            Instantiate(enemigo1, spawnpoint1.position, spawnpoint1.rotation);
            Instantiate(enemigo1, spawnpoint2.position, spawnpoint2.rotation);
            Instantiate(enemigo1, spawnpoint3.position, spawnpoint3.rotation);
            
        }
        if (ronda == 3) { maxSpawns += 1; }
        if (ronda == 4)
        {
            Instantiate(enemigo2, spawnpoint1.position, spawnpoint1.rotation);
            Instantiate(enemigo1, spawnpoint2.position, spawnpoint2.rotation);
            Instantiate(enemigo2, spawnpoint3.position, spawnpoint3.rotation);
        }


       
        //Boss
        if (ronda == 5)
        {
            Instantiate(Boss, spawnpoint1.position, spawnpoint1.rotation);

        }

        //TRAS PRIMER BOSS
        if (ronda <= 9 && ronda > 6)
        {
            Randomspawn();

        }
        //SEGUNDO BOSS
        if (ronda == 10)
        {
            Instantiate(Boss, spawnpoint1.position, spawnpoint1.rotation);

        }
        //TRAS SEGUNDO BOSS
        if (ronda > 11)
        {
            Randomspawn();

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

        if (ronda == 25)
        {
            Instantiate(Boss, spawnpoint1.position, spawnpoint1.rotation);
            Instantiate(Boss, spawnpoint2.position, spawnpoint2.rotation);
        }

        if (ronda == 30)
        {
            Instantiate(Boss, spawnpoint1.position, spawnpoint1.rotation);
            Instantiate(Boss, spawnpoint2.position, spawnpoint2.rotation);
            Instantiate(Boss, spawnpoint3.position, spawnpoint3.rotation);
        }

        if (ronda%5 == 0 && ronda > 30) {
            Instantiate(Boss, spawnpoint1.position, spawnpoint1.rotation);
            Instantiate(Boss, spawnpoint2.position, spawnpoint2.rotation);
            Instantiate(Boss, spawnpoint3.position, spawnpoint3.rotation);
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
            Instantiate(enemigo1, spawnpoint3.position, spawnpoint3.rotation);
        }

        if (ronda == 4)
        {
            Instantiate(enemigo2, spawnpoint1.position, spawnpoint1.rotation);
            Instantiate(enemigo1, spawnpoint2.position, spawnpoint2.rotation);
            Instantiate(enemigo2, spawnpoint3.position, spawnpoint3.rotation);
        }

        if (ronda >= 6)
        {
            Randomspawn();
        }

    }

    void reiniciolista() {
        for (int i = 0; i < spawnsList.Count; i++)
        {
                spawnsList.RemoveAt(i);

            
        }
        spawnsList.Add(spawnpoint1);
        spawnsList.Add(spawnpoint2);
        spawnsList.Add(spawnpoint3);
        spawnsList.Add(spawnpoint4);
        spawnsList.Add(spawnpoint5);
    }

    void inicioLista() {
        spawnsList.Add(spawnpoint1);
        spawnsList.Add(spawnpoint2);
        spawnsList.Add(spawnpoint3);
        spawnsList.Add(spawnpoint4);
        spawnsList.Add(spawnpoint5);
    }


    void Randomspawn() {

        int spawnNumber = Random.Range(0, spawnsList.Count - 1);
        int spawnNumber2;
        int spawnNumber3;
        do
        {
            spawnNumber2 = Random.Range(0, spawnsList.Count - 1);
        } while (spawnNumber == spawnNumber2);

        
        do
        {
            spawnNumber3 = Random.Range(0, spawnsList.Count - 1);
        } while (spawnNumber3 == spawnNumber2 || spawnNumber3 == spawnNumber);


        for (int i = 0; i < spawnsList.Count - 1; i++)
        {
            if (spawnNumber == i)
            {
                Instantiate(enemigo2, spawnsList[i].position, spawnsList[i].rotation);
                //spawnsList.RemoveAt(i);
            }
        }
     
        for (int i = 0; i < spawnsList.Count - 1 ; i++)
        {
            if (spawnNumber2 == i)
            {
                Instantiate(enemigo2, spawnsList[i].position, spawnsList[i].rotation);
                //spawnsList.RemoveAt(i);
            }
        }

        for (int i = 0; i < spawnsList.Count - 1; i++)
        {
            if (spawnNumber3 == i)
            {
                Instantiate(enemigo3, spawnsList[i].position, spawnsList[i].rotation);
               // spawnsList.RemoveAt(i);
            }
        }
    }

}
