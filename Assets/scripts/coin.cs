using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    public AudioSource coinsound;
    public GameObject sonidos;
    // Start is called before the first frame update
    void Start()
    {
     sonidos = GameObject.FindGameObjectWithTag("Sonidos")  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            coinsound.Play();
            Destroy(this.gameObject);
            col.GetComponent<vidaPlayer>().monedas += 1;
        }
    }
}
