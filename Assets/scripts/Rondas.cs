using System.Collections.Generic;
using TMPro;
using UnityEngine;
using BayatGames.SaveGameFree;
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
    private GameObject[] enemigos;
    public TextMeshProUGUI textoRondas;
    public TextMeshProUGUI textoEnemigo;
    public List<Transform> spawnsList = new List<Transform>();
    //ENEMIGOS
    public GameObject Boss;
    public GameObject enemigo1;
    public GameObject enemigo2;
    public GameObject enemigo3;
    public List<GameObject> spawnEnemies = new List<GameObject>();
    //PLAYER
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        if (SaveGame.Load<int>("guardado") == 1) { 
            ronda = SaveGame.Load<int>("ronda");
            if (ronda >= 3) { maxSpawns = 1 ; }
        } else {
            Instantiate(enemigo1, spawnpoint1.position, spawnpoint1.rotation);
            Instantiate(enemigo1, spawnpoint2.position, spawnpoint2.rotation);
            Instantiate(enemigo1, spawnpoint3.position, spawnpoint1.rotation);
        }
        textoRondas.text = ": " + ronda;
        //ESPERAR 1SEC TRAS RESPAWNEAR
        player =GameObject.FindGameObjectWithTag("Player");
        inicioLista();
        if (SaveGame.Load<int>("guardado") == 1) {
            passarRonda();
        }
    }
    public int getrondas() {
        return ronda;
    }
    // Update is called once per frame
    void Update()
    {
        textoRondas.text = ": " + ronda;
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
         textoRondas.text = ": " + ronda;
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


    void inicioLista() {
        //Añadimos Spawnpoints
        spawnsList.Add(spawnpoint1);
        spawnsList.Add(spawnpoint2);
        spawnsList.Add(spawnpoint3);
        spawnsList.Add(spawnpoint4);
        spawnsList.Add(spawnpoint5);
        //Añadimos Enemigos
        spawnEnemies.Add(enemigo2);
        spawnEnemies.Add(enemigo3);
    }


    void Randomspawn() {
        //creo 3 numeros random que no sean repetidos
        int spawnNumber = Random.Range(0, 5);
        int spawnNumber2;
        int spawnNumber3;
        do
        {
            spawnNumber2 = Random.Range(0, 5);
        } while (spawnNumber == spawnNumber2);

        
        do
        {
            spawnNumber3 = Random.Range(0, 5);
        } while (spawnNumber3 == spawnNumber2 || spawnNumber3 == spawnNumber);

        //indico que tipos de enemigos van a respawnear random
        int enemigo1Spawn = Random.Range(0, 2);
        int enemigo2Spawn = Random.Range(0, 2);
        int enemigo3Spawn = Random.Range(0, 2);

        //Spawneo a los enemigos
        for (int i = 0; i <= 4; i++)
        {
            if (spawnNumber == i)
            {
                Instantiate(spawnEnemies[enemigo1Spawn], spawnsList[i].position, spawnsList[i].rotation);
            }
        }
     
        for (int i = 0; i <= 4 ; i++)
        {
            if (spawnNumber2 == i)
            {
                Instantiate(spawnEnemies[enemigo2Spawn], spawnsList[i].position, spawnsList[i].rotation);
            }
        }

        for (int i = 0; i <= 4; i++)
        {
            if (spawnNumber3 == i)
            {
                Instantiate(spawnEnemies[enemigo3Spawn], spawnsList[i].position, spawnsList[i].rotation);
            }
        }
    }

}
