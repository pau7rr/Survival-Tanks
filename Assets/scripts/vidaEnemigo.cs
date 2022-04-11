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
        Debug.LogWarning("rondaa " +ronda);
        if (ronda <= 20) {
            //Boss
            if (tipoE == 0) { vida = 270; }
            //Enemigos
            if (tipoE == 1) { vida = 40; }
            if (tipoE == 2) { vida = 20; }
            if (tipoE == 3) { vida = 80; }
        }

        if (ronda >= 21)
        {
            //Boss
            if (tipoE == 0) { vida = 315; }
            //Enemigos
            if (tipoE == 1) { vida = 60; }
            if (tipoE == 2) { vida = 40; }
            if (tipoE == 3) { vida = 110; }
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
