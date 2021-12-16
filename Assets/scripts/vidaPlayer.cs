using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vidaPlayer : MonoBehaviour
{
    public float vida = 100;

    public Image barraDeVida;
    // Update is called once per frame
    void Update()
    {
        vida = Mathf.Clamp(vida, 0, 100); // declarar valor de la vida, minimo y maximo

        barraDeVida.fillAmount = vida / 100; 
    }
}
