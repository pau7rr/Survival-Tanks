using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class bala : MonoBehaviour
{
    private float dmg = TankStats.strengh;
    public TextMeshProUGUI textoRondas; //STATS
    TankStats ts = new TankStats();
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        if (collision.gameObject.tag.Equals("Enemigo")) {
            ts.sumardisparoAcertado();
            collision.gameObject.GetComponent<vidaEnemigo>().vida -= dmg;
        }
    }

    private void Start()
    {
        
    }
}
