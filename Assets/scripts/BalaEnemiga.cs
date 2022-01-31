using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaEnemiga : MonoBehaviour
{
    float dmg = 20;
    public Rigidbody2D rigid;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
