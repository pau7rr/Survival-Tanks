using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidaEnemigo : MonoBehaviour
{
    public float vida;
    public int tipoE;
    public GameObject moneda;
    private int ronda;
    public GameObject explosion;
    //STATS
    TankStats ts = new TankStats();
    // Start is called before the first frame update
    void Start()
    {
        ronda = GameObject.FindGameObjectWithTag("rondas").GetComponent<Rondas>().getrondas();
        DatosEnemigosParseado de = new DatosEnemigosParseado();
        float velocidad = this.GetComponent<AIPath>().maxSpeed;
        if (ronda == null) { ronda = 1; }
        if (ronda <= 20) {
            //Boss
            if (tipoE == 0) { vida = 270; }
            //Set up Enemigos
            if (tipoE == 1) { vida = de.getE1().health; velocidad = de.getE1().speed;}
            if (tipoE == 2) { vida = de.getE2().health; velocidad = de.getE2().speed; }
            if (tipoE == 3) { vida = de.getE3().health; velocidad = de.getE3().speed; }
        }

        if (ronda >= 21)
        {
            //Boss
            if (tipoE == 0) { vida = 315; }
            //Enemigos
            if (tipoE == 1) { vida = de.getE1().health +25; }
            if (tipoE == 2) { vida = de.getE2().health +25; }
            if (tipoE == 3) { vida = de.getE3().health +25; }
        }
        Debug.LogWarning(vida);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (vida <= 0) {
            Instantiate(explosion, this.transform.position, moneda.transform.rotation);
            ts.sumarKill();
            Destroy(this.gameObject);
           Instantiate(moneda, this.transform.position, moneda.transform.rotation);

        }
    }
}
