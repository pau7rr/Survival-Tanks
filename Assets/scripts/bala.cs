using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class bala : MonoBehaviour
{
    public float dmg = 20;
    public TextMeshProUGUI textoRondas;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        if (collision.gameObject.tag.Equals("Enemigo")) {
            collision.gameObject.GetComponent<vidaEnemigo>().vida -= dmg;

        }
    }
}
