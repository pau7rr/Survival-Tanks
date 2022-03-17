using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaEnemiga : MonoBehaviour
{
    float dmg ;
    public Rigidbody2D rigid;
    private int ronda;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        if (collision.gameObject.tag.Equals("Player"))
        {
            // Destroy(collision.gameObject);
            //rigid.Sleep();
            collision.gameObject.GetComponent<vidaPlayer>().vida -= dmg;
            //vida -= dmg;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ronda =  GameObject.FindGameObjectWithTag("rondas").GetComponent<Rondas>().getrondas();
        if (ronda <= 20) { dmg = 20; }
        if (ronda >= 21) { dmg = 40; }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
