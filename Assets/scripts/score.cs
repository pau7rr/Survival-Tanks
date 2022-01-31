using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score : MonoBehaviour
{
    private int puntuacion;
    // Start is called before the first frame update
    void Start()
    {
        puntuacion = 0;
    }

   private void OnTriggerEnter2D(Collider2D collision)
   {
       if (collision.gameObject.name == "Moneda")
       {
           puntuacion++;
           Debug.Log(puntuacion);
       }
   }
}
