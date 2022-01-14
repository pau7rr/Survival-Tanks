using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vidaPlayer : MonoBehaviour
{
    public float vida = 100;

    public Image barraDeVida;
    void Start()
    {

        vida = Mathf.Clamp(vida, 0, 100);
        barraDeVida = GameObject.FindGameObjectWithTag("vida").GetComponent<Image>();
    }
    // Update is called once per frame
    void Update()
    { // declarar valor de la vida, minimo y maximo

        barraDeVida.fillAmount = Mathf.Clamp(vida / 100, 0, 1f);
    Debug.LogWarning(vida);
    }

}
