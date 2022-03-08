using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidaEnemigo : MonoBehaviour
{
    public float vida = 100;
    public int tipoE;
    public GameObject moneda;
    // Start is called before the first frame update
    void Start()
    {
        //Boss
        if (tipoE == 0) { vida = 200; }
        //Enemigos
        if (tipoE == 1) { vida = 40; }
        if (tipoE == 2) { vida = 20; }
        if (tipoE == 3) { vida = 80; }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (vida <= 0) { Destroy(this.gameObject);
           Instantiate(moneda, this.transform.position, moneda.transform.rotation);
        }
    }
}
